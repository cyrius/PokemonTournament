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

namespace PokemonTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour GestTournoi.xaml
    /// </summary>
    public partial class GestTournoi : Window
    {
        Tournoi tournoi;
        
        public GestTournoi()
        {
            InitializeComponent();
            tournoi = new Tournoi("Tournoi", BusinessManager.Instance.GetAllStades(), BusinessManager.Instance.GetAllPokemons(), 16);
            tournoi.JouerTournoi();
            foreach (Match m in tournoi.Matchs)
            {
                BusinessManager.Instance.AddMatch(m);
            }
            this.DataContext = tournoi;
        }
    }
}
