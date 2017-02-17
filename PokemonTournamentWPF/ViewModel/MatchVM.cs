using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace PokemonTournamentWPF.ViewModel
{
    class MatchVM : ViewModelBase
    {
        private Match mMatch;

        public Match Match
        {
            get { return mMatch; }
            set { mMatch = value; }
        }

        public MatchVM(Match match)
        {
            Match = match;
        }

        public int ID
        {
            get { return mMatch.ID; }
            set
            {
                if (value == mMatch.ID) return;
                mMatch.ID = value;
                base.OnPropertyChanged("ID");
            }
        }

        public string Nom
        {
            get { return mMatch.Nom; }
            set
            {
                if (value == mMatch.Nom) return;
                mMatch.Nom = value;
                base.OnPropertyChanged("Nom");
            }
        }

        public Pokemon Pokemon1
        {
            get { return mMatch.Pokemon1; }
            set
            {
                if (value == mMatch.Pokemon1) return;
                mMatch.Pokemon1 = value;
                base.OnPropertyChanged("Pokemon1");
            }
        }

        public Pokemon Pokemon2
        {
            get { return mMatch.Pokemon2; }
            set
            {
                if (value == mMatch.Pokemon2) return;
                mMatch.Pokemon2 = value;
                base.OnPropertyChanged("Pokemon2");
            }
        }

        public Stade Stade
        { 
            get { return mMatch.Stade; }
            set
            {
                if (value == mMatch.Stade) return;
                mMatch.Stade = value;
                base.OnPropertyChanged("Stade");
            }
        }

        public EPhaseTournoi PhaseTournoi
        {
            get { return mMatch.PhaseTournoi; }
            set
            {
                if (value == mMatch.PhaseTournoi) return;
                mMatch.PhaseTournoi = value;
                base.OnPropertyChanged("PhaseTournoi");
            }
        }
        

        public Pokemon Vainqueur
        {
            get { return mMatch.Vainqueur; }
            set
            {
                if (value == mMatch.Vainqueur) return;
                mMatch.Vainqueur = value;
                base.OnPropertyChanged("Vainqueur");
            }
        }

    }
}
