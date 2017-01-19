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
    /// Interaction logic for AjouterStade.xaml
    /// </summary>
    public partial class AjouterStade : Window
    {
        BusinessManager businessManager;
        MainWindow mainWindow;

        public AjouterStade(BusinessManager bm, MainWindow mw)
        {
            businessManager = bm;
            mainWindow = mw;
            InitializeComponent();
            CBElement.ItemsSource = Enum.GetValues(typeof(ETypeElement));
            CBElement.SelectedIndex = 0;
        }

        private void Button_Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Valider_Click(object sender, RoutedEventArgs e)
        {
            bool textblockIsEmpty = false;
            if (TBNom.Text == "") textblockIsEmpty = true;
            else
            {
                if (TBNbPlaces.Text == "") textblockIsEmpty = true;
            }

            if (!textblockIsEmpty)
            {
                int nbPlaces;
                if (Int32.TryParse(TBNbPlaces.Text, out nbPlaces))
                {
                    businessManager.AjouterStade(new Stade(nbPlaces, TBNom.Text, (ETypeElement)CBElement.SelectedItem));
                    mainWindow.GridData.ItemsSource = businessManager.GetAllStades();
                    this.Close();
                }
                else
                    ErreurMessage.Content = "Le champ nombre de place n'est pas un nombre!";
            }
            else
            {
                ErreurMessage.Content = "Des champs sont vides!";
            }
        }
    }
}
