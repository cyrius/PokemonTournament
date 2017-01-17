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
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BusinessManager businessManager = new BusinessManager();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void btn_Click(object s, EventArgs e)
        {
            Button btn = (Button)s;
            
            switch(btn.Name)
            {
                case "BtnPokemons":
                    GridData.ItemsSource = businessManager.GetAllPokemons();
                    break;
                case "BtnCaracs":
                    break;
                case "BtnStades":
                    break;
                case "BtnMatchs":
                    break;
                case "BtnBonus":
                    break;
                default:
                    break;
            }
        }

    }
}
