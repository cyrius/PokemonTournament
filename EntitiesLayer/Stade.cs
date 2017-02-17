using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Stade : EntityObject
    {
        
        public ETypeElement Element {get; set; }

        private int nbPlaces;
        public int NbPlaces
        {
            get
            {
                return nbPlaces;
            }
            set
            {
                if (value < 0)
                    nbPlaces = 0;
                else nbPlaces = value;
            }
        }

        public Stade() : base("vide") { }
        public Stade(int nbPlace, string nom) : base(nom)
        {
            Element = ETypeElement.Aucun;
            NbPlaces = nbPlace;
        }
        
        public Stade(int nbPlace, string nom, ETypeElement element) : base(nom)
        {
            Element = element;
            NbPlaces = nbPlace;
        }
    }
}
