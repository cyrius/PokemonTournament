using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Utilisateur
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Utilisateur(string login , string pass, string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
            Login = login;
            Password = pass;
        }
        
    }
}
