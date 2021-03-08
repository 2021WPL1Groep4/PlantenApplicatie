using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PlantenApplicatie
{
    /// <summary>
    /// Interaction logic for OpzoekenPlant.xaml
    /// </summary>
    public partial class OpzoekenPlant : Window
    {
        public OpzoekenPlant()
        {
            InitializeComponent();
        }

        private void txtPlantnaam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MessageBox.Show("abc");
            }
        }

        private void btnDetailsPlant_Click_1(object sender, RoutedEventArgs e)
        {
            PlantDetails plantDetails = new PlantDetails();
            plantDetails.Show();
        }
    }
}
