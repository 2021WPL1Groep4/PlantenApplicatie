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
    /// Interaction logic for PlantDetails.xaml
    /// </summary>

    public partial class PlantDetails : Window
    {
        private PlantenDao plantenDAO;
        public PlantDetails()
        {
            InitializeComponent();
            plantenDAO = PlantenDao.Instance;
            Start();
        }

        private void Start()
        {
            cmbEigenschappen.Items.Add("FenoType");
            cmbEigenschappen.Items.Add("Abiotiek");
            cmbEigenschappen.Items.Add("Beheer");
            cmbEigenschappen.Items.Add("Extra's");
            cmbEigenschappen.Items.Add("Commensalisme");

            cmbEigenschappen.SelectedIndex = 0;


        }

        private void btnSluiten_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cmbEigenschappen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectie();
        }

        private void selectie()
        {
            string comboboxText = cmbEigenschappen.SelectedValue.ToString();

            switch (comboboxText)
            {
                case "FenoType":
                    lstLijst.Visibility = Visibility.Visible;
                    ChangeToFenotype();

                    break;
                case "Abiotiek":
                    lstLijst.Visibility = Visibility.Collapsed;
                    ChangeToAbiotiek();

                    break;
                case "Beheer":
                    lstLijst.Visibility = Visibility.Visible;
                    ChangeToBeheer();

                    break;
                case "Extra's":
                    lstLijst.Visibility = Visibility.Collapsed;
                    ChangeToExtra();

                    break;
                case "Commensalisme":
                    lstLijst.Visibility = Visibility.Collapsed;
                    ChangeToCommensalisme();

                    break;

                default:
                    break;
            }
        }
        private void ChangeToFenotype()
        {
            
            lblBladgrootte.Content = "Bladgrootte :";
            lblBladvorm.Content = "Bladvorm :";
            lblRatio.Content = "Ratio Bloei/Blad :";
            lblBloeiwijze.Content = "Bloeiwijze :";
            lblHabitus.Content = "Habitus :";
            lblLevensvorm.Content = "Levensvorm :";
            lblGeurend.Content = "";
            lblVorstGevoelig.Content = "";
        }

        private void ChangeToAbiotiek()
        {
            
            lblBladgrootte.Content = "Bezonning :";
            lblBladvorm.Content = "Grondsoort :";
            lblRatio.Content = "Vochtbehoefte :";
            lblBloeiwijze.Content = "Voedingsbehoefte :";
            lblHabitus.Content = "Antagonische omgeving :";
            lblLevensvorm.Content = "Habitat :";
            lblGeurend.Content = "";
            lblVorstGevoelig.Content = "";
            lblBladGrootteResult.Content = plantenDAO.GetAbiotiek();
        }
        private void ChangeToBeheer()
        {
            lblBladgrootte.Content = "";
            lblBladvorm.Content = "";
            lblRatio.Content = "";
            lblBloeiwijze.Content = "";
            lblHabitus.Content = "";
            lblLevensvorm.Content = "";
            lblGeurend.Content = "";
            lblVorstGevoelig.Content = "";
        }
        private void ChangeToExtra()
        {
            lblBladgrootte.Content = "Nectarwaarde :";
            lblBladvorm.Content = "Pollenwaarde :";
            lblRatio.Content = "Bijvriendelijk :";
            lblBloeiwijze.Content = "Vlindervriendelijk :";
            lblHabitus.Content = "Eetbaar :";
            lblLevensvorm.Content = "Kruidgebruik :";
            lblGeurend.Content = "Geurend :";
            lblVorstGevoelig.Content = "Vorstgevoelig :";
        }
        private void ChangeToCommensalisme()
        {
            lblBladgrootte.Content = "Ontwikkelingssnelheid :";
            lblBladvorm.Content = "Strategie :";
            lblRatio.Content = "Sociabiliteit :";
            lblBloeiwijze.Content = "Levensvorm :";
            lblHabitus.Content = "";
            lblLevensvorm.Content = "";
            lblGeurend.Content = "";
            lblVorstGevoelig.Content = "";
        }
    }
}

