using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRPGC
{
    // Normal, LA?, PL?, Electrical, Fire, Explosive
    enum DamageTypes { N, LA, PL, EL, FR, EX }

    // List Types for searching
    enum ListTypes { Weapons, Armours, Units, Stats }

    // Melee, Short Range Single, Short Range Burst, Long Range
    enum AttackTypes { M, SRS, SRB, LR }

    // Melee, Short Range, Long Range
    enum AttackRange { M, SR, LR }

    // The Five Combat Skills
    enum WeaponSkillType { BigGuns, EnergyWeapons, Explosives, SmallGuns, Unarmed, Melee }

    // The four difficulty levels
    enum Difficulty { Easy, Medium, Hard, ScottIsBeingADick }
}
