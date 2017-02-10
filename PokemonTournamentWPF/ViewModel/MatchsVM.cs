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
    class MatchsVM : ViewModelBase
    {
        private MatchVM selectedItem;
        public MatchVM SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<MatchVM> listeItems;
        public ObservableCollection<MatchVM> ListeItems
        {
            get { return listeItems; }
            private set
            {
                listeItems = value;
                OnPropertyChanged("ListeItems");
            }
        }

        public MatchsVM(List<Match> matchsList)
        {
            SelectedItem = null;
            ListeItems = new ObservableCollection<MatchVM>();
            foreach (Match match in matchsList)
                ListeItems.Add(new MatchVM(match));
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
            return false;
        }
        private void Add()
        {
            throw new NotImplementedException();
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
            return false;
        }
        private void Modify()
        {
            throw new NotImplementedException();
        }

        // Commande Clear
        private RelayCommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                if (clearCommand == null)
                {
                    clearCommand = new RelayCommand(
                        () => this.Clear(),
                        () => this.CanClear()
                        );
                }
                return clearCommand;
            }
        }
        private bool CanClear()
        {
            return (SelectedItem != null);
        }
        private void Clear()
        {
            if (SelectedItem != null)
                SelectedItem = null;
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
            return false;
        }
        private void Remove()
        {
            throw new NotImplementedException();
        }
    }
}