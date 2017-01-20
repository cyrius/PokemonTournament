using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Stade : EntityObject
    {

        public string Nom { get; set; }
        public ETypeElement Element { get; set; }
        public int NbPlaces { get; set; }

        public Stade(int nbPlace, String nom)
        {
            Element = ETypeElement.Aucun;
            NbPlaces = nbPlace;
            Nom = nom;
            NbPlaces = nbPlace;
            Nom = nom;
        }
        
        public Stade(int nbPlace, string nom, ETypeElement element)
        {
            Element = element;
            NbPlaces = nbPlace;
            Nom = nom;
        }
    }
}
