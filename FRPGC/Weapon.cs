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
        public string Name                  { get; set; }
        public string ID                    { get; set; }
        public int Range                    { get; set; }
        public int FlatDamage               { get; set; }
        public Dice BaseDamage              { get; set; }
        public Dice AdditionalDamage        { get; set; }
        public int ShotsPerBurst            { get; set; }
        public AttackRange Classification   { get; set; }
        public DamageTypes DamageType       { get; set; }
        public WeaponSkillType WeaponType   { get; set; }

        public Weapon(string name, string id, int singleRange, int flatDamage, Dice baseDamage, Dice additionalDamage, int shotsPerBurst, AttackRange classification, DamageTypes damageType, WeaponSkillType weaponType)
        {
            this.Name = name;
            this.ID = id;
            this.Range = singleRange;
            this.FlatDamage = flatDamage;
            this.BaseDamage = baseDamage;
            this.AdditionalDamage = additionalDamage;
            this.ShotsPerBurst = shotsPerBurst;
            this.Classification = classification;
            this.DamageType = damageType;
            this.WeaponType = weaponType;
        }

        public override string ToString()
        {
            string comma = ", ";
            return "[" + this.Name + comma +
                this.ID + comma +
                this.Range.ToString() + comma +
                this.FlatDamage.ToString() + comma +
                this.BaseDamage.toString() + comma +
                this.AdditionalDamage.toString() + comma +
                this.ShotsPerBurst.ToString() + comma +
                this.Classification.ToString() + comma + 
                this.DamageType.ToString() + comma +
                this.WeaponType.ToString() + "]";
        }
    }
}
