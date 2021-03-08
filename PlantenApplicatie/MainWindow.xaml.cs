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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PlantenApplicatie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void menu_item_Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Dit programma is ontworpen door groep 4:\n\rJim, Zakaria, Lily, Liam en Davy", "Project planten", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        //davy
        private void menu_item_Sluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        //davy
        private void menu_item_Opzoeken_plant_Click(object sender, RoutedEventArgs e)
        {
            OpzoekenPlant opzoekenPlant = new OpzoekenPlant();
            opzoekenPlant.Show();

        }

        //Jim
        private void menu_Item_Toevoegen_Plant_Click(object sender, RoutedEventArgs e)
        {
            ToevoegenPlant toevoegenPlant = new ToevoegenPlant();
            toevoegenPlant.Show();
        }

        private void menu_Item_Wijzigen_Plant_Click(object sender, RoutedEventArgs e)
        {
            WijzigenPlant wijzigenPlant = new WijzigenPlant();
            wijzigenPlant.Show();
        }
    }
}
