using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using EntitiesLayer;
using BusinessLayer;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PokemonTournamentWPF
{
    /// <summary>
    /// Interaction logic for GestionView.xaml
    /// </summary>
    public partial class GestionView : Window , INotifyPropertyChanged
    {

        BusinessManager businessManager;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<EntityObject> listNom;
        public ObservableCollection<EntityObject> ListNom
        {
            get { return listNom; }
            set
            {
                listNom = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged("ListNom");
            }
        }

        public GestionView(BusinessManager manager)
        {
            InitializeComponent();
            businessManager = manager;
            this.DataContext = this;
        }

        private void Button_Click_Supprimer(object sender, RoutedEventArgs e)
        {
            businessManager.SupprimerEntity((EntityObject) LBEntity.SelectedItem);
            ListNom.Remove((EntityObject)LBEntity.SelectedItem);
        }


        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
