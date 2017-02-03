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
        public Match(ref Pokemon pokemon1, ref Pokemon pokemon2, EPhaseTournoi phase = EPhaseTournoi.QuartFinale) : base(pokemon1.Nom.ToString() + " VS " + pokemon2.Nom.ToString())
        {         
            PhaseTournoi = phase;
            Pokemon1 = pokemon1;
            Pokemon2 = pokemon2;
        }
        public Match(Pokemon pokemon1, Pokemon pokemon2, EPhaseTournoi phase = EPhaseTournoi.QuartFinale) : base(pokemon1.Nom.ToString() + " VS " + pokemon2.Nom.ToString())
        {
            PhaseTournoi = phase;
            Pokemon1 = pokemon1;
            Pokemon2 = pokemon2;
        }
        private Pokemon JouerMatch(Pokemon pokemon1, Pokemon pokemon2, Stade stade)
        {
            int vie1 = pokemon1.Caracteristiques.PV;
            int vie2 = pokemon2.Caracteristiques.PV;
            int def1 = pokemon1.Caracteristiques.Def;
            int def2 = pokemon2.Caracteristiques.Def;
            int att1 = pokemon1.Caracteristiques.Atk;
            int att2 = pokemon2.Caracteristiques.Atk;
            int vit1 = pokemon1.Caracteristiques.Vitesse;
            int vit2 = pokemon2.Caracteristiques.Vitesse;
            if (pokemon1.Type == stade.Element)
            {
                att1 = Convert.ToInt32(att1 * 1.1);
            }
            if (pokemon2.Type == stade.Element)
            {
                att2 = Convert.ToInt32(att2 * 1.1);
            }
            while (vie1>0 && vie2>0)
            {
                if ((att2- def1) > 0)
                {
                    vie1 = vie1 - ((att2 - def1) * vit2);
                }
                if ((att1 - def2) > 0)
                {
                    vie2 = vie2 - ((att1 - def2) * vit1);
                }
            }
            Pokemon vainqueur = null;
            if (vie1 < vie2)
            {
                vainqueur = pokemon2;
            }
            else
            {
                vainqueur = pokemon1;
            }
            return vainqueur;
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
