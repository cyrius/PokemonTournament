using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;

namespace PokemonTournamentWPF.ViewModel
{
    class PokemonVM : ViewModelBase
    {
        private Pokemon mPokemon;

        public Pokemon Pokemon
        {
            get { return mPokemon; }
            set { mPokemon = value; }
        }

        public PokemonVM(Pokemon pokemon)
        {
            Pokemon = pokemon;
        }

        public int ID
        {
            get { return mPokemon.ID; }
            set
            {
                if (value == mPokemon.ID) return;
                mPokemon.ID = value;
                base.OnPropertyChanged("ID");
            }
        }

        public string Nom
        {
            get { return mPokemon.Nom; }
            set
            {
                if (value == mPokemon.Nom) return;
                mPokemon.Nom = value;
                base.OnPropertyChanged("Nom");
            }
        }

        public ETypeElement Type
        {
            get { return mPokemon.Type; }
            set
            {
                if (value == mPokemon.Type) return;
                mPokemon.Type = value;
                base.OnPropertyChanged("Type");
            }
        }

        public Caracteristiques Caracteristiques
        {
            get { return mPokemon.Caracteristiques; }
            set
            {
                if (value == mPokemon.Caracteristiques) return;
                mPokemon.Caracteristiques = value;
                base.OnPropertyChanged("Caracteristiques");
            }
        }
    }
}
