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
            int singleRange, burstRange, c, m, r, spb = 0;
            Dice bd, ad = null;
            DamageTypes dt;
            string[] splitted, constantSplit, diceSplit = null;

            while ((line = reader.ReadLine()) != null)
            {
                // Weapons {"Name":0, "ID":1, "Range":2, "BD":3, "AD":4, "SPB"(Shots per burst):5, "DamageType":6}
                splitted = line.Trim().Split(',');

                name = splitted[0].Trim();
                logBoth(log, "Parsing " + name);
                id = splitted[1].Trim();

                // Parse Range X\Y or X Format
                try
                {
                    // Parsing X\Y Format
                    constantSplit = splitted[2].Trim().Split('\\');
                    singleRange = int.Parse(constantSplit[0].Trim());
                    burstRange = int.Parse(constantSplit[1].Trim());
                }
                catch
                {
                    try
                    {
                        singleRange = int.Parse(splitted[2].Trim());
                        burstRange = -1;
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
                    // Parsing X+YdZ Format
                    constantSplit = splitted[3].Trim().Split('+');
                    diceSplit = constantSplit[1].Trim().ToLower().Split('d');
                    c = int.Parse(constantSplit[0].Trim());
                    m = int.Parse(diceSplit[0].Trim());
                    r = int.Parse(diceSplit[1].Trim());
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
                    // Parsing X+YdZ Format
                    constantSplit = splitted[4].Trim().Split('+');
                    diceSplit = constantSplit[1].Trim().ToLower().Split('d');
                    c = int.Parse(constantSplit[0].Trim());
                    m = int.Parse(diceSplit[0].Trim());
                    r = int.Parse(diceSplit[1].Trim());
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

                // Parsing Damage Type
                switch (splitted[6].Trim())
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
                    logBoth(log, "DamageType could not be parsed. Expected N|LA|PL|EL|FR|EX, got: " + splitted[6].Trim());
                    continue;
                }

                // Creating Weapon Object and adding to List
                this.weapons.Add(new Weapon(name, id, singleRange, burstRange, c, bd, ad, spb, dt));
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
                    textCurrentHealth.Text = (int.Parse(textInitialHealth.Text) - singleShot(int.Parse(textShotCount.Text))).ToString();
                    break;

                case (1): // Burst Shot
                    textCurrentHealth.Text = (int.Parse(textInitialHealth.Text) - singleShot(int.Parse(textShotCount.Text))).ToString();
                    break;

                case (2): // Melee
                    break;

                default:
                    writeLog(log, "ComboBox Firing Type Error, Index: " + this.comboFireType.SelectedIndex);
                    MessageBox.Show("Fire Type Drop Down List says wut: " + this.comboFireType.SelectedIndex);
                    break;
            }
        }

        private int singleShot(int shotsFired)
        {
            int chance = singleShotHitChance();
            int[] damages = singleShotDamage(shotsFired);
            int totalDamage = 0;
            Dice dice = new Dice(1, Math.Max(100, chance), this.logBoth, log);
            int rolled = -1;

            foreach (int shot in damages)
            {
                rolled = dice.getRoll();

                if (rolled < 5) // Critical Hit
                {
                    logBoth(log, "Critical Hit: " + rolled.ToString() + " < 5");
                    logBoth(log, "Damage Taken: " + (shot * 2).ToString());
                    totalDamage += shot * 2;
                    continue;
                }
                if (rolled < chance) // Hit
                {
                    logBoth(log, "Hit: " + rolled.ToString() + " < " + chance.ToString());
                    logBoth(log, "Damage Taken: " + shot.ToString());
                    totalDamage += shot;
                    continue;
                }
                else if (rolled > chance /*- (10 - LUCK)*/) // Miss
                {
                    logBoth(log, "Miss: " + rolled.ToString() + " > " + chance.ToString());
                    continue;
                }
                else // Critical Failure TODO Set correct log
                    // TODO set CRITICAL FAIL BEFORE NORMAL HIT CHECK
                {
                    logBoth(log, "Critical Failure: " + rolled.ToString() + " > 95");
                    logBoth(log, "Ending Calculations.");
                    return totalDamage;
                }
            }

            return totalDamage;
        }

        private int burstShot(int shotsFired)
        {
            int chance = burstShotHitChance();
            int[] damages = burstShotDamage(shotsFired);
            int totalDamage = 0;
            Dice dice = new Dice(1, Math.Max(100, chance), this.logBoth, log);
            int rolled = -1;

            foreach (int shot in damages)
            {
                rolled = dice.getRoll();

                if (rolled < 5) // Critical Hit
                {
                    logBoth(log, "Critical Hit: " + rolled.ToString() + " < 5");
                    logBoth(log, "Damage Taken: " + (shot * 2).ToString());
                    totalDamage += shot * 2;
                    continue;
                }
                if (rolled < chance) // Hit
                {
                    logBoth(log, "Hit: " + rolled.ToString() + " < " + chance.ToString());
                    logBoth(log, "Damage Taken: " + shot.ToString());
                    totalDamage += shot;
                    continue;
                }
                else if (rolled > chance /*- (10 - LUCK)*/) // Miss
                {
                    logBoth(log, "Miss: " + rolled.ToString() + " > " + chance.ToString());
                    continue;
                }
                else // Critical Failure TODO Set correct log
                {
                    logBoth(log, "Critical Failure: " + rolled.ToString() + " > 95");
                    logBoth(log, "Ending Calculations.");
                    return totalDamage;
                }
            }

            return totalDamage;
        }

        private int singleShotHitChance()
        {
            // TODO Fix Skill & Perception & Hit Bonuses
            int skill = 75;
            int weaponRange = ((Weapon) this.comboWeapon.SelectedItem).SingleRange;
            int perception = 7;
            int distance = int.Parse(textDistance.Text);
            int oac = ((Armour) this.comboArmour.SelectedItem).AC;
            int hitBonuses = 0;
            return (int) Math.Floor(skill + weaponRange + Math.Floor(perception / 2.0) - distance - oac + hitBonuses);
        }

        private int burstShotHitChance()
        {
            return 75;
            // % = Ceil(1d100 + 15 * (Skill / 4) + 4 * Luck - OAC)
        }

        private int[] singleShotDamage(int shots)
        {
            writeLog(log, "Beginning Single Shot Damage Calculation");
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

            writeLog(log, "Ending Single Shot Calculation");
            return damages;
        }

        //??? Ignoring rolls for now
        public int roll(int i, int j) { return 0; }
        //???

        private int[] burstShotDamage(int shotsFired)
        {
            int flatDamage = ((Weapon) this.comboWeapon.SelectedItem).FD;
            Dice BD = ((Weapon) this.comboWeapon.SelectedItem).BD;
            Dice AD = ((Weapon) this.comboWeapon.SelectedItem).AD;
            int ad, bd = -1;

            return new int[]{12, 8, 4};

            int[] damages = new int[shotsFired];
            for (int i = 0; i < shotsFired; i++)
            {
                bd = BD.getRoll();
                ad = AD.getRoll();
                damages[i] = bd + ad + flatDamage;
                writeLog(log, "Base Damage: " + bd.ToString() + " Additional Damage: " + ad.ToString() + " Flat Damage: " + flatDamage.ToString());
            }
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
            // TODO After Unit Equip CSV is formed
        }

        private void comboDefenderUnitChanged(object sender, EventArgs e)
        {
            // TODO After Unit Equip CSV is formed
        }
    }
}
