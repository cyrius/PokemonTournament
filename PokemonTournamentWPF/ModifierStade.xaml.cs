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
    /// Interaction logic for ModifierStade.xaml
    /// </summary>
    public partial class ModifierStade : Window
    {
        private Stade stadeModifier;
        private BusinessManager businessManager;
        private MainWindow mainWindow;
        public ModifierStade(BusinessManager bm,MainWindow mw, Stade stadeModif)
        {
            stadeModifier = stadeModif;
            businessManager = bm;
            mainWindow = mw;

            InitializeComponent();
            TBNom.Text = stadeModifier.Nom;
            TBNbPlaces.Text = stadeModifier.NbPlaces.ToString();
            CBElement.ItemsSource = Enum.GetValues(typeof(ETypeElement));
            CBElement.SelectedItem = stadeModifier.Element;
        }

        private void Button_Annuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Modifier_Click(object sender, RoutedEventArgs e)
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
                    businessManager.ModifierStade(stadeModifier, TBNom.Text, Int32.Parse(TBNbPlaces.Text), (ETypeElement)CBElement.SelectedItem);
                    mainWindow.GridData.ItemsSource = null;
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
