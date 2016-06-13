using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRPGC
{
    class Player
    {
        public string Name          { get; set; }
        public string ID            { get; set; }
        public Weapon WeaponID      { get; set; }
        public Armour ArmourID      { get; set; }
        public PlayerStat StatID    { get; set; }

        public Player(string name, string id, Weapon wid, Armour aid, PlayerStat sid)
        {
            this.Name = name;
            this.ID = id;
            this.WeaponID = wid;
            this.ArmourID = aid;
            this.StatID = sid;
        }

        public override string ToString()
        {
            string comma = ", ";
            return "[" + this.Name + comma +
                this.ID + comma +
                this.WeaponID.Name + comma +
                this.ArmourID.Name + comma +
                this.StatID.ID.ToString() + "]";
        }
    }
}
