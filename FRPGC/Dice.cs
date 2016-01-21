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
        Log logger                          { get; set; }
        string LogName                      { get; set; }

        public Dice(int multiplier, int maxRoll, Log logger)
        {
            this.Multiplier = multiplier;
            this.MaxRoll = maxRoll;
            this.logger = logger;
        }

        public int getRoll()
        {
            if (this.MaxRoll == 0 || this.MaxRoll == 1)
            {
                this.logger.writeLog("Constant Found, returning " + this.Multiplier);
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

            this.logger.logBoth("Rolling " + Multiplier.ToString() + "d" + MaxRoll.ToString() + ": " + result.ToString());
            this.logger.logBoth("Rolls Obtained: [" + string.Join(", ", rollresults) + "] (1d" + MaxRoll.ToString() + ")");
            return result;
        }

        public string toString()
        {
            return this.Multiplier + "d" + this.MaxRoll;
        }
    }
}
