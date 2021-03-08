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
using PlantenApplicatie.Domain;

namespace PlantenApplicatie
{
    /// <summary>
    /// Interaction logic for OpzoekenPlant.xaml
    /// </summary>
    public partial class OpzoekenPlant : Window
    {
        private PlantenDao plantenDAO;

        public OpzoekenPlant()
        {
            InitializeComponent();
            plantenDAO = PlantenDao.Instance();
            cmbFamilie.ItemsSource = plantenDAO.getFamilies();
            cmbGeslacht.ItemsSource = plantenDAO.getGeslachten();
            cmbSoort.ItemsSource = plantenDAO.getSoorten();
            cmbType.ItemsSource = plantenDAO.getTypes();
            lvPlanten.ItemsSource = plantenDAO.GetPlanten();

        }

        private void txtPlantnaam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MessageBox.Show("abc");
                //lvPlanten.ItemsSource = getPlantenByName(sender.ToString());
            }
        }

        private void btnDetailsPlant_Click_1(object sender, RoutedEventArgs e)
        {
            PlantDetails plantDetails = new PlantDetails();
            plantDetails.Show();
        }
    }
}
