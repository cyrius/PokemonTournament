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
using EntitiesLayer;
using BusinessLayer;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PokemonTournamentWPF
{
    /// <summary>
    /// Interaction logic for GestionView.xaml
    /// </summary>
    public partial class GestionView : Window
    {
        public GestionView(BusinessManager manager)
        {
            InitializeComponent();
        }
       
    }
}
