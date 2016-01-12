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
    }
}
