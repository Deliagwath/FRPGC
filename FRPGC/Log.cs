using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRPGC
{
    class Log
    {
        private string filename;
        private TextBox logArea;

        public Log(string filename, TextBox textbox)
        {
            this.filename = filename;
            this.logArea = textbox;
        }

        public void writeLog(string message)
        {
            // Initialising Writer
            StreamWriter writer;
            if (System.IO.File.Exists(this.filename)) { writer = new StreamWriter(this.filename, true); }
            else { writer = new StreamWriter(this.filename); }

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
            this.logArea.AppendText(timestamp + message + "\n");
            return;
        }

        public void logBoth(string message)
        {
            writeLog(message);
            updateLog(message);
        }
    }
}
