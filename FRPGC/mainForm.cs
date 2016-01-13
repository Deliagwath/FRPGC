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
            "Armour.csv",
            "PlayerEquip.csv",
            "EnemyEquip.csv",
            "EnemyStats.csv"
        };

        public mainForm()
        {
            writeLog(log, "Initialising Program.");
            getData();
            InitializeComponent();
        }

        public void getData()
        {
            // Initialise null Containers
            StreamReader reader = null;
            string line = null;

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

                    while ((line = reader.ReadLine()) != null)
                    {
                        // Nom nom nom
                        // Parse Parse Parse
                    }
                }
                
                // Catches and Finally to Log and close StreamReader
                catch (Exception e)
                {
                    writeLog(log, "Exception Occurred: " + e.ToString());
                    writeLog(log, "Ignoring " + filename);
                    reader.Close();
                    check[counter++] = false;
                }
                finally
                {
                    writeLog(log, "Read Successful from " + filename);
                    reader.Close();
                    check[counter++] = true;
                }
            }

            writeLog(log, "Data Retrieval Completed.");
            return;
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
            writer.Write(timestamp + message);
            writer.Close();
            return;
        }

        private void calculate(object sender, EventArgs e)
        {

        }

        private double singleShotHitChance()
        {
            int skill;
            int weaponRange;
            int perception;
            int distance = int.Parse(textDistance.Text);
            int oac;
            int hitBonuses;
            return skill + weaponRange + Math.Floor(perception / 2.0) - distance - oac + hitBonuses;
        }

        private double burstShotHitChance()
        {
            return 0;
            // % = Ceil(1d100 + 15 * (Skill / 4) + 4 * Luck - OAC)
        }

        private int[] singleShotDamage(int shots)
        {
            writeLog(log, "Beginning Single Shot Calculation");
            writeLog(log, "Number of shots: " + shots);

            int baseDamage;
            int baseDamageDie;
            int additionalDamage;
            int additionalDamageDie;

            int[] damages = new int[shots];
            for (int i = 0; i < shots; i++)
            {
                damages[i] = roll(baseDamage, baseDamageDie) + roll(additionalDamage, additionalDamageDie);
                writeLog(log, "Combined Damage: " + damages[i].ToString());
            }

            writeLog(log, "Ending Single Shot Calculation");
            return damages;
        }

        private int[] burstShotDamage(double hitChance, int shotsFired)
        {
            int baseDamage;
            int baseDamageDie;
            int additionalDamage;
            int additionalDamageDie;

            int[] damages = new int[shotsFired];
            for (int i = 0; i < shotsFired; i++)
            {
                if (roll(1, 100) < hitChance)
                {
                    damages[i] = roll(baseDamage, baseDamageDie) + roll(additionalDamage, additionalDamageDie);
                }
                else
                {
                    damages[i] = 0;
                }
            }

            return damages;
        }

        private int roll(int multiplier, int maxRoll)
        {
            Random die = new Random();
            int roll = die.Next(1, maxRoll);
            int result = multiplier * roll;

            writeLog(log, "Rolling " + multiplier.ToString() + "d" + maxRoll.ToString() + ": " + result.ToString());
            return result;
        }
    }
}
