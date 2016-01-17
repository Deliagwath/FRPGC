using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRPGC
{
    class Unit
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public Weapon WeaponID { get; set; }
        public Armour ArmourID { get; set; }
        public Stats StatID { get; set; }

        public Unit(string name, string id, Weapon wid, Armour aid, Stats sid)
        {
            this.Name = name;
            this.ID = id;
            this.WeaponID = wid;
            this.ArmourID = aid;
            this.StatID = sid;
        }
    }
}
