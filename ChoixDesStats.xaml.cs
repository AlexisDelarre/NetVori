using NetVori.Entite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace NetVori
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class ChoixDesStats : Page
    {
        private int nbrPoint = 20;
        
       
        public ChoixDesStats()
        {
            this.InitializeComponent();
            ListComp.SelectionMode = ListViewSelectionMode.Multiple;
            txtNbrPoint.Text = nbrPoint.ToString();
            BtnLetsGo.Visibility = Visibility.Collapsed;
            foreach (Technique t in App.ListeDeCompetenceBase)
            {
                ListComp.Items.Add(t.Nom);
            }
            
            
        }

        private void basHP_Click(object sender, RoutedEventArgs e)
        {
            if (App.vaisseau.PoindDeVie != 0)
            {
                App.vaisseau.PoindDeVie -= 1;
                nbrPoint += 1;
                txtHP.Text = App.vaisseau.PoindDeVie.ToString();
                txtNbrPoint.Text = nbrPoint.ToString();
            }
            if (nbrPoint == 0)
            {
                BtnLetsGo.Visibility = Visibility.Visible;
            }
            else
            {
                BtnLetsGo.Visibility = Visibility.Collapsed;
            }
        }

        private void hautHP_Click(object sender, RoutedEventArgs e)
        {
            if (nbrPoint >= 1)
            {
                App.vaisseau.PoindDeVie += 1;
                nbrPoint -= 1;
                txtHP.Text = App.vaisseau.PoindDeVie.ToString();
                txtNbrPoint.Text = nbrPoint.ToString();
            }
            if (nbrPoint == 0)
            {
                BtnLetsGo.Visibility = Visibility.Visible;
            }
            else
            {
                BtnLetsGo.Visibility = Visibility.Collapsed;
            }
        }

        private void basForce_Click(object sender, RoutedEventArgs e)
        {
            if (App.vaisseau.PuissanceDeTir != 0)
            {
                App.vaisseau.PuissanceDeTir -= 1;
                nbrPoint += 1;
                txtForce.Text = App.vaisseau.PuissanceDeTir.ToString();
                txtNbrPoint.Text = nbrPoint.ToString();
            }
            if (nbrPoint == 0)
            {
                BtnLetsGo.Visibility = Visibility.Visible;
            }
            else
            {
                BtnLetsGo.Visibility = Visibility.Collapsed;
            }
        }

        private void hautForce_Click(object sender, RoutedEventArgs e)
        {
            if (nbrPoint >= 1)
            {
                App.vaisseau.PuissanceDeTir += 1;
                nbrPoint -= 1;
                txtForce.Text = App.vaisseau.PuissanceDeTir.ToString();
                txtNbrPoint.Text = nbrPoint.ToString();
            }
            if (nbrPoint == 0)
            {
                BtnLetsGo.Visibility = Visibility.Visible;
            }
            else
            {
                BtnLetsGo.Visibility = Visibility.Collapsed;
            }
        }

        private void basBouclier_Click(object sender, RoutedEventArgs e)
        {
            if (App.vaisseau.Bouclier != 0)
            {
                App.vaisseau.Bouclier -= 1;
                nbrPoint += 5;
                txtBouclier.Text = App.vaisseau.Bouclier.ToString();
                txtNbrPoint.Text = nbrPoint.ToString();
            }
            if (nbrPoint == 0)
            {
                BtnLetsGo.Visibility = Visibility.Visible;
            }
            else
            {
                BtnLetsGo.Visibility = Visibility.Collapsed;
            }
        }

        private void hautBouclier_Click(object sender, RoutedEventArgs e)
        {
            if (nbrPoint >= 5)
            {
                App.vaisseau.Bouclier += 1;
                nbrPoint -= 5;
                txtBouclier.Text = App.vaisseau.Bouclier.ToString();
                txtNbrPoint.Text = nbrPoint.ToString();
            }
            if (nbrPoint == 0)
            {
                BtnLetsGo.Visibility = Visibility.Visible;
            }
            else
            {
                BtnLetsGo.Visibility = Visibility.Collapsed;
            }
        }

        private void txtNom_TextChanged(object sender, TextChangedEventArgs e)
        {
            App.vaisseau.Nom = txtNom.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
         Frame.Navigate(typeof(Game));
            
           
        }

        private void ListComp_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void ListComp_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void ListComp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListComp.SelectedItems.Count >= 4)
            {
                App.vaisseau.ListTechnique = new List<Technique>();
                App.vaisseau.ListTechnique = (from a in App.ListeDeCompetenceBase where (from b in ListComp.SelectedItems select b).Contains(a.Nom) select (a)).ToList();
                App.inventaire.Inventary = (from a in App.ListeDeCompetenceBase where (from b in ListComp.SelectedItems select b).Contains(a.Nom) select (a)).ToList();
                ListComp.SelectionMode = ListViewSelectionMode.None;
            }
        }
    }
}
