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
using BusinessLayer;
using EntitiesLayer;
using System.Collections.ObjectModel;

namespace PokemonTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        BusinessManager manager;
        public Manager()
        {
            manager = new BusinessManager();
            InitializeComponent();
        }

        private void Gestion_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            ObservableCollection<EntityObject> listNom = new ObservableCollection<EntityObject>();

            switch (b.Name)
            {
                case "btn_GestStades":
                    listNom = manager.GetAllStades();                  
                    break;
                case "btn_GestTournoi":

                    break;
                case "btn_GestPokemon":
                    listNom = manager.GetAllPokemons();
                    break;
                case "btn_GestMatch":
                    listNom = manager.GetAllMatchs();
                    break;
                default:
                    break;
            }

            GestionView gv = new GestionView(manager,listNom);
            gv.Show();
        }
    }
}
