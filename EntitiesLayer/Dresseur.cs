using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Dresseur : EntityObject
    {
        private string _nom;

        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        public int Score { get; set; }

        public Dresseur(string nom)
        {
            _nom = nom;
            Score = 0;
        }
        public override string ToString()
        {
            return "Dresseur : " + Nom + " | score : " + Score + " points";
        }
    }
}
