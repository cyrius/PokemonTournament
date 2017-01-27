using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class EntityObject
    {
        static private int _compteur = 0;
        public int ID { get; set; }
        public string Nom { get; set; }

        public EntityObject(string nom)
        {
            ID = _compteur++;
            Nom = nom;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
