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
            Caracteristiques = null;
            NbPlaces = nbPlace;
            Nom = nom;
        }
        public Stade(int nbPlace, string nom, Caracteristiques caract, int value)
        {
            Caracteristiques = caract;
            //Stade sans effet particulier par defaut
            NbPlaces = nbPlace;
            Nom = nom;
        }
        public override string ToString()
        {
            return "Stade : " + Nom + " disposant de " + NbPlaces + " places";
        }
        public Stade(int nbPlace, string nom, ETypeElement element)
        {
            Element = element;
            NbPlaces = nbPlace;
            Nom = nom;
        }
        public override string ToString()
        {
            return "Stade : " + Nom + " disposant de " + NbPlaces + " places";
        }
    }
}
