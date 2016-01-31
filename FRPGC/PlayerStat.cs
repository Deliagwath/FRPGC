using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRPGC
{
    class PlayerStat
    {
        public string ID { get; set; }

        public int Strength { get; set; }
        public int Perception { get; set; }
        public int Endurance { get; set; }
        public int Agility { get; set; }
        public int Luck { get; set; }

        public double HP { get; set; }
        public double ActionPoints { get; set; }
        public int CriticalChance { get; set; }
        public int PoisonResistance { get; set; }
        public int RadiationResistance { get; set; }
        public int MeleeDamage { get; set; }
        public int Sequence { get; set; }
        public int AC { get; set; }

        public int BigGuns { get; set; }
        public int EnergyWeapons { get; set; }
        public int Explosives { get; set; }
        public int SmallGuns { get; set; }
        public int Unarmed { get; set; }
        public int Melee { get; set; }

        public PlayerStat(string id, int level, int str, int per, int end, int agi, int luck, int bigGuns, int energyWeapons, int explosives, int smallGuns, int unarmed, int melee, int critchance)
        {
            this.ID = id;

            this.Strength = str;
            this.Perception = per;
            this.Endurance = end;
            this.Agility = agi;
            this.Luck = luck;

            this.HP = (15 + str + (2 * end)) + (level * (3 + (end / 2)));
            this.ActionPoints = 5 + ((agi / 2) + (end / 2));
            this.CriticalChance = critchance;
            this.PoisonResistance = end * 5;
            this.RadiationResistance = end * 2;
            this.MeleeDamage = Math.Max(str - 5, 0);
            this.Sequence = per * 2;
            this.AC = agi;

            this.BigGuns = bigGuns;
            this.EnergyWeapons = energyWeapons;
            this.Explosives = explosives;
            this.SmallGuns = smallGuns;
            this.Unarmed = unarmed;
            this.MeleeDamage = melee;
        }

        public string ToString()
        {
            string comma = ", ";
            return "[" + this.ID + comma +
                this.Strength.ToString() + comma +
                this.Perception.ToString() + comma +
                this.Endurance.ToString() + comma +
                this.Agility.ToString() + comma +
                this.Luck.ToString() + comma +
                this.HP.ToString() + comma +
                this.ActionPoints.ToString() + comma +
                this.CriticalChance.ToString() + comma +
                this.PoisonResistance.ToString() + comma +
                this.RadiationResistance.ToString() + comma +
                this.MeleeDamage.ToString() + comma +
                this.Sequence.ToString() + comma +
                this.AC.ToString() + comma +
                this.BigGuns.ToString() + comma +
                this.EnergyWeapons.ToString() + comma +
                this.Explosives.ToString() + comma +
                this.SmallGuns.ToString() + comma +
                this.Unarmed.ToString() + comma +
                this.MeleeDamage.ToString() + "]";
        }
    }
}
