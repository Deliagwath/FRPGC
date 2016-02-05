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
        public int DTNormal             { get; set; }
        public int DRNormal             { get; set; }
        public int DTLaser              { get; set; }
        public int DRLaser              { get; set; }
        public int DTPlasma             { get; set; }
        public int DRPlasma             { get; set; }
        public int DTElectrical         { get; set; }
        public int DRElectrical         { get; set; }
        public int DTFire               { get; set; }
        public int DRFire               { get; set; }
        public int DTExplosive          { get; set; }
        public int DRExplosive          { get; set; }

        public Armour(string name, string id, int armourClass, int dtn, int drn, int dtl, int drl, int dtp, int drp, int dte, int dre, int dtf, int drf, int dtex, int drex)
        {
            this.Name = name;
            this.ID = id;
            this.ArmourClass = armourClass;
            this.DTNormal = dtn;
            this.DRNormal = drn;
            this.DTLaser = dtl;
            this.DRLaser = drl;
            this.DTPlasma = dtp;
            this.DRPlasma = drp;
            this.DTElectrical = dte;
            this.DRElectrical = dre;
            this.DTFire = dtf;
            this.DRFire = drf;
            this.DTExplosive = dtex;
            this.DRExplosive = drex;
        }
        // Normal damage, fire damage, laser damage, plasma damage, electrical damage, explosive damage. 
        public override string ToString()
        {
            string comma = ", ";
            return "[" + this.Name + comma +
                this.ID + comma +
                this.ArmourClass.ToString() + comma +
                this.DTNormal.ToString() + comma + 
                this.DRNormal.ToString() + comma +
                this.DTLaser.ToString() + comma + 
                this.DRLaser.ToString() + comma +
                this.DTPlasma.ToString() + comma + 
                this.DRPlasma.ToString() + comma +
                this.DTElectrical.ToString() + comma + 
                this.DRElectrical.ToString() + comma +
                this.DTFire.ToString() + comma + 
                this.DRFire.ToString() + comma +
                this.DTExplosive.ToString() + comma + 
                this.DRExplosive.ToString() + "]";
        }
    }
}
