using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using System.Windows.Input;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;

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

        // Commande Export
        private RelayCommand exportCommand;
        public ICommand ExportCommand
        {
            get
            {
                if (exportCommand == null)
                {
                    exportCommand = new RelayCommand(
                        () => this.Export(),
                        () => this.CanExport()
                        );
                }
                return exportCommand;
            }
        }
        private bool CanExport()
        {
            return true;
        }
        private void Export()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<Stade>));
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "Stades_Export";
            List<Stade> tmp_list = new List<Stade>();
            foreach (StadeVM p in ListeItems)
            {
                tmp_list.Add(p.Stade);
            }
            if (save.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(save.FileName, FileMode.Create))
                {
                    ser.Serialize(fs, tmp_list);
                }
            }
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