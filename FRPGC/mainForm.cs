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
        private string[] files = new string[]
        {
            "Weapons.csv",
            "Armour.csv"
            //"PlayerEquip.csv",
            //"PlayerStats.csv",
            //"EnemyEquip.csv",
            //"EnemyStats.csv"
        };

        
        private BindingList<Weapon> weapons = new BindingList<Weapon>();
        private BindingList<Armour> armours = new BindingList<Armour>();
        //private Dictionary<string, string> playerEquip = new Dictionary<string, string>();
        //private Dictionary<string, string> playerStats = new Dictionary<string, string>();
        //private Dictionary<string, string> enemyEquip = new Dictionary<string, string>();
        //private Dictionary<string, string> enemyStats = new Dictionary<string, string>();

        public mainForm()
        {
            InitializeComponent();
            getData();
        }

        public void getData()
        {
            writeLog(log, "Fetching Data");

            // Initialise null Containers
            StreamReader reader = null;

            // Initialise Check Array and Counter
            bool[] check = new bool[this.files.Length];
            int counter = 0;

            foreach (string filename in this.files)
            {
                writeLog(log, "Reading from " + filename);
                try
                {
                    // Reading from File
                    reader = new StreamReader(filename);

                    switch (filename)
                    {
                        case ("Weapons.csv"):
                        getWeapons(reader);
                        break;

                        case ("Armour.csv"):
                        getArmours(reader);
                        break;
                    }
                }
                
                // Catches and Finally to Log and close StreamReader
                catch (Exception e)
                {
                    writeLog(log, "Exception Occurred: " + e.ToString());
                    writeLog(log, "Ignoring " + filename);
                    try { reader.Close(); } catch { }
                    check[counter] = false;
                }
                finally
                {
                    writeLog(log, "Read Finished from " + filename);
                    try { reader.Close(); } catch { }
                    check[counter] = true;
                }
                counter++;
            }

            writeLog(log, "Data Retrieval Completed.");
            return;
        }

        public void getWeapons(StreamReader reader)
        {
            string line, name, id = null;
            int singleRange, c, m, r, spb = 0;
            Dice bd, ad = null;
            WeaponRange wr;
            DamageTypes dt;
            WeaponType wt;
            string[] splitted, constantSplit, diceSplit = null;

            while ((line = reader.ReadLine()) != null)
            {
                // Weapons {"Name":0, "ID":1, "Range":2, "BD":3, "AD":4, "SPB"(Shots per burst):5, "DamageType":6}
                splitted = line.Trim().Split(',');
                name = splitted[0].Trim();
                logBoth(log, "Parsing " + name);
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
                        logBoth(log, "Range could not be parsed. Expected int, got: " + splitted[2].Trim());
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
                        c = int.Parse(constantSplit[1].Trim());
                        m = int.Parse(diceSplit[0].Trim());
                        r = int.Parse(diceSplit[1].Trim());
                    }
                    else
                    {
                        diceSplit = constantSplit[1].Trim().ToLower().Split('d');
                        c = int.Parse(constantSplit[0].Trim());
                        m = int.Parse(diceSplit[0].Trim());
                        r = int.Parse(diceSplit[1].Trim());
                    }
                    bd = new Dice(m, r, this.logBoth, this.log);
                }
                catch
                {
                    try
                    {
                        // Parsing XdY Format
                        diceSplit = splitted[3].Trim().ToLower().Split('d');
                        c = 0;
                        m = int.Parse(diceSplit[0].Trim());
                        r = int.Parse(diceSplit[1].Trim());
                        bd = new Dice(m, r, this.logBoth, this.log);
                    }
                    catch
                    {
                        try
                        {
                            // Parsing X Format
                            c = 0;
                            m = int.Parse(splitted[3]);
                            bd = new Dice(m, 1, this.logBoth, this.log);
                        }
                        catch
                        {
                            logBoth(log, "Base Damage could not be parsed. Expected X+YdZ or XdY or X, got: " + splitted[3].Trim());
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
                        c = int.Parse(constantSplit[1].Trim());
                        m = int.Parse(diceSplit[0].Trim());
                        r = int.Parse(diceSplit[1].Trim());
                    }
                    else {
                        diceSplit = constantSplit[1].Trim().ToLower().Split('d');
                        c = int.Parse(constantSplit[0].Trim());
                        m = int.Parse(diceSplit[0].Trim());
                        r = int.Parse(diceSplit[1].Trim());
                    }
                    bd = new Dice(m, r, this.logBoth, this.log);
                }
                catch
                {
                    try
                    {
                        // Parsing XdY Format
                        diceSplit = splitted[4].Trim().ToLower().Split('d');
                        c = 0;
                        m = int.Parse(diceSplit[0].Trim());
                        r = int.Parse(diceSplit[1].Trim());
                        ad = new Dice(m, r, this.logBoth, this.log);
                    }
                    catch
                    {
                        try
                        {
                            // Parsing X Format
                            c = 0;
                            m = int.Parse(splitted[4]);
                            ad = new Dice(m, 1, this.logBoth, this.log);
                        }
                        catch
                        {
                            logBoth(log, "Additional Damage could not be parsed. Expected X+YdZ or XdY or X, got: " + splitted[4].Trim());
                            continue;
                        }
                    }
                }

                try
                {
                    if (splitted[5].Trim().ToUpper().Equals("NA")) { spb = 1; }
                    else { spb = int.Parse(splitted[5].Trim()); }
                }
                catch
                {
                    logBoth(log, "Shot Per Burst could not be parsed. Expected int, got: " + splitted[5].Trim());
                    continue;
                }

                // Parsing Classification
                switch (splitted[6].Trim().ToUpper())
                {
                    case ("M"):
                        wr = WeaponRange.M;
                        break;
                    
                    case ("SR"):
                        wr = WeaponRange.SR;
                        break;

                    case ("LR"):
                        wr = WeaponRange.LR;
                        break;

                    default:
                        logBoth(log, "Classification could not be parsed. Expected M|SR|LR, got: " + splitted[6].Trim().ToUpper());
                        continue;
                }

                // Parsing Damage Type
                switch (splitted[7].Trim().ToUpper())
                {
                    case ("N"):
                        dt = DamageTypes.N;
                        break;

                    case ("LA"):
                        dt = DamageTypes.LA;
                        break;
                    
                    case ("PL"):
                        dt = DamageTypes.PL;
                        break;
                    
                    case ("EL"):
                        dt = DamageTypes.EL;
                        break;

                    case ("FR"):
                        dt = DamageTypes.FR;
                        break;

                    case ("EX"):
                        dt = DamageTypes.EX;
                        break;
                    
                    default:
                        logBoth(log, "DamageType could not be parsed. Expected N|LA|PL|EL|FR|EX, got: " + splitted[7].Trim().ToUpper());
                        continue;
                }

                // Parsing Weapon Type (Which Skill it is dependant upon)
                switch (splitted[8].Trim().ToUpper())
                {
                    case ("BIGGUNS"):
                    case ("BG"):
                        wt = WeaponType.BigGuns;
                        break;

                    case ("ENERGYWEAPONS"):
                    case ("EW"):
                        wt = WeaponType.EnergyWeapons;
                        break;

                    case ("EXPLOSIVES"):
                    case ("E"):
                        wt = WeaponType.Explosives;
                        break;

                    case ("SMALLGUNS"):
                    case ("SG"):
                        wt = WeaponType.SmallGuns;
                        break;

                    case ("UNARMED"):
                    case ("U"):
                        wt = WeaponType.Unarmed;
                        break;

                    default:
                        logBoth(log, "WeaponType could not be parsed. Expected BigGuns|BG|EnergyWeapons|EW|Explosives|E|SmallGuns|SG|Unarmed|U, got: " + splitted[8].Trim().ToUpper());
                        continue;
                }

                // Creating Weapon Object and adding to List
                this.weapons.Add(new Weapon(name, id, singleRange, c, bd, ad, spb, wr, dt, wt));
            }

            // Binding to ComboBox
            this.comboWeapon.DataSource = this.weapons;
            this.comboWeapon.ValueMember = "ID";
            this.comboWeapon.DisplayMember = "Name";
        }

        public void dumpWeapons(object sender, EventArgs e)
        {
            logBoth(log, "Dumping");
            foreach (Weapon w in this.weapons)
            {
                logBoth(log, w.toString());
            }
        }

        public void getArmours(StreamReader reader)
        {
            string line, name, id = null;
            string[] splitted = null;

            while ((line = reader.ReadLine()) != null)
            {
                // Weapons {"Name":0, "ID":1, "Range":2, "BD":3, "AD":4, "SPB"(Shots per burst):5, "DamageType":6}
                splitted = line.Trim().Split(',');

                name = splitted[0].Trim();
                logBoth(log, "Parsing " + name);
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
            logBoth(log, "Dumping");
            foreach (Armour a in this.armours)
            {
                logBoth(log, a.toString());
            }
        }

        public void writeLog(string filename, string message)
        {
            // Initialising Writer
            StreamWriter writer;
            if (System.IO.File.Exists(filename)) { writer = new StreamWriter(filename, true); }
            else { writer = new StreamWriter(filename); }

            // Generating Timestamp for Log
            string timestamp = string.Format("[{0:HH:mm:ss}]: ", DateTime.Now);

            // Writing to Log
            writer.Write(timestamp + message + "\n");
            writer.Close();
            return;
        }

        public void updateLog(string message)
        {
            string timestamp = string.Format("[{0:HH:mm:ss}]: ", DateTime.Now);
            this.textLog.AppendText(timestamp + message + "\n");
            return;
        }

        public void logBoth(string filename, string message)
        {
            writeLog(filename, message);
            updateLog(message);
        }

        private void calculate(object sender, EventArgs e)
        {
            switch (this.comboFireType.SelectedIndex)
            {
                case (-1): // ComboBox not touched
                    MessageBox.Show("It'd be nice if you chose a Firing Mode.");
                    break;

                case (0): // Single Shot
                    if (((Weapon)this.comboWeapon.SelectedItem).Classification == WeaponRange.LR)
                    {
                        textCurrentHealth.Text = (int.Parse(textInitialHealth.Text) - shoot(int.Parse(textShotCount.Text), ShotTypes.LR)).ToString();
                    }
                    else
                    {
                        textCurrentHealth.Text = (int.Parse(textInitialHealth.Text) - shoot(int.Parse(textShotCount.Text), ShotTypes.SRS)).ToString();
                    }
                    break;

                case (1): // Burst Shot
                    textCurrentHealth.Text = (int.Parse(textInitialHealth.Text) - shoot(int.Parse(textShotCount.Text), ShotTypes.SRB)).ToString();
                    break;

                case (2): // Melee
                    break;

                default:
                    writeLog(log, "ComboBox Firing Type Error, Index: " + this.comboFireType.SelectedIndex);
                    MessageBox.Show("Fire Type Drop Down List says wut: " + this.comboFireType.SelectedIndex);
                    break;
            }
        }

        private int shoot(int shotsFired, ShotTypes shotType)
        {
            int chance = -1;

            switch (shotType)
            {
                case (ShotTypes.SRS):
                    chance = shortRangeShotChance(true);
                    break;

                case (ShotTypes.SRB):
                    chance = shortRangeShotChance(false);
                    break;

                case (ShotTypes.LR):
                    chance = longRangeShotChance();
                    break;

                default:
                    logBoth(log, "A weird error occured at the shoot() function. The shotType is: " + shotType.ToString());
                    return 0;
            }
            logBoth(log, "Hit Chance: " + chance.ToString());
            int[] damages = shotDamage(shotsFired);
            int totalDamage = 0;
            Dice dice = new Dice(1, Math.Max(100, chance), this.logBoth, log);
            Unit attacker = (Unit) this.comboAttackingUnit.SelectedItem;
            int rolled = -1;

            foreach (int shot in damages)
            {
                rolled = dice.getRoll();

                if (rolled < attacker.StatID.CriticalChance) // Critical Hit
                {
                    logBoth(log, "Critical Hit: " + rolled.ToString() + " < 5");
                    logBoth(log, "Damage Taken: " + (shot * 2).ToString());
                    totalDamage += shot * 2;
                    continue;
                }
                if (rolled > Math.Max(100, chance) - (10 - attacker.StatID.Luck)) // Critical Failure
                {
                    logBoth(log, "Critical Failure: " + rolled.ToString() + " > " + (Math.Max(100, chance) - (10 - attacker.StatID.Luck)).ToString());
                    logBoth(log, "Ending Calculations.");
                    return totalDamage;
                }
                if (rolled < chance) // Hit
                {
                    logBoth(log, "Hit: " + rolled.ToString() + " < " + chance.ToString());
                    logBoth(log, "Damage Taken: " + shot.ToString());
                    totalDamage += shot;
                    continue;
                }
                else if (rolled > chance) // Miss
                {
                    logBoth(log, "Miss: " + rolled.ToString() + " > " + chance.ToString());
                    continue;
                }
                else
                {
                    logBoth(log, "There's a problem, contact the product owner and send the log file (It's in the same directory)");
                    return 0;
                }
            }

            return totalDamage;
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
            int oac = ((Armour) this.comboArmour.SelectedItem).AC;
            int hitBonuses = 0;

            return (int) Math.Floor((skill / ((distance / multiplier) / divisor)) * multiplier + (Math.Pow(weaponRange, 2)) / (distance - (2 * weaponRange)) + (luck - 10) + hitBonuses);
        }

        private int longRangeShotChance()
        {
            // TODO Implement Hit Bonuses
            // Skill * e ^ (-(x - OptimalRange) ^ 2 / (2 * (Skill / 4) ^ 2))
            int skill = -1;
            switch (((Weapon)this.comboWeapon.SelectedItem).DamageType)
            {
                // Electrical (Energy Weapons)
                case (DamageTypes.EL):
                    skill = ((Unit)this.comboAttackingUnit.SelectedItem).StatID.EnergyWeapons;
                    break;

                // Explosive (Explosives)
                case (DamageTypes.EX):
                    skill = ((Unit)this.comboAttackingUnit.SelectedItem).StatID.Explosives;
                    break;

                // Normal (Small Guns) or Big?
                case (DamageTypes.N):
                    skill = ((Unit)this.comboAttackingUnit.SelectedItem).StatID.SmallGuns;
                    break;

                default:
                    return 0;
            }
            int weaponRange = ((Weapon)this.comboWeapon.SelectedItem).Range;
            int luck = ((Unit)this.comboAttackingUnit.SelectedItem).StatID.Luck;
            int distance = int.Parse(textDistance.Text.Trim());
            int hitBonuses = 0;
            // Skill*e^(-(x - OptimalRange)^2/(2 * (Skill / 4)^2))

            return (int) Math.Floor(skill * Math.Exp(-Math.Pow(distance - weaponRange, 2) / (2 * Math.Pow(skill / 4, 2))) + hitBonuses - (luck - 10));
        }

        private int[] shotDamage(int shots)
        {
            writeLog(log, "Beginning Shot Damage Calculation");
            writeLog(log, "Number of shots: " + shots);

            int flatDamage = ((Weapon) this.comboWeapon.SelectedItem).FD;
            Dice BD = ((Weapon) this.comboWeapon.SelectedItem).BD;
            Dice AD = ((Weapon) this.comboWeapon.SelectedItem).AD;
            int ad, bd = -1;

            int[] damages = new int[shots];
            for (int i = 0; i < shots; i++)
            {
                bd = BD.getRoll();
                ad = AD.getRoll();
                damages[i] = bd + ad + flatDamage;
                writeLog(log, "Base Damage: " + bd.ToString() + " Additional Damage: " + ad.ToString() + " Flat Damage: " + flatDamage.ToString());
            }

            writeLog(log, "Ending Shot Calculation");
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
            logBoth(log, "Setting Initial HP to " + this.textCurrentHealth.Text);
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
    }
}
