using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRPGC
{
    class Weapon
    {
        // Weapons {"Name", "ID", "Range", "BD", "AD", "SPB"(Shots per burst), "DamageType"}
        public string Name              { get; set; }
        public string ID                { get; set; }
        public int Range                { get; set; }
        public int FD                   { get; set; }
        public Dice BD                  { get; set; }
        public Dice AD                  { get; set; }
        public int SPB                  { get; set; }
        public DamageTypes DamageType   { get; set; }

        public Weapon(string name, string id, int singleRange, int fd, Dice bd, Dice ad, int spb, DamageTypes damageType)
        {
            this.Name = name;
            this.ID = id;
            this.Range = singleRange;
            this.FD = fd;
            this.BD = bd;
            this.AD = ad;
            this.SPB = spb;
            this.DamageType = damageType;
        }

        public string toString()
        {
            string comma = ", ";
            return "[" + this.Name + comma +
                this.ID + comma +
                this.Range.ToString() + comma +
                this.FD.ToString() + comma +
                this.BD.toString() + comma +
                this.AD.toString() + comma +
                this.SPB.ToString() + comma +
                this.DamageType.ToString() + "]";
        }
    }
}
