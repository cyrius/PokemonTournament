using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Match : EntityObject
    {
        public int IdPokemonVainqueur { get; set; }
        public EPhaseTournoi PhaseTournoi { get; set; }
        public Pokemon Pokemon1 { get; set; }
        public Pokemon Pokemon2 { get; set; }
        public Stade Stade { get; set; }

        //Obligé de surcharger le constructeur si on veut faire
        // Match match = new Match(new Pokemon(...), new Pokemon(...)) ?
        public Match(string nom, ref Pokemon pokemon1, ref Pokemon pokemon2, EPhaseTournoi phase = EPhaseTournoi.QuartFinale) : base(nom)
        {
            PhaseTournoi = phase;
            Pokemon1 = pokemon1;
            Pokemon2 = pokemon2;
        }
        public Match(string nom, Pokemon pokemon1, Pokemon pokemon2, EPhaseTournoi phase = EPhaseTournoi.QuartFinale) : base(nom)
        {
            PhaseTournoi = phase;
            Pokemon1 = pokemon1;
            Pokemon2 = pokemon2;
        }

        public override string ToString()
        {
            return "Match : " + Pokemon1.Nom + " VS " + Pokemon2.Nom + " . IDVainqueur = " + IdPokemonVainqueur;
        }
    }

    public enum EPhaseTournoi
    {
        QuartFinale,
        HuitiemeFinale,
        DemiFinale,
        Finale,
    }
}
