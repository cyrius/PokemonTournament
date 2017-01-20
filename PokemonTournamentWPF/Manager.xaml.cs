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
            switch (b.Name)
            {
                case "btn_GestStades":
                    AjouterStade fs = new AjouterStade(manager);
                    fs.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
