using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRPGC
{
    // Normal, LA?, PL?, Electrical, Fire, Explosive
    public enum DamageTypes { N, LA, PL, EL, FR, EX }

    // List Types for searching
    public enum ListTypes { Weapons, Armours, Units, Stats }

    // Melee, Short Range Single, Short Range Burst, Long Range
    public enum AttackTypes { M, SRS, SRB, LR }

    // Melee, Short Range, Long Range
    public enum AttackRange { M, SR, LR }

    // The Five Combat Skills
    public enum WeaponSkillType { BigGuns, EnergyWeapons, Explosives, SmallGuns, Unarmed, Melee }

    // The four difficulty levels
    public enum Difficulty { Easy, Medium, Hard, ScottIsBeingADick }
}
