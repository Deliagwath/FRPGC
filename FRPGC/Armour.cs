using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRPGC
{
    class Armour
    {
        //Armour {"Name", "ID", "AC", "DR", "LA", "PL", "EL", "FR", "EX"}
        public string Name  { get; set; }
        public string ID    { get; set; }
        public int AC       { get; set; }
        public int DR       { get; set; }
        public int LA       { get; set; }
        public int PL       { get; set; }
        public int EL       { get; set; }
        public int FR       { get; set; }
        public int EX       { get; set; }

        public Armour(string name, string id, int ac, int dr, int la, int pl, int el, int fr, int ex)
        {
            this.Name = name;
            this.ID = id;
            this.AC = ac;
            this.DR = dr;
            this.LA = la;
            this.PL = pl;
            this.EL = el;
            this.FR = fr;
            this.EX = ex;
        }

        public string toString()
        {
            string comma = ", ";
            return "[" + this.Name + comma +
                this.ID + comma +
                this.AC.ToString() + comma +
                this.DR.ToString() + comma +
                this.LA.ToString() + comma +
                this.PL.ToString() + comma +
                this.EL.ToString() + comma +
                this.FR.ToString() + comma +
                this.EX.ToString() + "]";
        }
    }
}
