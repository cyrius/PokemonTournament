using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    public class Match : EntityObject
    {
        public Pokemon Vainqueur { get; set; }
        public EPhaseTournoi PhaseTournoi { get; set; }
        public Pokemon Pokemon1 { get; set; }
        public Pokemon Pokemon2 { get; set; }
        public Stade Stade { get; set; }

        //Obligé de surcharger le constructeur si on veut faire
        // Match match = new Match(new Pokemon(...), new Pokemon(...)) ?
        public Match(ref Pokemon pokemon1, ref Pokemon pokemon2, EPhaseTournoi phase, Stade stade) : base(pokemon1.Nom.ToString() + " VS " + pokemon2.Nom.ToString())
        {         
            PhaseTournoi = phase;
            Pokemon1 = pokemon1;
            Pokemon2 = pokemon2;
            Stade = stade;
        }

        private void JouerMatch()
        {
            int vie1 = Pokemon1.Caracteristiques.PV;
            int vie2 = Pokemon2.Caracteristiques.PV;
            int def1 = Pokemon1.Caracteristiques.Def;
            int def2 = Pokemon2.Caracteristiques.Def;
            int att1 = Pokemon1.Caracteristiques.Atk;
            int att2 = Pokemon2.Caracteristiques.Atk;
            int vit1 = Pokemon1.Caracteristiques.Vitesse;
            int vit2 = Pokemon2.Caracteristiques.Vitesse;
            if (Pokemon1.Type == Stade.Element)
            {
                att1 = Convert.ToInt32(att1 * 1.1);
            }
            if (Pokemon2.Type == Stade.Element)
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
            if (vie1 < vie2)
            {
                Vainqueur = Pokemon2;
            }
            else
            {
                Vainqueur = Pokemon1;
            }
        }

        public override string ToString()
        {
            return "Match : " + Pokemon1.Nom + " VS " + Pokemon2.Nom + " . IDVainqueur = " + Vainqueur;
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
