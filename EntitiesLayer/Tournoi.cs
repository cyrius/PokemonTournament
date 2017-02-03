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
        private Pokemon[] JouerTournoi(Pokemon[] tablpokemon, EPhaseTournoi phase)
        {
            Pokemon[] pokevainqueur = new Pokemon[(int)((tablpokemon.Length) / 2)];
            for (int i=0; i < (tablpokemon.Length)/2; i++)
            {
                Stade stade = BuisnessManager.getInstance.getRandomStade();
                Match match = new Match(tablpokemon[i*2], tablpokemon[(i*2)+1], phase, stade);
            }
            return pokevainqueur;
        }
    }
}
