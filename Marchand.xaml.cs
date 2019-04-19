using NetVori.Entite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NetVori
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Marchand : Page
    {
        public Marchand()
        {
            this.InitializeComponent();
            GridConteneur.Visibility = Visibility.Collapsed;
            GridAchat.Visibility = Visibility.Collapsed;
        }


        private void btnVendre(object sender, RoutedEventArgs e)
        {
            GridConteneur.Visibility = Visibility.Visible;
            btnConteneur.IsEnabled = false;
            btnConteneur.Opacity = 0;
            btnConteneur_Copy.IsEnabled = false;
            btnConteneur_Copy.Opacity = 0;

            foreach(Technique tec in App.inventaire.Inventary)
            {
                if(App.vaisseau.ListTechnique.Contains(tec))
                {
                    if (txtComp1.Text == string.Empty)
                        txtComp1.Text = tec.Nom;
                    else if (txtComp2.Text == string.Empty)
                        txtComp2.Text = tec.Nom;
                    else if (txtComp3.Text == string.Empty)
                        txtComp3.Text = tec.Nom;
                    else if (txtComp4.Text == string.Empty)
                        txtComp4.Text = tec.Nom;
                    else if (txtComp5.Text == string.Empty)
                        txtComp5.Text = tec.Nom;
                    else if (txtComp6.Text == string.Empty)
                        txtComp6.Text = tec.Nom;
                }
            }
        }

        private void btnAcheter(object sender, RoutedEventArgs e)
        {
            GridAchat.Visibility = Visibility.Visible;

            txtComp11.Text = App.ListLoot[new Random().Next(0, App.ListLoot.Count)].Nom;
            txtComp21.Text = App.ListLoot[new Random().Next(1, App.ListLoot.Count)].Nom;
            txtComp31.Text = App.ListLoot[new Random().Next(2, App.ListLoot.Count)].Nom;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridConteneur.Visibility = Visibility.Collapsed;
            btnConteneur.IsEnabled = true;
            btnConteneur.Opacity = 100;
            btnConteneur_Copy.IsEnabled = true;
            btnConteneur_Copy.Opacity = 100;
        }

        private void Valide3_Click(object sender, RoutedEventArgs e)
        {
            App.vaisseau.ListTechnique.Remove(RechercheTech(txtComp3.Text));
            App.inventaire.Inventary.Remove(RechercheTech(txtComp3.Text));
            txtComp3.Text = string.Empty;
        }

        public Technique RechercheTech(string nom)
        {
            Technique tec = new Technique("NULL", 0);
            foreach (Technique t in App.ListeDeCompetenceBase)
            {
                if (t.Nom == nom)
                    return t;
            }
            return tec;
        }

        private void Valide1_Click(object sender, RoutedEventArgs e)
        {
            App.vaisseau.ListTechnique.Remove(RechercheTech(txtComp1.Text));
            App.inventaire.Inventary.Remove(RechercheTech(txtComp1.Text));
            txtComp1.Text = string.Empty;
        }

        private void Valide2_Click(object sender, RoutedEventArgs e)
        {
            App.vaisseau.ListTechnique.Remove(RechercheTech(txtComp2.Text));
            App.inventaire.Inventary.Remove(RechercheTech(txtComp2.Text));
            txtComp2.Text = string.Empty;
        }

        private void Valide4_Click(object sender, RoutedEventArgs e)
        {
            App.vaisseau.ListTechnique.Remove(RechercheTech(txtComp4.Text));
            App.inventaire.Inventary.Remove(RechercheTech(txtComp4.Text));
            txtComp4.Text = string.Empty;
        }

        private void Valide5_Click(object sender, RoutedEventArgs e)
        {
            App.vaisseau.ListTechnique.Remove(RechercheTech(txtComp5.Text));
            App.inventaire.Inventary.Remove(RechercheTech(txtComp5.Text));
            txtComp5.Text = string.Empty;
        }

        private void Valide6_Click(object sender, RoutedEventArgs e)
        {
            App.vaisseau.ListTechnique.Remove(RechercheTech(txtComp6.Text));
            App.inventaire.Inventary.Remove(RechercheTech(txtComp6.Text));
            txtComp6.Text = string.Empty;
        }

        private void Valide33_Click(object sender, RoutedEventArgs e)
        {
            if(App.inventaire.Inventary.Count < 6)
            {
                App.inventaire.Inventary.Add(RechercheTech(txtComp11.Text));
                txtComp11.Text = string.Empty;
            }
        }

        private void Valide32_Click(object sender, RoutedEventArgs e)
        {
            if (App.inventaire.Inventary.Count < 6)
            {
                App.inventaire.Inventary.Add(RechercheTech(txtComp21.Text));
                txtComp21.Text = string.Empty;
            }
        }

        private void Valide31_Click(object sender, RoutedEventArgs e)
        {
            if (App.inventaire.Inventary.Count < 6)
            {
                App.inventaire.Inventary.Add(RechercheTech(txtComp31.Text));
                txtComp31.Text = string.Empty;
            }
        }
    }
}
