using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRPGC
{
    class Dice
    {
        public int Multiplier               { get; set; }
        public int MaxRoll                  { get; set; }
        Action<string, string> LogMethod    { get; set; }
        string LogName                      { get; set; }

        public Dice(int multiplier, int maxRoll, Action<string, string> logMethod, string logName)
        {
            this.Multiplier = multiplier;
            this.MaxRoll = maxRoll;
            this.LogMethod = logMethod;
            this.LogName = logName;
        }

        public int getRoll()
        {
            if (this.MaxRoll == 0 || this.MaxRoll == 1)
            {
                this.LogMethod(this.LogName, "Constant Found, returning " + this.Multiplier);
                return this.Multiplier;
            }

            Random die = new Random();
            int result = 0;
            int roll = 0;
            int[] rollresults = new int[Multiplier];

            for (int i = 0; i < Multiplier; i++)
            {
                roll = die.Next(1, MaxRoll);
                rollresults[i] = roll;
                result += roll;
            }

            LogMethod(LogName, "Rolling " + Multiplier.ToString() + "d" + MaxRoll.ToString() + ": " + result.ToString());
            LogMethod(LogName, "Rolls Obtained: [" + string.Join(", ", rollresults) + "] (1d" + MaxRoll.ToString() + ")");
            return result;
        }

        public string toString()
        {
            return this.Multiplier + "d" + this.MaxRoll;
        }
    }
}
