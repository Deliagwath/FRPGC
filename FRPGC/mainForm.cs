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

        private BindingList<Weapon>         weapons         = new BindingList<Weapon>();
        private BindingList<Armour>         armours         = new BindingList<Armour>();
        private BindingList<Unit>           attackerunits   = new BindingList<Unit>();
        private BindingList<Unit>           defenderunits   = new BindingList<Unit>();
        private BindingList<Stat>           stats           = new BindingList<Stat>();
        private BindingList<Player>         attackerplayers = new BindingList<Player>();
        private BindingList<Player>         defenderplayers = new BindingList<Player>();
        private BindingList<PlayerStat>     pstats          = new BindingList<PlayerStat>();

        private Dictionary<string, BindingList<Stat>> unitDifficultyAttacker = new Dictionary<string, BindingList<Stat>>();
        private Dictionary<string, BindingList<Stat>> unitDifficultyDefender = new Dictionary<string, BindingList<Stat>>();

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
                    foreach (Unit unit in this.attackerunits)
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

                case (ListTypes.PlayerStats):
                    foreach (PlayerStat stat in this.pstats)
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
            bool penetrating = false;

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
                        weaponRange = AttackRange.Melee;
                        break;
                    
                    case ("SR"):
                        weaponRange = AttackRange.ShortRange;
                        break;

                    case ("LR"):
                        weaponRange = AttackRange.LongRange;
                        break;

                    default:
                        this.logger.logBoth(String.Format("Classification could not be parsed. Expected M|SR|LR, got: {0}", splitted[6].Trim().ToUpper()));
                        continue;
                }

                // Parsing Damage Type
                switch (splitted[7].Trim().ToUpper())
                {
                    case ("N"):
                        damageType = DamageTypes.Normal;
                        break;

                    case ("LA"):
                        damageType = DamageTypes.Laser;
                        break;
                    
                    case ("PL"):
                        damageType = DamageTypes.Plasma;
                        break;
                    
                    case ("EL"):
                        damageType = DamageTypes.Electrical;
                        break;

                    case ("FR"):
                        damageType = DamageTypes.Fire;
                        break;

                    case ("EX"):
                        damageType = DamageTypes.Explosion;
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

                // Penetrating (P, N)
                try
                {
                    penetrating = (splitted[9].Trim().ToUpper().Equals("P")) ? true : false;
                }
                catch
                {
                    this.logger.logBoth(String.Format("Penetration could not be parsed. Expected P|N, received :{0}", splitted[9]));
                    continue;
                }
                // Creating Weapon Object and adding to List
                this.weapons.Add(new Weapon(name, id, singleRange, constant, baseDamage, additionalDamage, shotPerBurst, weaponRange, damageType, weaponType, penetrating));
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
                splitted = line.Trim().Split(',');

                name = splitted[0].Trim();
                this.logger.logBoth(String.Format("Parsing {0}", name));
                id = splitted[1].Trim();

                // Creating Armour Object and adding to List
                this.armours.Add(new Armour(name, id,
                    int.Parse(splitted[2].Trim()),       // AC
                    int.Parse(splitted[3].Trim()),       // DT N
                    int.Parse(splitted[4].Trim()),       // DR N
                    int.Parse(splitted[5].Trim()),       // DT L
                    int.Parse(splitted[6].Trim()),       // DR L
                    int.Parse(splitted[7].Trim()),       // DT P
                    int.Parse(splitted[8].Trim()),       // DR P
                    int.Parse(splitted[9].Trim()),       // DT E
                    int.Parse(splitted[10].Trim()),      // DR E
                    int.Parse(splitted[11].Trim()),      // DT F
                    int.Parse(splitted[12].Trim()),      // DR F
                    int.Parse(splitted[13].Trim()),      // DT EX
                    int.Parse(splitted[14].Trim())));    // DR EX
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
            string line, id, currentid = "";
            string[] splitted = null;
            Difficulty diff;
            Stat stat;

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
                stat = new Stat(id, int.Parse(splitted[1]), int.Parse(splitted[2]), int.Parse(splitted[3]), int.Parse(splitted[4]), int.Parse(splitted[5]), int.Parse(splitted[6]),
                    int.Parse(splitted[7]), int.Parse(splitted[8]), int.Parse(splitted[9]), int.Parse(splitted[10]), int.Parse(splitted[11]), int.Parse(splitted[12]), diff);
                this.stats.Add(stat);

                if (!currentid.Equals(id))
                {
                    this.unitDifficultyAttacker.Add(id, new BindingList<Stat>() { stat });
                    this.unitDifficultyDefender.Add(id, new BindingList<Stat>() { stat });
                    currentid = id;
                }
                else
                {
                    this.unitDifficultyAttacker[id].Add(stat);
                    this.unitDifficultyDefender[id].Add(stat);
                }
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
                this.attackerunits.Add(new Unit(name, splitted[1], (Weapon) searchListByID(splitted[2], ListTypes.Weapons), (Armour) searchListByID(splitted[3], ListTypes.Armours), (Stat) searchListByID(splitted[4], ListTypes.Stats)));
            }

            // Populate the two drop down combo boxes
            this.comboAttackingUnit.DataSource = this.attackerunits;
            this.comboAttackingUnit.ValueMember = "ID";
            this.comboAttackingUnit.DisplayMember = "Name";

            this.defenderunits = new BindingList<Unit>(this.attackerunits);
            this.comboDefendingUnit.DataSource = this.defenderunits;
            this.comboDefendingUnit.ValueMember = "ID";
            this.comboDefendingUnit.DisplayMember = "Name";
        }

        public void dumpUnits(object sender, EventArgs e)
        {
            this.logger.logBoth("Dumping");
            foreach (Unit u in this.attackerunits)
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
                this.attackerplayers.Add(new Player(name, splitted[1], (Weapon)searchListByID(splitted[2], ListTypes.Weapons), (Armour)searchListByID(splitted[3], ListTypes.Armours), (PlayerStat)searchListByID(splitted[4], ListTypes.PlayerStats)));
            }

            // Populate the two drop down combo boxes
            this.comboAttackingUnit.DataSource = this.attackerplayers;
            this.comboAttackingUnit.ValueMember = "ID";
            this.comboAttackingUnit.DisplayMember = "Name";

            this.defenderplayers = new BindingList<Player>(this.attackerplayers);
            this.comboDefendingUnit.DataSource = this.defenderplayers;
            this.comboDefendingUnit.ValueMember = "ID";
            this.comboDefendingUnit.DisplayMember = "Name";
        }

        public void dumpPlayers(object sender, EventArgs e)
        {
            this.logger.logBoth("Dumping");
            foreach (Player p in this.attackerplayers)
            {
                this.logger.logBoth(p.ToString());
            }
        }

        private void calculate(object sender, EventArgs e)
        {
            int parseTest = 0;
            if (this.textAttacksLaunched.Text == "" || !int.TryParse(this.textAttacksLaunched.Text, out parseTest))
            {
                this.textAttacksLaunched.Text = "!!!";
                this.logger.logBoth("Incorrect Format for Number of Attacks Launched.");
                return;
            }
            if (this.textDistance.Text == "" || !int.TryParse(this.textDistance.Text, out parseTest))
            {
                this.textDistance.Text = "!!!";
                this.logger.logBoth("Incorrect Format for Distance.");
                return;
            }
            
            switch (this.comboAttackingMethod.SelectedIndex)
            {
                case (-1): // ComboBox not touched
                    MessageBox.Show("It'd be nice if you chose a Firing Mode.");
                    break;

                case (0): // Single Shot
                    if (((Weapon) this.comboWeapon.SelectedItem).Classification == AttackRange.LongRange)
                    {
                        textCurrentHealth.Text = (int.Parse(textInitialHealth.Text) - attack(int.Parse(textAttacksLaunched.Text), AttackTypes.LongRange)).ToString();
                    }
                    else
                    {
                        textCurrentHealth.Text = (int.Parse(textInitialHealth.Text) - attack(int.Parse(textAttacksLaunched.Text), AttackTypes.ShortRangeSingle)).ToString();
                    }
                    break;

                case (1): // Burst Shot
                    textCurrentHealth.Text = (int.Parse(textInitialHealth.Text) - attack(int.Parse(textAttacksLaunched.Text), AttackTypes.ShortRangeBurst)).ToString();
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
            int bonusHit = 0;
            bool parseAttempt = int.TryParse(this.bonusHitChance.Text, out bonusHit);
            if (!parseAttempt)
            {
                this.logger.logBoth(String.Format("Bonus Hit Chance could not be parsed. Input: {0}, setting to 0", this.bonusHitChance.Text));
                this.bonusHitChance.Text = "0";
                bonusHit = 0;
            }
            switch (attackType)
            {
                case (AttackTypes.Melee):
                    chance = meleeHitChance();
                    break;

                case (AttackTypes.ShortRangeSingle):
                    chance = shortRangeShotChance(true);
                    break;

                case (AttackTypes.ShortRangeBurst):
                    chance = shortRangeShotChance(false);
                    break;

                case (AttackTypes.LongRange):
                    chance = longRangeShotChance();
                    break;

                default:
                    this.logger.logBoth(String.Format("A weird error occured at the attack() function. The attackType is: {0}", attackType.ToString()));
                    return 0;
            }

            this.logger.logBoth(String.Format("Hit Chance: {0}, Bonus Hit Chance: {1}", chance.ToString(), bonusHit.ToString()));
            chance += bonusHit;
            attacksLaunched *= ((AttackTypes) this.comboAttackingMethod.SelectedItem).Equals(AttackTypes.ShortRangeBurst) ? ((Weapon) this.comboWeapon.SelectedItem).ShotsPerBurst : 1;
            int[] damages = attackDamage(attacksLaunched);
            int totalDamage = 0;
            Dice dice = new Dice(1, Math.Max(100, chance), this.logger);
            dynamic attacker = (dynamic) this.comboAttackingUnit.SelectedItem;
            int rolled = -1;

            foreach (int damage in damages)
            {
                rolled = dice.getRoll();

                if (rolled < attacker.StatID.CriticalChance) // Critical Hit
                {
                    this.logger.logBoth(String.Format("Critical Hit: {0} < {1}", rolled.ToString(), attacker.StatID.CriticalChance));
                    this.logger.logBoth(String.Format("Damage Taken: {0}", (damageReduction(damage) * 2).ToString()));
                    totalDamage += damageReduction(damage) * 2;
                    continue;
                }
                if (rolled > Math.Max(100, chance) - (10 - attacker.StatID.Luck)) // Critical Failure
                {
                    this.logger.logBoth(String.Format("Critical Failure: {0} > {1}", rolled.ToString(), (Math.Max(100, chance) - (10 - attacker.StatID.Luck)).ToString()));
                    this.logger.logBoth("Ending Calculations.");
                    return totalDamage;
                }
                if (rolled <= chance) // Hit
                {
                    this.logger.logBoth(String.Format("Hit: {0} < {1}", rolled.ToString(), chance.ToString()));
                    this.logger.logBoth(String.Format("Damage Taken: {0}", damageReduction(damage).ToString()));
                    totalDamage += damageReduction(damage);
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
            this.textDamageDealt.Text = totalDamage.ToString();
            return totalDamage;
        }

        private int damageReduction(int damage)
        {
            DamageTypes dt = ((Weapon) this.comboWeapon.SelectedItem).DamageType;
            Armour ar = (Armour) this.comboArmour.SelectedItem;

            switch (dt)
            {
                case (DamageTypes.Normal):
                    damage -= ((Weapon) this.comboWeapon.SelectedItem).Penetrating ? (int) Math.Floor(ar.DTNormal / 2.0) : ar.DTNormal;
                    damage = ((Weapon) this.comboWeapon.SelectedItem).Penetrating ? (int) Math.Max(damage, Math.Floor(damage * ((100 - ar.DRNormal) / 100.0))) : (int) Math.Floor(damage * ((100 - ar.DRNormal) / 100.0));
                    return Math.Max(0, damage);

                case (DamageTypes.Laser):
                    damage -= ((Weapon)this.comboWeapon.SelectedItem).Penetrating ? (int) Math.Floor(ar.DTLaser / 2.0) : ar.DTLaser;
                    damage = ((Weapon)this.comboWeapon.SelectedItem).Penetrating ? (int) Math.Max(damage, Math.Floor(damage * ((100 - ar.DRLaser) / 100.0))) : (int)Math.Floor(damage * ((100 - ar.DRLaser) / 100.0));
                    return Math.Max(0, damage);

                case (DamageTypes.Plasma):
                    damage -= ((Weapon)this.comboWeapon.SelectedItem).Penetrating ? (int) Math.Floor(ar.DTPlasma / 2.0) : ar.DTPlasma;
                    damage = ((Weapon)this.comboWeapon.SelectedItem).Penetrating ? (int) Math.Max(damage, Math.Floor(damage * ((100 - ar.DRPlasma) / 100.0))) : (int)Math.Floor(damage * ((100 - ar.DRPlasma) / 100.0));
                    return Math.Max(0, damage);

                case (DamageTypes.Electrical):
                    damage -= ((Weapon)this.comboWeapon.SelectedItem).Penetrating ? (int) Math.Floor(ar.DTElectrical / 2.0) : ar.DTElectrical;
                    damage = ((Weapon)this.comboWeapon.SelectedItem).Penetrating ? (int) Math.Max(damage, Math.Floor(damage * ((100 - ar.DRElectrical) / 100.0))) : (int)Math.Floor(damage * ((100 - ar.DRElectrical) / 100.0));
                    return Math.Max(0, damage);

                case (DamageTypes.Fire):
                    damage -= ((Weapon)this.comboWeapon.SelectedItem).Penetrating ? (int) Math.Floor(ar.DTFire / 2.0) : ar.DTFire;
                    damage = ((Weapon)this.comboWeapon.SelectedItem).Penetrating ? (int) Math.Max(damage, Math.Floor(damage * ((100 - ar.DRFire) / 100.0))) : (int)Math.Floor(damage * ((100 - ar.DRFire) / 100.0));
                    return Math.Max(0, damage);

                case (DamageTypes.Explosion):
                    damage -= ((Weapon)this.comboWeapon.SelectedItem).Penetrating ? (int) Math.Floor(ar.DTExplosive / 2.0) : ar.DTExplosive;
                    damage = ((Weapon)this.comboWeapon.SelectedItem).Penetrating ? (int) Math.Max(damage, Math.Floor(damage * ((100 - ar.DRExplosive) / 100.0))) : (int)Math.Floor(damage * ((100 - ar.DRExplosive) / 100.0));
                    return Math.Max(0, damage);

                default:
                    logger.logBoth(String.Format("Damage Reduction Failed, Incorrect DamageType: {0}", dt.ToString()));
                    return -1;
            }
        }

        private int meleeHitChance()
        {
            return Math.Max(((dynamic) this.comboAttackingUnit.SelectedItem).StatID.Melee - ((dynamic) this.comboDefendingUnit.SelectedItem).StatID.AC, 0);
        }

        private int shortRangeShotChance(bool singleShot)
        {
            // TODO Implement Hit Bonuses
            // =(Skill / (Range / Multiplier / Divisor |If singleShot != true|)) * Multiplier + (Optimal Range ^ 2) / (Range - (2 * Optimal Range)) + (Luck - 10)
            int skill = -1;
            if (this.textDistance.Text == "") { return 0; }
            if (this.textDistance.Text == "1") { return 1000; }
            try { double.Parse(this.textDistance.Text); }
            catch (Exception) { return 0; }
            if (((Weapon) this.comboWeapon.SelectedItem).Range * 2 < double.Parse(this.textDistance.Text)) { return 0; }
            switch (((Weapon) this.comboWeapon.SelectedItem).WeaponType)
            {
                case (WeaponSkillType.EnergyWeapons):
                    skill = ((dynamic) this.comboAttackingUnit.SelectedItem).StatID.EnergyWeapons;
                    break;

                case (WeaponSkillType.Explosives):
                    skill = ((dynamic) this.comboAttackingUnit.SelectedItem).StatID.Explosives;
                    break;

                case (WeaponSkillType.SmallGuns):
                    skill = ((dynamic) this.comboAttackingUnit.SelectedItem).StatID.SmallGuns;
                    break;

                case (WeaponSkillType.Melee):
                    skill = ((dynamic) this.comboAttackingUnit.SelectedItem).StatID.Melee;
                    break;

                case (WeaponSkillType.Unarmed):
                    skill = ((dynamic) this.comboAttackingUnit.SelectedItem).StatID.Unarmed;
                    break;

                case (WeaponSkillType.BigGuns):
                    skill = ((dynamic) this.comboAttackingUnit.SelectedItem).StatID.BigGuns;
                    break;

                default:
                    return 0;
            }
            int multiplier = 7;
            double divisor = singleShot ? 1 : .5;
            int weaponRange = ((Weapon) this.comboWeapon.SelectedItem).Range;
            int perception = ((dynamic) this.comboAttackingUnit.SelectedItem).StatID.Perception;
            int luck = ((dynamic) this.comboAttackingUnit.SelectedItem).StatID.Luck;
            int distance = int.Parse(textDistance.Text.Trim());
            int oac = ((Armour) this.comboArmour.SelectedItem).ArmourClass;
            int hitBonuses = 0;
            int chance = (int) Math.Max(Math.Floor((skill / ((distance / multiplier) / divisor)) * multiplier + (Math.Pow(weaponRange, 2)) / (distance - (2 * weaponRange)) + (luck - 10) + hitBonuses), 0);
            if (chance == -2147483648) { return 1000; }
            return chance;
        }

        private int longRangeShotChance()
        {
            // TODO Implement Hit Bonuses
            // Skill * e ^ (-(x - OptimalRange) ^ 2 / (2 * (Skill / 4) ^ 2))
            int skill = -1;
            if (this.textDistance.Text == "") { return 0; }
            try { double.Parse(this.textDistance.Text); }
            catch (Exception) { return 0; }
            switch (((Weapon) this.comboWeapon.SelectedItem).WeaponType)
            {
                case (WeaponSkillType.EnergyWeapons):
                    skill = ((dynamic)this.comboAttackingUnit.SelectedItem).StatID.EnergyWeapons;
                    break;

                case (WeaponSkillType.Explosives):
                    skill = ((dynamic)this.comboAttackingUnit.SelectedItem).StatID.Explosives;
                    break;

                case (WeaponSkillType.SmallGuns):
                    skill = ((dynamic)this.comboAttackingUnit.SelectedItem).StatID.SmallGuns;
                    break;

                case (WeaponSkillType.Melee):
                    skill = ((dynamic)this.comboAttackingUnit.SelectedItem).StatID.Melee;
                    break;

                case (WeaponSkillType.Unarmed):
                    skill = ((dynamic)this.comboAttackingUnit.SelectedItem).StatID.Unarmed;
                    break;

                case (WeaponSkillType.BigGuns):
                    skill = ((dynamic)this.comboAttackingUnit.SelectedItem).StatID.BigGuns;
                    break;

                default:
                    return 0;
            }
            int weaponRange = ((Weapon) this.comboWeapon.SelectedItem).Range;
            int luck = ((dynamic) this.comboAttackingUnit.SelectedItem).StatID.Luck;
            if (this.textDistance.Text.Trim() == "") { return 0; }
            int distance = int.Parse(textDistance.Text.Trim());
            int hitBonuses = 0;
            // Skill*e^(-(x - OptimalRange)^2/(2 * (Skill / 4)^2))

            return (int) Math.Max(Math.Floor(skill * Math.Exp(-Math.Pow(distance - weaponRange, 2) / (2 * Math.Pow(skill / 4, 2))) + hitBonuses - (luck - 10)), 0);
        }

        private int[] attackDamage(int attacks)
        {
            this.logger.writeLog("Beginning Attack Damage Calculation");
            this.logger.writeLog(String.Format("Number of attacks: {0}", attacks));

            int flatDamage = ((Weapon) this.comboWeapon.SelectedItem).FlatDamage;
            bool melee = (((Weapon) this.comboWeapon.SelectedItem).WeaponType == WeaponSkillType.Melee || ((Weapon) this.comboWeapon.SelectedItem).WeaponType == WeaponSkillType.Unarmed);
            flatDamage = (melee ? flatDamage + ((dynamic) this.comboAttackingUnit.SelectedItem).StatID.MeleeDamage : flatDamage);
            Dice BD = ((Weapon) this.comboWeapon.SelectedItem).BaseDamage;
            Dice AD = ((Weapon) this.comboWeapon.SelectedItem).AdditionalDamage;
            int ad, bd = -1;

            int[] damages = new int[attacks];
            for (int i = 0; i < attacks; i++)
            {
                bd = BD.getRoll();
                ad = AD.getRoll();
                // Burst Attack Modes (Excluding Shotguns) only do Additional Damage.
                damages[i] = (((AttackTypes) this.comboAttackingMethod.SelectedItem == AttackTypes.ShortRangeBurst) && !((Weapon) this.comboWeapon.SelectedItem).ID.Substring(0, 3).Equals("SGS")) ? ad : bd + ad + flatDamage;
                this.logger.writeLog(String.Format("Base Damage: {0} Additional Damage: {1} Flat Damage: {2}", bd.ToString(), ad.ToString(), flatDamage.ToString()));
            }

            this.logger.writeLog("Ending Attack Calculation");
            return damages;
        }

        private void radioAttackerPlayerChecked(object sender, EventArgs e)
        {
            this.comboAttackerUnitLabel.Text = "Player Name";

            // Limit Visibility of NPC related functions
            this.comboAttackerDifficultyLabel.Visible = false;
            this.comboAttackerDifficulty.Visible = false;
            this.checkAttackerDefaultEquipment.Visible = false;

            // Clear comboUnit and populate with Player Name List
            this.comboAttackingUnit.DataSource = this.attackerplayers;
            this.comboAttackingUnit.ValueMember = "ID";
            this.comboAttackingUnit.DisplayMember = "Name";
        }

        private void radioAttackerEnemyChecked(object sender, EventArgs e)
        {
            this.comboAttackerUnitLabel.Text = "Unit Name";

            // Increase Visibility of NPC related functions
            this.comboAttackerDifficultyLabel.Visible = true;
            this.comboAttackerDifficulty.Visible = true;
            this.checkAttackerDefaultEquipment.Visible = true;

            // Clear comboUnit and populate with Player Name List
            this.comboAttackingUnit.DataSource = this.attackerunits;
            this.comboAttackingUnit.ValueMember = "ID";
            this.comboAttackingUnit.DisplayMember = "Name";
        }

        private void radioDefenderPlayerChecked(object sender, EventArgs e)
        {
            this.comboDefenderUnitLabel.Text = "Player Name";

            // Limit Visibility of NPC related functions
            this.comboDefenderDifficultyLabel.Visible = false;
            this.comboDefenderDifficulty.Visible = false;
            this.checkDefenderDefaultEquipment.Visible = false;

            // Clear comboUnit and populate with Player Name List
            this.comboDefendingUnit.DataSource = this.defenderplayers;
            this.comboDefendingUnit.ValueMember = "ID";
            this.comboDefendingUnit.DisplayMember = "Name";
        }

        private void radioDefenderEnemyChecked(object sender, EventArgs e)
        {
            this.comboDefenderUnitLabel.Text = "Unit Name";

            // Increase Visibility of NPC related functions
            this.comboDefenderDifficultyLabel.Visible = true;
            this.comboDefenderDifficulty.Visible = true;
            this.checkDefenderDefaultEquipment.Visible = true;

            // Clear comboUnit and populate with Player Name List
            this.comboDefendingUnit.DataSource = this.defenderunits;
            this.comboDefendingUnit.ValueMember = "ID";
            this.comboDefendingUnit.DisplayMember = "Name";
        }

        private void buttonSetHP_Click(object sender, EventArgs e)
        {
            this.logger.logBoth(String.Format("Setting Initial HP to {0}", this.textCurrentHealth.Text));
            this.textInitialHealth.Text = this.textCurrentHealth.Text;
        }

        private void comboAttackerUnitChanged(object sender, EventArgs e)
        {
            dynamic newAttacker = (dynamic) this.comboAttackingUnit.SelectedItem;
            this.comboWeapon.SelectedItem = newAttacker.WeaponID;
            this.textSkill.Clear();
            this.textSkill.Text = String.Join(Environment.NewLine, newAttacker.StatID.ToStringArray());
            if (this.radioAttackerEnemy.Checked)
            {
                this.comboAttackerDifficulty.DataSource = this.unitDifficultyAttacker[newAttacker.StatID.ID];
                this.comboAttackerDifficulty.DisplayMember = "Diff";
            }
        }

        private void comboDefenderUnitChanged(object sender, EventArgs e)
        {
            dynamic newDefender = (dynamic) this.comboDefendingUnit.SelectedItem;
            this.comboArmour.SelectedItem = newDefender.ArmourID;
            this.textInitialHealth.Text = newDefender.StatID.HP.ToString();
            //this.textSkill.Clear();
            //this.textSkill.Text = String.Join(Environment.NewLine, newDefender.StatID.ToStringArray());
            if (this.radioDefenderEnemy.Checked)
            {
                this.comboDefenderDifficulty.DataSource = this.unitDifficultyDefender[newDefender.StatID.ID];
                this.comboDefenderDifficulty.DisplayMember = "Diff";
            }
        }

        private BindingList<AttackTypes> cWCMelee = new BindingList<AttackTypes>() { AttackTypes.Melee };
        private BindingList<AttackTypes> cWCSR = new BindingList<AttackTypes>() { AttackTypes.ShortRangeSingle, AttackTypes.ShortRangeBurst };
        private BindingList<AttackTypes> cWCLR = new BindingList<AttackTypes>() { AttackTypes.LongRange };

        private void comboWeaponChanged(object sender, EventArgs e)
        {
            if (this.comboWeapon.SelectedItem == null) { return; }
            AttackRange classification = ((Weapon) this.comboWeapon.SelectedItem).Classification;
            
            switch (classification)
            {
                case (AttackRange.Melee):
                    this.comboAttackingMethod.DataSource = this.cWCMelee;
                    break;

                case (AttackRange.ShortRange):
                    this.comboAttackingMethod.DataSource = this.cWCSR;
                    break;

                case (AttackRange.LongRange):
                    this.comboAttackingMethod.DataSource = this.cWCLR;
                    break;
            }
        }

        private void onLoad(object sender, EventArgs e)
        {
            getData();
        }

        private void hitChanceChange(object sender, EventArgs e)
        {
            int distance = 100000;
            double chance = 0;
            int bonusHit = 0;
            int.TryParse(this.bonusHitChance.Text, out bonusHit);
            if (this.textDistance.Text == "N/A") { return; }
            try
            {
                distance = int.Parse(this.textDistance.Text);
            }
            catch (Exception)
            {
                this.hitChance.Text = "N/A";
            }
            finally
            {
                switch ((AttackTypes) Enum.Parse(typeof(AttackTypes), this.comboAttackingMethod.Text, true))
                {
                    case (AttackTypes.Melee):
                        chance = meleeHitChance();
                        break;

                    case (AttackTypes.ShortRangeSingle):
                        chance = shortRangeShotChance(true);
                        break;

                    case (AttackTypes.ShortRangeBurst):
                        chance = shortRangeShotChance(false);
                        break;

                    case (AttackTypes.LongRange):
                        chance = longRangeShotChance();
                        break;
                }
                chance += bonusHit;
                this.hitChance.Text = chance.ToString();
            }
        }

        private void clearLog(object sender, EventArgs e)
        {
            this.textLog.Clear();
        }

        private void comboAttackerDifficultyChanged(object sender, EventArgs e)
        {
            Stat newDifficulty = (Stat) this.comboAttackerDifficulty.SelectedItem;
            ((Unit) this.comboAttackingUnit.SelectedItem).StatID = newDifficulty;
            this.textSkill.Clear();
            this.textSkill.Text = String.Join(Environment.NewLine, newDifficulty.ToStringArray());
            hitChanceChange(this, new EventArgs());
        }

        private void comboDefenderDifficultyChanged(object sender, EventArgs e)
        {
            Stat newDifficulty = (Stat) this.comboDefenderDifficulty.SelectedItem;
            ((Unit) this.comboDefendingUnit.SelectedItem).StatID = newDifficulty;
            //this.textSkill.Clear();
            //this.textSkill.Text = String.Join(Environment.NewLine, newDifficulty.ToStringArray());
        }
    }
}
