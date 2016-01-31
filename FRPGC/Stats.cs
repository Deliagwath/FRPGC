using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRPGC
{
    class Stats
    {
        public string ID                { get; set; }

        public int Strength             { get; set; }
        public int Perception           { get; set; }
        public int Endurance            { get; set; }
        public int Agility              { get; set; }
        public int Luck                 { get; set; }

        public double HP                { get; set; }
        public double ActionPoints      { get; set; }
        public int CriticalChance       { get; set; }
        public int PoisonResistance     { get; set; }
        public int RadiationResistance  { get; set; }
        public int Melee                { get; set; }
        public int Sequence             { get; set; }
        public int AC                   { get; set; }

        public int BigGuns              { get; set; }
        public int EnergyWeapons        { get; set; }
        public int Explosives           { get; set; }
        public int SmallGuns            { get; set; }
        public int Unarmed              { get; set; }

        public Difficulty Diff          { get; set; }

        public Stats(string id, int level, int str, int per, int end, int agi, int luck, int bigGuns, int energyWeapons, int explosives, int smallGuns, int unarmed, Difficulty diff)
        {
            this.ID = id;

            this.Strength = str;
            this.Perception = per;
            this.Endurance = end;
            this.Agility = agi;
            this.Luck = luck;

            this.HP = (15 + str + (2 * end)) + (level * (3 + (end / 2)));
            this.ActionPoints = 5 + ((agi / 2) + (end / 2));
            this.CriticalChance = luck;
            this.PoisonResistance = end * 5;
            this.RadiationResistance = end * 2;
            this.Melee = Math.Max(str - 5, 0);
            this.Sequence = per * 2;
            this.AC = agi;

            this.BigGuns = bigGuns;
            this.EnergyWeapons = energyWeapons;
            this.Explosives = explosives;
            this.SmallGuns = smallGuns;
            this.Unarmed = unarmed;

            this.Diff = diff;
        }
    }
}
