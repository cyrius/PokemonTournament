﻿using System;
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
using System.Drawing.Printing;

namespace PokemonTournamentWPF
{
    /// <summary>
    /// Logique d'interaction pour Manager.xaml
    /// </summary>
    public partial class Manager : Window
    {
        BusinessManager manager;
        GestionView gestionView;
        string gestionViewOpened = null;
    
        public Manager()
        {
            manager = BusinessManager.Instance;
            InitializeComponent();
        }

        private void GestionViewClosed(object sender, EventArgs e)
        {
            gestionView = null;
            gestionViewOpened = null;
        }

        private void Gestion_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            if (gestionView == null)
            {
                gestionView = new GestionView(manager);
                gestionView.Closed += new EventHandler(GestionViewClosed);
            }
            gestionViewOpened = b.Name;
            switch (b.Name)
            {
                case "btn_GestStades":
                    gestionView.DataContext = new ViewModel.StadesVM(BusinessManager.Instance.GetAllStades());
                    gestionView.UCGen.Content = new View.UCStade();
                    gestionView.Show();
                    break;
                case "btn_GestPokemon":
                    gestionView.DataContext = new ViewModel.PokemonsVM(BusinessManager.Instance.GetAllPokemons());
                    gestionView.UCGen.Content = new View.UCPokemon();
                    gestionView.Show();
                    break;
                case "btn_GestMatch":
                    gestionView.DataContext = new ViewModel.MatchsVM(BusinessManager.Instance.GetAllMatchs());
                    gestionView.UCGen.Content = new View.UCMatch();
                    gestionView.Show();
                    break;
                case "btn_bonus":
                    gestionView.DataContext = new ViewModel.PokemonsVM(BusinessManager.Instance.GetPokemonBizarre());
                    gestionView.UCGen.Content = new View.UCPokemon();
                    gestionView.Show();
                    break;
                case "btn_imprimer":
                    PrintDialog print = new PrintDialog();
                    if (print.ShowDialog()==true)
                    {
                        var p = print.PrintQueue.FullName;
                        StringBuilder Impression = new StringBuilder();
                        List<Pokemon> listpoke = BusinessManager.Instance.GetAllPokemons();
                        List<Stade> liststade = BusinessManager.Instance.GetAllStades();
                        Impression.Append("Pokemon :\n\n");
                        foreach(Pokemon poke in listpoke){
                            Impression.Append(poke.Nom + "\n");
                        }
                        Impression.Append("\n\nStades :\n\n");
                        foreach (Stade stade in liststade)
                        {
                            Impression.Append(stade.Nom + "\n");
                        }
                        PokemonPrinter printer = new PokemonPrinter(p, "config.json", Impression.ToString());
                        printer.Print();
                    }
                    break;
                default:
                    break;
            }           
        }
        private void Tournoi_Click(object sender, RoutedEventArgs e)
        {
            GestTournoi gt = new PokemonTournamentWPF.GestTournoi();
            gt.Show();
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            if (gestionView != null)
                gestionView.Close();
        }

        private void btn_Dal_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            switch(b.Name)
            {
                case "btn_DalStub":
                    b.IsEnabled = false;
                    this.btn_DalSQL.IsEnabled = true;
                    manager.useDalStub();
                    break;

                case "btn_DalSQL":
                    b.IsEnabled = false;
                    this.btn_DalStub.IsEnabled = true;
                    manager.useDalSQL();
                    break;
            }

            switch(gestionViewOpened)
            {
                case "btn_GestStades":
                    Gestion_Click(btn_GestStades, null);
                    break;
                case "btn_GestPokemon":
                    Gestion_Click(btn_GestPokemon, null);
                    break;
                case "btn_GestMatch":
                    Gestion_Click(btn_GestMatch, null);
                    break;

                default:
                    break;
            }
        }
    }
}
