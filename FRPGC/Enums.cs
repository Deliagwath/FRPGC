using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRPGC
{
    // Normal, LA?, PL?, Electrical, Fire, Explosive
    enum DamageTypes { N, LA, PL, EL, FR, EX }

    // Melee, Short Range Single, Short Range Burst, Long Range
    enum AttackTypes { M, SRS, SRB, LR }

    // Melee, Short Range, Long Range
    enum AttackRange { M, SR, LR }

    // The Five Combat Skills
    enum WeaponSkillType { BigGuns, EnergyWeapons, Explosives, SmallGuns, Unarmed, Melee }
}
