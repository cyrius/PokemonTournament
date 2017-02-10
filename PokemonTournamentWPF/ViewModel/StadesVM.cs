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
    class StadesVM : ViewModelBase
    {
        private StadeVM selectedItem;
        public StadeVM SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private ObservableCollection<StadeVM> listeItems;
        public ObservableCollection<StadeVM> ListeItems
        {
            get { return listeItems; }
            private set
            {
                listeItems = value;
                OnPropertyChanged("ListeItems");
            }
        }

        public StadesVM(List<Stade> stadesList)
        {
            SelectedItem = null;
            ListeItems = new ObservableCollection<StadeVM>();
            foreach (Stade stade in stadesList)
                ListeItems.Add(new StadeVM(stade));
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
            Stade std = new Stade(0, "New");
            BusinessLayer.BusinessManager.Instance.AddStade(std);
            ListeItems.Add(new StadeVM(std));
;            
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
            BusinessLayer.BusinessManager.Instance.UpdateStade(SelectedItem.Stade);
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
            BusinessLayer.BusinessManager.Instance.DeleteStade(SelectedItem.Stade);
            ListeItems.Remove(SelectedItem);
            SelectedItem = null;            
        }
    }
}