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

        public Dice(string input, Log logger)
        {
            this.logger = logger;

            bool parseOK = parseable(input);
            bool d = false;

            if (!parseOK)
            {
                this.logger.logBoth(String.Format("Unable to create Dice, Input: {0}\nSetting Dice to 0d0", input));
                this.Multiplier = 0;
                this.MaxRoll = 0;
                return;
            }
            int mul, max = -1;

            // Traditional Dice Format
            try
            {
                d = input.Contains("d");
                if (!d) { throw new Exception("Constant Format"); }
                string[] parsed = input.Split('d');
                mul = int.Parse(parsed[0]);
                this.Multiplier = mul;
                max = int.Parse(parsed[1]);
                this.MaxRoll = max;
                return;
            }

            // Constant
            catch
            {
                mul = 0;
                this.Multiplier = mul;
                max = int.Parse(input);
                this.MaxRoll = max;
                return;
            }
        }

        public int getRoll()
        {
            if (this.Multiplier == 0)
            {
                this.logger.writeLog("Constant Found, returning " + this.MaxRoll);
                return this.MaxRoll;
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

        public static bool parseable(string input)
        {
            int mul, max = -1;
            bool diceFormat = false;
            bool mulParse = false;
            bool maxParse = false;

            try
            {
                string[] parsed = input.Split('d');
                diceFormat = true;
                mulParse = int.TryParse(parsed[0], out mul);
                maxParse = int.TryParse(parsed[1], out max);
            }
            catch
            {
                maxParse = int.TryParse(input, out max);
            }

            return diceFormat ? mulParse && maxParse : maxParse;
        }
    }
}
