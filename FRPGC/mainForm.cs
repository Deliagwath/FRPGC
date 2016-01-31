using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRPGC
{
    public partial class mainForm : Form
    {
        private string log = "FRPGCLog";
        private Log logger;
        
        private string[] files = new string[]
        {
            "Weapons.csv",
            "Armours.csv",
            "Stats.csv",
            "Units.csv",
            "PlayerStats.csv",
            "Players.csv"
        };

        private BindingList<Weapon>         weapons = new BindingList<Weapon>();
        private BindingList<Armour>         armours = new BindingList<Armour>();
        private BindingList<Unit>           units   = new BindingList<Unit>();
        private BindingList<Stat>          stats   = new BindingList<Stat>();
        private BindingList<Player>         players = new BindingList<Player>();
        private BindingList<PlayerStat>    pstats  = new BindingList<PlayerStat>();

        public mainForm()
        {
            InitializeComponent();
            logger = new Log(log, this.textLog);
        }

        public void getData()
        {
            this.logger.writeLog("Fetching Data");

            // Initialise null Containers
            StreamReader reader = null;

            // Initialise Check Array and Counter
            int pass = 0, fail = 0;

            foreach (string filename in this.files)
            {
                this.logger.writeLog("Reading from " + filename);
                try
                {
                    // Reading from File
                    reader = new StreamReader(filename);

                    switch (filename)
                    {
                        case ("Weapons.csv"):
                            getWeapons(reader);
                            break;

                        case ("Armours.csv"):
                            getArmours(reader);
                            break;

                        case ("Stats.csv"):
                            getStats(reader);
                            break;

                        case ("Units.csv"):
                            getUnits(reader);
                            break;

                        case ("PlayerStats.csv"):
                            getPlayerStats(reader);
                            break;

                        case ("Players.csv"):
                            getPlayers(reader);
                            break;
                        
                        default:
                            this.logger.logBoth("This parsing shit gone wrong yo");
                            break;
                    }
                }
                
                // Catches and Finally to Log and close StreamReader
                catch (Exception e)
                {
                    this.logger.writeLog("Exception Occurred: " + e.ToString());
                    this.logger.writeLog("Ignoring " + filename);
                    try { reader.Close(); } catch { }
                    fail++;
                }
                finally
                {
                    this.logger.writeLog("Read Finished from " + filename);
                    try { reader.Close(); } catch { }
                    pass++;
                }
            }

            this.logger.writeLog("Data Retrieval Completed.");
            this.logger.writeLog(String.Format("{0} of {1} logs retrieved", pass.ToString(), (pass + fail).ToString()));
            return;
        }

        public Object searchListByID(string id, ListTypes lt)
        {
            switch (lt)
            {
                case (ListTypes.Weapons):
                    foreach (Weapon weapon in this.weapons)
                    {
                        if (weapon.ID.Equals(id))
                        {
                            return weapon;
                        }
                    }
                    break;

                case (ListTypes.Armours):
                    foreach (Armour armour in this.armours)
                    {
                        if (armour.ID.Equals(id))
                        {
                            return armour;
                        }
                    }
                    break;

                case (ListTypes.Units):
                    foreach (Unit unit in this.units)
                    {
                        if (unit.ID.Equals(id))
                        {
                            return unit;
                        }
                    }
                    break;

                case (ListTypes.Stats):
                    foreach (Stat stat in this.stats)
                    {
                        if (stat.ID.Equals(id))
                        {
                            return stat;
                        }
                    }
                    break;

                default:
                    this.logger.logBoth(String.Format("Searching for id: {0}, type: {1}", id, lt.ToString()));
                    break;
            }

            return null;
        }

        public void getWeapons(StreamReader reader)
        {
            string line = null, name = null, id = null;
            int singleRange = 0, constant = 0, multiplier = 0, roll = 0, shotPerBurst = 0;
            Dice baseDamage = null, additionalDamage = null;
            AttackRange weaponRange;
            DamageTypes damageType;
            WeaponSkillType weaponType;
            string[] splitted = null, constantSplit = null, diceSplit = null;

            while ((line = reader.ReadLine()) != null)
            {
                // Weapons {"Name":0, "ID":1, "Range":2, "BD":3, "AD":4, "SPB"(Shots per burst):5, "DamageType":6}
                splitted = line.Trim().Split(',');
                name = splitted[0].Trim();
                this.logger.logBoth(String.Format("Parsing {0}", name));
                id = splitted[1].Trim();

                // Parse Range X\Y or X Format
                // Range X\Y is obsolete, new Range system uses one Optimal Range.
                try
                {
                    // Parsing X\Y Format
                    // Left to support legacy information
                    // Ignores second part
                    constantSplit = splitted[2].Trim().Split('\\');
                    singleRange = int.Parse(constantSplit[0].Trim());
                }
                catch
                {
                    try
                    {
                        singleRange = int.Parse(splitted[2].Trim());
                    }
                    catch
                    {
                        this.logger.logBoth(String.Format("Range could not be parsed. Expected int, got: {0}", splitted[2].Trim()));
                        continue;
                    }
                }
                
                // Parse Base Damage X+YdZ or XdY or X Format
                try
                {
                    // Parsing X+YdZ || XdY+Z Format
                    constantSplit = splitted[3].Trim().Split('+');
                    if (constantSplit[0].Length > constantSplit[1].Length)
                    {
                        diceSplit = constantSplit[0].Trim().ToLower().Split('d');
                        constant = int.Parse(constantSplit[1].Trim());
                        multiplier = int.Parse(diceSplit[0].Trim());
                        roll = int.Parse(diceSplit[1].Trim());
                    }
                    else
                    {
                        diceSplit = constantSplit[1].Trim().ToLower().Split('d');
                        constant = int.Parse(constantSplit[0].Trim());
                        multiplier = int.Parse(diceSplit[0].Trim());
                        roll = int.Parse(diceSplit[1].Trim());
                    }
                    baseDamage = new Dice(multiplier, roll, this.logger);
                }
                catch
                {
                    try
                    {
                        // Parsing XdY Format
                        diceSplit = splitted[3].Trim().ToLower().Split('d');
                        constant = 0;
                        multiplier = int.Parse(diceSplit[0].Trim());
                        roll = int.Parse(diceSplit[1].Trim());
                        baseDamage = new Dice(multiplier, roll, this.logger);
                    }
                    catch
                    {
                        try
                        {
                            // Parsing X Format
                            constant = 0;
                            multiplier = int.Parse(splitted[3]);
                            baseDamage = new Dice(multiplier, 1, this.logger);
                        }
                        catch
                        {
                            this.logger.logBoth(String.Format("Base Damage could not be parsed. Expected X+YdZ or XdY or X, got: {0}", splitted[3].Trim()));
                            continue;
                        }
                    }
                }

                // Parse Additional Damage X+YdZ or XdY or X Format
                try
                {
                    // Parsing X+YdZ || XdY+Z Format
                    constantSplit = splitted[4].Trim().Split('+');
                    if (constantSplit[0].Length > constantSplit[1].Length) {
                        diceSplit = constantSplit[0].Trim().ToLower().Split('d');
                        constant = int.Parse(constantSplit[1].Trim());
                        multiplier = int.Parse(diceSplit[0].Trim());
                        roll = int.Parse(diceSplit[1].Trim());
                    }
                    else {
                        diceSplit = constantSplit[1].Trim().ToLower().Split('d');
                        constant = int.Parse(constantSplit[0].Trim());
                        multiplier = int.Parse(diceSplit[0].Trim());
                        roll = int.Parse(diceSplit[1].Trim());
                    }
                    baseDamage = new Dice(multiplier, roll, this.logger);
                }
                catch
                {
                    try
                    {
                        // Parsing XdY Format
                        diceSplit = splitted[4].Trim().ToLower().Split('d');
                        constant = 0;
                        multiplier = int.Parse(diceSplit[0].Trim());
                        roll = int.Parse(diceSplit[1].Trim());
                        additionalDamage = new Dice(multiplier, roll, this.logger);
                    }
                    catch
                    {
                        try
                        {
                            // Parsing X Format
                            constant = 0;
                            multiplier = int.Parse(splitted[4]);
                            additionalDamage = new Dice(multiplier, 1, this.logger);
                        }
                        catch
                        {
                            this.logger.logBoth(String.Format("Additional Damage could not be parsed. Expected X+YdZ or XdY or X, got: {0}", splitted[4].Trim()));
                            continue;
                        }
                    }
                }

                try
                {
                    if (splitted[5].Trim().ToUpper().Equals("NA")) { shotPerBurst = 1; }
                    else { shotPerBurst = int.Parse(splitted[5].Trim()); }
                }
                catch
                {
                    this.logger.logBoth(String.Format("Shot Per Burst could not be parsed. Expected int, got: {0}", splitted[5].Trim()));
                    continue;
                }

                // Parsing Classification
                switch (splitted[6].Trim().ToUpper())
                {
                    case ("M"):
                        weaponRange = AttackRange.M;
                        break;
                    
                    case ("SR"):
                        weaponRange = AttackRange.SR;
                        break;

                    case ("LR"):
                        weaponRange = AttackRange.LR;
                        break;

                    default:
                        this.logger.logBoth(String.Format("Classification could not be parsed. Expected M|SR|LR, got: {0}", splitted[6].Trim().ToUpper()));
                        continue;
                }

                // Parsing Damage Type
                switch (splitted[7].Trim().ToUpper())
                {
                    case ("N"):
                        damageType = DamageTypes.N;
                        break;

                    case ("LA"):
                        damageType = DamageTypes.LA;
                        break;
                    
                    case ("PL"):
                        damageType = DamageTypes.PL;
                        break;
                    
                    case ("EL"):
                        damageType = DamageTypes.EL;
                        break;

                    case ("FR"):
                        damageType = DamageTypes.FR;
                        break;

                    case ("EX"):
                        damageType = DamageTypes.EX;
                        break;
                    
                    default:
                        this.logger.logBoth(String.Format("DamageType could not be parsed. Expected N|LA|PL|EL|FR|EX, got: {0}", splitted[7].Trim().ToUpper()));
                        continue;
                }

                // Parsing Weapon Type (Which Skill it is dependant upon)
                switch (splitted[8].Trim().ToUpper())
                {
                    case ("BIGGUNS"):
                    case ("BG"):
                        weaponType = WeaponSkillType.BigGuns;
                        break;

                    case ("ENERGYWEAPONS"):
                    case ("EW"):
                        weaponType = WeaponSkillType.EnergyWeapons;
                        break;

                    case ("EXPLOSIVES"):
                    case ("EX"):
                        weaponType = WeaponSkillType.Explosives;
                        break;

                    case ("SMALLGUNS"):
                    case ("SG"):
                        weaponType = WeaponSkillType.SmallGuns;
                        break;

                    case ("UNARMED"):
                    case ("U"):
                        weaponType = WeaponSkillType.Unarmed;
                        break;

                    case ("MELEE"):
                    case ("M"):
                        weaponType = WeaponSkillType.Melee;
                        break;

                    default:
                        this.logger.logBoth(String.Format("WeaponType could not be parsed. Expected BigGuns|BG|EnergyWeapons|EW|Explosives|E|SmallGuns|SG|Unarmed|U|Melee|M, got: {0}", splitted[8].Trim().ToUpper()));
                        continue;
                }

                // Creating Weapon Object and adding to List
                this.weapons.Add(new Weapon(name, id, singleRange, constant, baseDamage, additionalDamage, shotPerBurst, weaponRange, damageType, weaponType));
            }

            // Binding to ComboBox
            this.comboWeapon.DataSource = this.weapons;
            this.comboWeapon.ValueMember = "ID";
            this.comboWeapon.DisplayMember = "Name";
        }

        public void dumpWeapons(object sender, EventArgs e)
        {
            this.logger.logBoth("Dumping");
            foreach (Weapon w in this.weapons)
            {
                this.logger.logBoth(w.ToString());
            }
        }

        public void getArmours(StreamReader reader)
        {
            string line, name, id = null;
            string[] splitted = null;

            while ((line = reader.ReadLine()) != null)
            {
                // Armours {"Name":0, "ID":1, "AC":2, "DR":3, "DR LA":4, "DR PL":5, "DR EL":6, "DR FR":7, "DR EX":8}
                splitted = line.Trim().Split(',');

                name = splitted[0].Trim();
                this.logger.logBoth(String.Format("Parsing {0}", name));
                id = splitted[1].Trim();

                // Creating Armour Object and adding to List
                this.armours.Add(new Armour(name, id,
                    int.Parse(splitted[2].Trim()),
                    int.Parse(splitted[3].Trim()),
                    int.Parse(splitted[4].Trim()),
                    int.Parse(splitted[5].Trim()),
                    int.Parse(splitted[6].Trim()),
                    int.Parse(splitted[7].Trim()),
                    int.Parse(splitted[8].Trim())));
            }

            this.comboArmour.DataSource = this.armours;
            this.comboArmour.ValueMember = "ID";
            this.comboArmour.DisplayMember = "Name";
        }

        public void dumpArmours(object sender, EventArgs e)
        {
            this.logger.logBoth("Dumping");
            foreach (Armour a in this.armours)
            {
                this.logger.logBoth(a.ToString());
            }
        }

        public void getStats(StreamReader reader)
        {
            string line, id = null;
            string[] splitted = null;
            Difficulty diff;

            while ((line = reader.ReadLine()) != null)
            {
                splitted = line.Trim().Split(',');

                switch (int.Parse(splitted[13]))
                {
                    case (1):
                        diff = Difficulty.Easy;
                        break;

                    case (2):
                        diff = Difficulty.Medium;
                        break;

                    case (3):
                        diff = Difficulty.Hard;
                        break;

                    case (4):
                        diff = Difficulty.ScottIsBeingADick;
                        break;

                    default:
                        this.logger.logBoth(String.Format("Difficulty cannot be parsed: {0}", int.Parse(splitted[13])));
                        continue;
                }

                id = splitted[0].Trim();
                this.logger.writeLog(String.Format("Parsing {0}", id));
                this.stats.Add(new Stat(id, int.Parse(splitted[1]), int.Parse(splitted[2]), int.Parse(splitted[3]), int.Parse(splitted[4]), int.Parse(splitted[5]), int.Parse(splitted[6]),
                    int.Parse(splitted[7]), int.Parse(splitted[8]), int.Parse(splitted[9]), int.Parse(splitted[10]), int.Parse(splitted[11]), int.Parse(splitted[12]), diff));
            }
        }

        public void dumpStats(object sender, EventArgs e)
        {
            this.logger.logBoth("Dumping");
            foreach (Stat s in this.stats)
            {
                this.logger.logBoth(s.ToString());
            }
        }

        public void getUnits(StreamReader reader)
        {
            string line, name, id = null;
            string[] splitted = null;

            while ((line = reader.ReadLine()) != null)
            {
                splitted = line.Trim().Split(',');

                name = splitted[0].Trim();
                id = splitted[1].Trim();
                this.logger.writeLog(String.Format("Parsing {0}", name));
                this.units.Add(new Unit(name, splitted[1], (Weapon) searchListByID(id, ListTypes.Weapons), (Armour) searchListByID(id, ListTypes.Armours), (Stat) searchListByID(id, ListTypes.Stats)));
            }
        }

        public void dumpUnits(object sender, EventArgs e)
        {
            this.logger.logBoth("Dumping");
            foreach (Unit u in this.units)
            {
                this.logger.logBoth(u.ToString());
            }
        }

        public void getPlayerStats(StreamReader reader)
        {
            string line, id = null;
            string[] splitted = null;

            while ((line = reader.ReadLine()) != null)
            {
                splitted = line.Trim().Split(',');

                id = splitted[0].Trim();
                this.logger.writeLog(String.Format("Parsing {0}", id));
                this.pstats.Add(new PlayerStat(id, int.Parse(splitted[1]), int.Parse(splitted[2]), int.Parse(splitted[3]), int.Parse(splitted[4]), int.Parse(splitted[5]), int.Parse(splitted[6]),
                    int.Parse(splitted[7]), int.Parse(splitted[8]), int.Parse(splitted[9]), int.Parse(splitted[10]), int.Parse(splitted[11]), int.Parse(splitted[12]), int.Parse(splitted[13])));
            }
        }

        public void dumpPlayerStats(object sender, EventArgs e)
        {
            this.logger.logBoth("Dumping");
            foreach (Stat s in this.stats)
            {
                this.logger.logBoth(s.ToString());
            }
        }

        public void getPlayers(StreamReader reader)
        {
            string line, name, id = null;
            string[] splitted = null;

            while ((line = reader.ReadLine()) != null)
            {
                splitted = line.Trim().Split(',');

                name = splitted[0].Trim();
                id = splitted[1].Trim();
                this.logger.writeLog(String.Format("Parsing {0}", name));
                this.units.Add(new Unit(name, splitted[1], (Weapon)searchListByID(id, ListTypes.Weapons), (Armour)searchListByID(id, ListTypes.Armours), (Stat)searchListByID(id, ListTypes.Stats)));
            }
        }

        public void dumpPlayers(object sender, EventArgs e)
        {
            this.logger.logBoth("Dumping");
            foreach (Player p in this.players)
            {
                this.logger.logBoth(p.ToString());
            }
        }

        private void calculate(object sender, EventArgs e)
        {
            switch (this.comboAttackingMethod.SelectedIndex)
            {
                case (-1): // ComboBox not touched
                    MessageBox.Show("It'd be nice if you chose a Firing Mode.");
                    break;

                case (0): // Single Shot
                    if (((Weapon) this.comboWeapon.SelectedItem).Classification == AttackRange.LR)
                    {
                        textCurrentHealth.Text = (int.Parse(textInitialHealth.Text) - attack(int.Parse(textAttacksLaunched.Text), AttackTypes.LR)).ToString();
                    }
                    else
                    {
                        textCurrentHealth.Text = (int.Parse(textInitialHealth.Text) - attack(int.Parse(textAttacksLaunched.Text), AttackTypes.SRS)).ToString();
                    }
                    break;

                case (1): // Burst Shot
                    textCurrentHealth.Text = (int.Parse(textInitialHealth.Text) - attack(int.Parse(textAttacksLaunched.Text), AttackTypes.SRB)).ToString();
                    break;

                case (2): // Melee
                    break;

                default:
                    this.logger.writeLog(String.Format("ComboBox Firing Type Error, Index: {0}", this.comboAttackingMethod.SelectedIndex));
                    MessageBox.Show(String.Format("Fire Type Drop Down List says wut: ", this.comboAttackingMethod.SelectedIndex));
                    break;
            }
        }

        private int attack(int attacksLaunched, AttackTypes attackType)
        {
            int chance = -1;

            switch (attackType)
            {
                case (AttackTypes.M):
                    chance = meleeHitChance();
                    break;

                case (AttackTypes.SRS):
                    chance = shortRangeShotChance(true);
                    break;

                case (AttackTypes.SRB):
                    chance = shortRangeShotChance(false);
                    break;

                case (AttackTypes.LR):
                    chance = longRangeShotChance();
                    break;

                default:
                    this.logger.logBoth(String.Format("A weird error occured at the attack() function. The attackType is: {0}", attackType.ToString()));
                    return 0;
            }

            this.logger.logBoth(String.Format("Hit Chance: {0}", chance.ToString()));
            int[] damages = attackDamage(attacksLaunched);
            int totalDamage = 0;
            Dice dice = new Dice(1, Math.Max(100, chance), this.logger);
            Unit attacker = (Unit) this.comboAttackingUnit.SelectedItem;
            int rolled = -1;

            foreach (int damage in damages)
            {
                rolled = dice.getRoll();

                if (rolled < attacker.StatID.CriticalChance) // Critical Hit
                {
                    this.logger.logBoth(String.Format("Critical Hit: {0} < 5", rolled.ToString()));
                    this.logger.logBoth(String.Format("Damage Taken: {0}", (damage * 2).ToString()));
                    totalDamage += damage * 2;
                    continue;
                }
                if (rolled > Math.Max(100, chance) - (10 - attacker.StatID.Luck)) // Critical Failure
                {
                    this.logger.logBoth(String.Format("Critical Failure: {0} > {1}", rolled.ToString(), (Math.Max(100, chance) - (10 - attacker.StatID.Luck)).ToString()));
                    this.logger.logBoth("Ending Calculations.");
                    return totalDamage;
                }
                if (rolled < chance) // Hit
                {
                    this.logger.logBoth(String.Format("Hit: {0} < {1}", rolled.ToString(), chance.ToString()));
                    this.logger.logBoth(String.Format("Damage Taken: {0}", damage.ToString()));
                    totalDamage += damage;
                    continue;
                }
                else if (rolled > chance) // Miss
                {
                    this.logger.logBoth(String.Format("Miss: {0} > {1}", rolled.ToString(), chance.ToString()));
                    continue;
                }
                else
                {
                    this.logger.logBoth("There's a problem, contact the product owner and send the log file (It's in the same directory)");
                    return 0;
                }
            }

            return totalDamage;
        }

        private int meleeHitChance()
        {
            return ((Unit) this.comboAttackingUnit.SelectedItem).StatID.MeleeDamage - ((Unit) this.comboDefendingUnit.SelectedItem).StatID.AC;
        }

        private int shortRangeShotChance(bool singleShot)
        {
            // TODO Implement Hit Bonuses
            // =(Skill / (Range / Multiplier / Divisor |If singleShot != true|)) * Multiplier + (Optimal Range ^ 2) / (Range - (2 * Optimal Range)) + (Luck - 10)
            int skill = -1;
            switch (((Weapon) this.comboWeapon.SelectedItem).DamageType)
            {
                // Electrical (Energy Weapons)
                case (DamageTypes.EL):
                    skill = ((Unit) this.comboAttackingUnit.SelectedItem).StatID.EnergyWeapons;
                    break;

                // Explosive (Explosives)
                case (DamageTypes.EX):
                    skill = ((Unit) this.comboAttackingUnit.SelectedItem).StatID.Explosives;
                    break;

                // Normal (Small Guns) or Big?
                case (DamageTypes.N):
                    skill = ((Unit) this.comboAttackingUnit.SelectedItem).StatID.SmallGuns;
                    break;

                default:
                    return 0;
            }
            int multiplier = 7;
            double divisor = singleShot ? 1 : .5;
            int weaponRange = ((Weapon) this.comboWeapon.SelectedItem).Range;
            int perception = ((Unit) this.comboAttackingUnit.SelectedItem).StatID.Perception;
            int luck = ((Unit) this.comboAttackingUnit.SelectedItem).StatID.Luck;
            int distance = int.Parse(textDistance.Text.Trim());
            int oac = ((Armour) this.comboArmour.SelectedItem).ArmourClass;
            int hitBonuses = 0;

            return (int) Math.Floor((skill / ((distance / multiplier) / divisor)) * multiplier + (Math.Pow(weaponRange, 2)) / (distance - (2 * weaponRange)) + (luck - 10) + hitBonuses);
        }

        private int longRangeShotChance()
        {
            // TODO Implement Hit Bonuses
            // Skill * e ^ (-(x - OptimalRange) ^ 2 / (2 * (Skill / 4) ^ 2))
            int skill = -1;
            switch (((Weapon) this.comboWeapon.SelectedItem).DamageType)
            {
                // Electrical (Energy Weapons)
                case (DamageTypes.EL):
                    skill = ((Unit) this.comboAttackingUnit.SelectedItem).StatID.EnergyWeapons;
                    break;

                // Explosive (Explosives)
                case (DamageTypes.EX):
                    skill = ((Unit) this.comboAttackingUnit.SelectedItem).StatID.Explosives;
                    break;

                // Normal (Small Guns) or Big?
                case (DamageTypes.N):
                    skill = ((Unit) this.comboAttackingUnit.SelectedItem).StatID.SmallGuns;
                    break;

                default:
                    return 0;
            }
            int weaponRange = ((Weapon) this.comboWeapon.SelectedItem).Range;
            int luck = ((Unit) this.comboAttackingUnit.SelectedItem).StatID.Luck;
            int distance = int.Parse(textDistance.Text.Trim());
            int hitBonuses = 0;
            // Skill*e^(-(x - OptimalRange)^2/(2 * (Skill / 4)^2))

            return (int) Math.Floor(skill * Math.Exp(-Math.Pow(distance - weaponRange, 2) / (2 * Math.Pow(skill / 4, 2))) + hitBonuses - (luck - 10));
        }

        private int[] attackDamage(int attacks)
        {
            this.logger.writeLog("Beginning Attack Damage Calculation");
            this.logger.writeLog(String.Format("Number of attacks: {0}", attacks));

            int flatDamage = ((Weapon) this.comboWeapon.SelectedItem).FlatDamage;
            bool melee = (((Weapon) this.comboWeapon.SelectedItem).WeaponType == WeaponSkillType.Melee || ((Weapon) this.comboWeapon.SelectedItem).WeaponType == WeaponSkillType.Unarmed);
            flatDamage = (melee ? flatDamage + ((Unit) this.comboAttackingUnit.SelectedItem).StatID.MeleeDamage : flatDamage);
            Dice BD = ((Weapon) this.comboWeapon.SelectedItem).BaseDamage;
            Dice AD = ((Weapon) this.comboWeapon.SelectedItem).AdditionalDamage;
            int ad, bd = -1;

            int[] damages = new int[attacks];
            for (int i = 0; i < attacks; i++)
            {
                bd = BD.getRoll();
                ad = AD.getRoll();
                damages[i] = bd + ad + flatDamage;
                this.logger.writeLog(String.Format("Base Damage: {0} Additional Damage: {1} Flat Damage: {2}", bd.ToString(), ad.ToString(), flatDamage.ToString()));
            }

            this.logger.writeLog("Ending Attack Calculation");
            return damages;
        }

        private void radioAttackerPlayerChecked(object sender, EventArgs e)
        {
            this.comboAttackerUnitLabel.Text = "Player Name";
            // Clear comboUnit and populate with Player Name List
            this.comboAttackerDifficultyLabel.Visible = false;
            this.comboAttackerDifficulty.Visible = false;
            this.checkAttackerDefaultEquipment.Visible = false;
        }

        private void radioAttackerEnemyChecked(object sender, EventArgs e)
        {
            this.comboAttackerUnitLabel.Text = "Unit Name";
            // Clear comboUnit and populate with Enemy Name List
            this.comboAttackerDifficultyLabel.Visible = true;
            this.comboAttackerDifficulty.Visible = true;
            this.checkAttackerDefaultEquipment.Visible = true;
        }

        private void radioDefenderPlayerChecked(object sender, EventArgs e)
        {
            this.comboDefenderUnitLabel.Text = "Player Name";
            // Clear comboUnit and populate with Player Name List
            this.comboDefenderDifficultyLabel.Visible = false;
            this.comboDefenderDifficulty.Visible = false;
            this.checkDefenderDefaultEquipment.Visible = false;
        }

        private void radioDefenderEnemyChecked(object sender, EventArgs e)
        {
            this.comboDefenderUnitLabel.Text = "Unit Name";
            // Clear comboUnit and populate with Enemy Name List
            this.comboDefenderDifficultyLabel.Visible = true;
            this.comboDefenderDifficulty.Visible = true;
            this.checkDefenderDefaultEquipment.Visible = true;
        }

        private void buttonSetHP_Click(object sender, EventArgs e)
        {
            this.logger.logBoth(String.Format("Setting Initial HP to {0}", this.textCurrentHealth.Text));
            this.textInitialHealth.Text = this.textCurrentHealth.Text;
        }

        private void comboAttackerUnitChanged(object sender, EventArgs e)
        {
            this.comboWeapon.SelectedItem = ((Unit) this.comboAttackingUnit.SelectedItem).WeaponID;
        }

        private void comboDefenderUnitChanged(object sender, EventArgs e)
        {
            this.comboArmour.SelectedItem = ((Unit) this.comboDefendingUnit.SelectedItem).ArmourID;
        }

        private BindingList<AttackTypes> cWCMelee = new BindingList<AttackTypes>() { AttackTypes.M };
        private BindingList<AttackTypes> cWCSR = new BindingList<AttackTypes>() { AttackTypes.SRS, AttackTypes.SRB };
        private BindingList<AttackTypes> cWCLR = new BindingList<AttackTypes>() { AttackTypes.LR };

        private void comboWeaponChanged(object sender, EventArgs e)
        {
            AttackRange classification = ((Weapon) this.comboWeapon.SelectedItem).Classification;
            
            switch (classification)
            {
                case (AttackRange.M):
                    this.comboAttackingMethod.DataSource = this.cWCMelee;
                    break;

                case (AttackRange.SR):
                    this.comboAttackingMethod.DataSource = this.cWCSR;
                    break;

                case (AttackRange.LR):
                    this.comboAttackingMethod.DataSource = this.cWCLR;
                    break;
            }
        }

        private void onLoad(object sender, EventArgs e)
        {
            getData();
        }
    }
}
