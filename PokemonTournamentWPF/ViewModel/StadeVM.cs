using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace PokemonTournamentWPF.ViewModel
{
    class StadeVM : ViewModelBase
    {
        private Stade mStade;

        public Stade Stade
        {
            get { return mStade; }
            set { mStade = value; }
        }

        public StadeVM(Stade stade)
        {
            Stade = stade;
        }

        public int ID
        {
            get { return mStade.ID; }
            set
            {
                if (value == mStade.ID) return;
                mStade.ID = value;
                base.OnPropertyChanged("ID");
            }
        }

        public string Nom
        {
            get { return mStade.Nom; }
            set
            {
                if (value == mStade.Nom) return;
                mStade.Nom = value;
                base.OnPropertyChanged("Nom");
            }
        }

        public ETypeElement Element
        {
            get { return mStade.Element; }
            set
            {
                if (value == mStade.Element) return;
                mStade.Element = value;
                base.OnPropertyChanged("Element");
            }
        }

        public int NbPlaces
        {
            get { return mStade.NbPlaces; }
            set
            {
                if (value == mStade.NbPlaces) return;
                mStade.NbPlaces = value;
                base.OnPropertyChanged("NbPlaces");
            }
        }

    }
}
