using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Tournoi : EntityObject
    {
        public List<Match> Matchs { get; set; }

        public Tournoi(string nom) : base (nom)
        {

        }
    }
}
