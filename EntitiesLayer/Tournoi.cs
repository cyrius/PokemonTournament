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
        public Pokemon Vainqueur { get; private set; }

        public Tournoi(string nom) : base (nom)
        {

        }
        private Pokemon[] JouerPhaseTournoi(ref Pokemon[] tablpokemon, EPhaseTournoi phase)
        {
            Pokemon[] pokevainqueur = new Pokemon[(int)((tablpokemon.Length) / 2)];
            for (int i=0; i < (tablpokemon.Length)/2; i++)
            {
                Stade stade = BusinessManager.Instance.getRandomStade();
                Match match = new Match(ref tablpokemon[i*2], ref tablpokemon[(i*2)+1], phase, stade);
                match.JouerMatch();
                Matchs.Add(match);
                pokevainqueur[i] = match.Vainqueur;
            }
            return pokevainqueur;
        }

        private void JouerTournoi(List<Pokemon> listepokemon)
        {
            if (listepokemon.Count != 16)
            {
                Pokemon[] tabpoke = listepokemon.ToArray();
                tabpoke = JouerPhaseTournoi(ref tabpoke, EPhaseTournoi.HuitiemeFinale);
                tabpoke = JouerPhaseTournoi(ref tabpoke, EPhaseTournoi.QuartFinale);
                tabpoke = JouerPhaseTournoi(ref tabpoke, EPhaseTournoi.DemiFinale);
                tabpoke = JouerPhaseTournoi(ref tabpoke, EPhaseTournoi.Finale);
                Vainqueur = tabpoke[0];
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
    }
}
