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
        public List<Stade> Stades { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        Random rand = new Random();
        public Tournoi(string nom, List<Stade> stades, List<Pokemon> listepokemon, int taille) : base(nom)
        {
            Stades = stades;
            Pokemons = getRandomPokemon(taille, listepokemon);
        }
        private Pokemon[] JouerPhaseTournoi(Pokemon[] tablpokemon, EPhaseTournoi phase)
        {
            Pokemon[] pokevainqueur = new Pokemon[(int)((tablpokemon.Length) / 2)];
            for (int i = 0; i < (tablpokemon.Length) / 2; i++)
            {
                Stade stade = getRandomStade();
                Match match = new Match(tablpokemon[i * 2], tablpokemon[(i * 2) + 1], stade, phase);
                match.JouerMatch();
                Matchs.Add(match);
                pokevainqueur[i] = match.Vainqueur;
            }
            return pokevainqueur;
        }

        public void JouerTournoi()
        {
            Pokemon[] tabpoke = Pokemons.ToArray();
            Matchs = new List<Match>();
            tabpoke = JouerPhaseTournoi(tabpoke, EPhaseTournoi.HuitiemeFinale);
            tabpoke = JouerPhaseTournoi(tabpoke, EPhaseTournoi.QuartFinale);
            tabpoke = JouerPhaseTournoi(tabpoke, EPhaseTournoi.DemiFinale);
            tabpoke = JouerPhaseTournoi(tabpoke, EPhaseTournoi.Finale);
            Vainqueur = tabpoke[0];
        }

        private Stade getRandomStade()
        {
            return Stades[rand.Next(0, Stades.Count)];
        }

        private List<Pokemon> getRandomPokemon(int nb, List<Pokemon> pokes)
        {
            List<Pokemon> pkmns = new List<Pokemon>();
            for (int i = 0; i < nb; i++)
            {
                pkmns.Add(pokes[rand.Next(0, pokes.Count)]);
            }

            return pkmns;
            
        }
    }
}
