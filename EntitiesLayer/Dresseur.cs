using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Dresseur : EntityObject
    {

        public int Score { get; set; }

        public Dresseur(string nom) : base(nom)
        {
            Score = 0;
        }
        public override string ToString()
        {
            return "Dresseur : " + Nom + " | score : " + Score + " points";
        }
    }
}
