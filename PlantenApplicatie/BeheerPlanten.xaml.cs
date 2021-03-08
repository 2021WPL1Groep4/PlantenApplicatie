using PlantenApplicatie.Data;
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
    /// Interaction logic for BeheerPlanten.xaml
    /// </summary>
    public partial class BeheerPlanten : Window
    {
        PlantenDao plantenDao;

        public BeheerPlanten()
        {
            InitializeComponent();
            plantenDao = PlantenDao.Instance();

            lvPlanten.ItemsSource = plantenDao.GetPlanten();
            cmbType.ItemsSource = plantenDao.GetTypes();
            cmbGeslacht.ItemsSource = plantenDao.GetGeslachten();
            cmbSoort.ItemsSource = plantenDao.GetSoorten();
            cmbFamilie.ItemsSource = plantenDao.GetFamilies();

        }

        private void txtPlantnaam_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtNLNaam_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnZoeken_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDetailsPlant_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtVariant_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
