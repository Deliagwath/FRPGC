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
        public string Name              { get; set; }
        public string ID                { get; set; }
        public int ArmourClass          { get; set; }
        public int DamageReduction      { get; set; }
        public int LaserResistance      { get; set; }
        public int PlasmaResistance     { get; set; }
        public int ElectricalResistance { get; set; }
        public int FireResistance       { get; set; }
        public int ExplosiveResistance  { get; set; }

        public Armour(string name, string id, int armourClass, int damageResistance, int laserResistance, int plasmaResistance, int electricalResistance, int fireResistance, int explosiveResistance)
        {
            this.Name = name;
            this.ID = id;
            this.ArmourClass = armourClass;
            this.DamageReduction = damageResistance;
            this.LaserResistance = laserResistance;
            this.PlasmaResistance = plasmaResistance;
            this.ElectricalResistance = electricalResistance;
            this.FireResistance = fireResistance;
            this.ExplosiveResistance = explosiveResistance;
        }
        // Normal damage, fire damage, laser damage, plasma damage, electrical damage, explosive damage. 
        public override string ToString()
        {
            string comma = ", ";
            return "[" + this.Name + comma +
                this.ID + comma +
                this.ArmourClass.ToString() + comma +
                this.DamageReduction.ToString() + comma +
                this.LaserResistance.ToString() + comma +
                this.PlasmaResistance.ToString() + comma +
                this.ElectricalResistance.ToString() + comma +
                this.FireResistance.ToString() + comma +
                this.ExplosiveResistance.ToString() + "]";
        }
    }
}
