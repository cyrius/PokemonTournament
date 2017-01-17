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
        public string Nom { get; set; }
        public ETypeElement Type { get; set; }
        public Caracteristiques Caracteristiques { get; set; }

        public Pokemon(int id, string nom, Caracteristiques carac, ETypeElement type) : base(id)
        {
            Nom = nom;
            Caracteristiques = carac;
            Type = type;
        }

    }

    public enum ETypeElement
    {
        Eau,
        Feu,
        Terre,
        Insecte,
        Plante,
        Sol,
    }
}
