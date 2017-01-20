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

namespace PokemonTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BusinessManager businessManager = new BusinessManager();
        String dataAfficher = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        public void btn_Click(object s, EventArgs e)
        {
            Button btn = (Button)s;

            ButtonAjouter.Visibility = Visibility.Visible;

            switch (btn.Name)
            {
                case "BtnPokemons":
                    dataAfficher = "Pokemon";
                    GridData.ItemsSource = businessManager.GetAllPokemons();
                    ButtonAjouter.Content = "Ajouter un pokemon";
                    break;
                case "BtnCaracs":
                    dataAfficher = "Carac";
                    GridData.ItemsSource = businessManager.GetAllCaracteristique();
                    ButtonAjouter.Content = "Ajouter une caracteristique";
                    break;
                case "BtnStades":
                    dataAfficher = "Stade";
                    GridData.ItemsSource = businessManager.GetAllStades();
                    ButtonAjouter.Content = "Ajouter un stade";        
                    break;
                case "BtnMatchs":
                    dataAfficher = "Match";
                    GridData.ItemsSource = businessManager.GetAllMatchs();
                    ButtonAjouter.Content = "Ajouter un match";
                    break;
                case "BtnBonus":
                    break;
                default:
                    break;
            }
        }

        private void Button_Ajouter_Click(object sender, RoutedEventArgs e)
        {
            switch (dataAfficher)
            {
                case "Pokemon":
                    
                    break;
                case "Carac":
                   
                    break;
                case "Stade":
                    AjouterStade asWindow = new AjouterStade(businessManager,this);
                    asWindow.Show();
                    break;
                case "BtnMatchs":
                   
                    break;
                case "Match":
                    break;
                default:
                    break;
            }          
        }

        private void Button_Supprimer_Click(object sender, RoutedEventArgs e)
        {
            switch (dataAfficher)
            {
                case "Pokemon":

                    break;
                case "Carac":

                    break;
                case "Stade":
                    businessManager.SupprimerStade((Stade)GridData.SelectedItem);
                    GridData.ItemsSource = null;
                    GridData.ItemsSource = businessManager.GetAllStades();
                    break;
                case "BtnMatchs":

                    break;
                case "Match":
                    break;
                default:
                    break;
            }
        }

        private void Button_Modifier_Click(object sender, RoutedEventArgs e)
        {
            switch (dataAfficher)
            {
                case "Pokemon":

                    break;
                case "Carac":

                    break;
                case "Stade":
                    ModifierStade modifierStadeView = new ModifierStade(businessManager, this, (Stade)GridData.SelectedItem);
                    modifierStadeView.Show();
                    break;
                case "BtnMatchs":

                    break;
                case "Match":
                    break;
                default:
                    break;
            }
        }

        private void ButtonImprimer_Click(object sender, RoutedEventArgs e)
        {
            ///TODO lié au fonction impression
        }
    }
}
