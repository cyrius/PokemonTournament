using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Windows.Input;

namespace PokemonTournamentWPF.ViewModel
{
    class PokemonsVM : ViewModelBase
    {
        private PokemonVM selectedItem;
        public PokemonVM SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<PokemonVM> listeItems;
        public ObservableCollection<PokemonVM> ListeItems
        {
            get { return listeItems; }
            private set
            {
                listeItems = value;
                OnPropertyChanged("ListeItems");
            }
        }

        public PokemonsVM(List<Pokemon> pokemonsList)
        {
            SelectedItem = null;
            ListeItems = new ObservableCollection<PokemonVM>();
            foreach (Pokemon pokemon in pokemonsList)
                ListeItems.Add(new PokemonVM(pokemon));
        }

        // Commande Add
        private RelayCommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(
                        () => this.Add(),
                        () => this.CanAdd()
                        );
                }
                return addCommand;
            }
        }
        private bool CanAdd()
        {
            return true;
        }
        private void Add()
        {
            Pokemon pok = new Pokemon("New", ETypeElement.Aucun);
            BusinessLayer.BusinessManager.Instance.AddPokemon(pok);
            ListeItems.Add(new PokemonVM(pok));            
        }

        // Commande Modify
        private RelayCommand modifyCommand;
        public ICommand ModifyCommand
        {
            get
            {
                if (modifyCommand == null)
                {
                    modifyCommand = new RelayCommand(
                        () => this.Modify(),
                        () => this.CanModify()
                        );
                }
                return modifyCommand;
            }
        }
        private bool CanModify()
        {
            return (SelectedItem != null && SelectedItem.ID != 0);
        }
        private void Modify()
        {
            BusinessLayer.BusinessManager.Instance.UpdatePokemon(SelectedItem.Pokemon);
        }

        // Commande Remove
        private RelayCommand removeCommand;
        public ICommand RemoveCommand
        {
            get
            {
                if (removeCommand == null)
                {
                    removeCommand = new RelayCommand(
                        () => this.Remove(),
                        () => this.CanRemove()
                        );
                }
                return removeCommand;
            }
        }
        private bool CanRemove()
        {
            return (SelectedItem != null && SelectedItem.ID != 0);
        }
        private void Remove()
        {
            BusinessLayer.BusinessManager.Instance.DeletePokemon(SelectedItem.Pokemon);
            ListeItems.Remove(SelectedItem);
            SelectedItem = null;
        }
    }
}