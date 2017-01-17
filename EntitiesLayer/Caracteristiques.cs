using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    [Serializable]
    public class Caracteristiques
    {
        public int PV { get; set; }
        public int Atk { get; set; }
        public int AtkSpe { get; set; }
        public int Def { get; set; }
        public int DefSpe { get; set; }
        public int Vitesse { get; set; }

        public Caracteristiques(int pv, int atk, int atkspe, int def, int defspe, int vitesse)
        {
            PV = pv;
            Atk = atk;
            AtkSpe = atk;
            Def = def;
            DefSpe = defspe;
            Vitesse = vitesse;
        }

    }
}
