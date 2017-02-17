using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    [Serializable]
    public class Pokemon : EntityObject
    {
        public ETypeElement Type { get; set; }
        public Caracteristiques Caracteristiques { get; set; }

        public Pokemon(string nom, Caracteristiques carac, ETypeElement type) : base(nom)
        {
            Caracteristiques = carac;
            Type = type;
        }

        public Pokemon() : base("vide") { }
        public Pokemon(string nom, ETypeElement elem) : base(nom)
        {
            Caracteristiques = new Caracteristiques(100, 20, 10, 10);
            Type = elem;
        }

        public override String ToString()
        {
            return "Je m'appelle " + Nom + " et je suis de type " + Type + ". Mon identifiant est " + ID;
        }

    }

    public enum ETypeElement
    {
        Aucun,
        Eau,
        Feu,
        Terre,
        Insecte,
        Plante,
        Tonnerre,
        Sol,
    }
}
