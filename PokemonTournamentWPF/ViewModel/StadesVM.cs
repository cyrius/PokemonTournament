using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTournamentWPF.ViewModel
{
    class StadesVM : ViewModelBase
    {
        // Event destiné à réclamer la fermeture du conteneur;
        public event EventHandler<EventArgs> CloseNotified;
        protected void OnCloseNotified(EventArgs e)
        {
            this.CloseNotified(this, e);
        }

        // Model encapsulé dans le ViewModel
        private ObservableCollection<StadeVM> mArtistes;

        public ObservableCollection<StadeVM> Stades
        {
            get { return mArtistes; }
            private set
            {
                mArtistes = value;
                OnPropertyChanged("Stades");
            }
        }

        private StadeVM _selectedItem;
        public StadeVM SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public StadesVM(IList<EntitiesLayer.Stade> stadesModel)
        {
            mArtistes = new ObservableCollection<StadeVM>();
            foreach (EntitiesLayer.Stade a in stadesModel)
            {
                mArtistes.Add(new StadeVM(a));
            }
        }

        #region "Commandes du formulaire"

        // Commande Add
        private RelayCommand _addCommand;
        public System.Windows.Input.ICommand AddCommand
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(
                        () => this.Add(),
                        () => this.CanAdd()
                        );
                }
                return _addCommand;
            }
        }

        private bool CanAdd()
        {
            return true;
        }

        private void Add()
        {
            EntitiesLayer.Stade s = new EntitiesLayer.Stade(0, "<New>");

            this.SelectedItem = new StadeVM(s);
            Stades.Add(this.SelectedItem);
        }

        // Commande Remove
        private RelayCommand _removeCommand;
        public System.Windows.Input.ICommand RemoveCommand
        {
            get
            {
                if (_removeCommand == null)
                {
                    _removeCommand = new RelayCommand(
                        () => this.Remove(),
                        () => this.CanRemove()
                        );
                }
                return _removeCommand;
            }
        }

        private bool CanRemove()
        {
            return (this.SelectedItem != null);
        }

        private void Remove()
        {
            if (this.SelectedItem != null) Stades.Remove(this.SelectedItem);
        }

        // Commande Close
        private RelayCommand _closeCommand;
        public System.Windows.Input.ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new RelayCommand(
                        () => this.Close(),
                        () => this.CanClose()
                        );
                }
                return _closeCommand;
            }
        }

        private bool CanClose()
        {
            return true;
        }

        private void Close()
        {
            OnCloseNotified(new EventArgs());
        }

        #endregion
    }
}
