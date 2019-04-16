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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using System.Windows.Input;
using Windows.UI;
using NetVori.Entite;
// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace NetVori
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Game : Page
    {
        public int deplacement;


        public Game()
        {
            this.InitializeComponent();
            GridConteneur.Visibility = Visibility.Collapsed;
           
            btnVaisseau.Margin = new Thickness(App.coordX, App.coordY, App.coordW, App.coordZ);
            if (App.AfterEvent)
                ApresEvent(0, false);
            txtComp1.Text = App.inventaire.Inventary[0].Nom;
            txtComp2.Text = App.inventaire.Inventary[1].Nom;
            txtComp3.Text = App.inventaire.Inventary[2].Nom;
            txtComp4.Text = App.inventaire.Inventary[3].Nom;
            if(App.inventaire.Inventary.Count > 4) 
                txtComp5.Text = App.inventaire.Inventary[4].Nom;
            if (App.inventaire.Inventary.Count > 5)
                txtComp6.Text = App.inventaire.Inventary[5].Nom;



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BattleScreen));
            App.coordX = 1730;
            App.coordY = 884;
            App.coordW = 46;
            App.coordZ = 10;
            App.AfterEvent = true;
        }

        private void btnVaisseau_Click(object sender, RoutedEventArgs e)
        {
        }

        public void ApresEvent(int opactity, bool etat)
        {
            imgAlea1.Opacity = opactity;
            btnAlea1.Opacity = opactity;
            btnAlea1.IsEnabled = etat;

        }

        private void btnConteneur_Click(object sender, RoutedEventArgs e)
        {
            GridConteneur.Visibility = Visibility.Visible;
            
        }
        private void Valide1_Click(object sender, RoutedEventArgs e)
        {
            if(Valide1.Content.ToString() == "✔")
            {
                App.vaisseau.ListTechnique.Remove(RechercheTech(txtComp1.Text));
                Valide1.Content = "✘";
                Valide1.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                if(App.vaisseau.ListTechnique.Count < 4)
                {
                    App.vaisseau.ListTechnique.Add(RechercheTech(txtComp1.Text));
                    Valide1.Content = "✔";
                    Valide1.Foreground = new SolidColorBrush(Colors.Green);
                }
            }
        }

        public Technique RechercheTech(string nom)
        {
            Technique tec = new Technique("NULL",0);
            foreach (Technique t in App.ListeDeCompetenceBase)
            {
                if (t.Nom == nom)
                    return t;
            }
            return tec;
        }

        private void Valide2_Click(object sender, RoutedEventArgs e)
        {
            if (txtComp6.Text != string.Empty)
            {
                if (Valide2.Content.ToString() == "✔")
                {
                    App.vaisseau.ListTechnique.Remove(RechercheTech(txtComp2.Text));
                    Valide2.Content = "✘";
                    Valide2.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    if (App.vaisseau.ListTechnique.Count < 4)
                    {
                        App.vaisseau.ListTechnique.Add(RechercheTech(txtComp2.Text));
                        Valide2.Content = "✔";
                        Valide2.Foreground = new SolidColorBrush(Colors.Green);
                    }
                }
            }
        }

        private void Valide3_Click(object sender, RoutedEventArgs e)
        {
            if (txtComp6.Text != string.Empty)
            {
                if (Valide3.Content.ToString() == "✔")
                {
                    App.vaisseau.ListTechnique.Remove(RechercheTech(txtComp3.Text));
                    Valide3.Content = "✘";
                    Valide3.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    if (App.vaisseau.ListTechnique.Count < 4)
                    {
                        App.vaisseau.ListTechnique.Add(RechercheTech(txtComp3.Text));
                        Valide3.Content = "✔";
                        Valide3.Foreground = new SolidColorBrush(Colors.Green);
                    }
                }
            }
        }

        private void Valide4_Click(object sender, RoutedEventArgs e)
        {
            if (txtComp6.Text != string.Empty)
            {
                if (Valide4.Content.ToString() == "✔")
                {
                    App.vaisseau.ListTechnique.Remove(RechercheTech(txtComp4.Text));
                    Valide4.Content = "✘";
                    Valide4.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    if (App.vaisseau.ListTechnique.Count < 4)
                    {
                        App.vaisseau.ListTechnique.Add(RechercheTech(txtComp4.Text));
                        Valide4.Content = "✔";
                        Valide4.Foreground = new SolidColorBrush(Colors.Green);
                    }
                }
            }
        }

        private void Valide6_Click(object sender, RoutedEventArgs e)
        {
            if (txtComp6.Text != string.Empty)
            {
                if (Valide6.Content.ToString() == "✔")
                {
                    App.vaisseau.ListTechnique.Remove(RechercheTech(txtComp6.Text));
                    Valide6.Content = "✘";
                    Valide6.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    if (App.vaisseau.ListTechnique.Count < 4)
                    {
                        App.vaisseau.ListTechnique.Add(RechercheTech(txtComp6.Text));
                        Valide6.Content = "✔";
                        Valide6.Foreground = new SolidColorBrush(Colors.Green);
                    }
                }
            }
        }

        private void Valide5_Click(object sender, RoutedEventArgs e)
        {
            if (txtComp6.Text != string.Empty)
            {
                if (Valide5.Content.ToString() == "✔")
                {
                    App.vaisseau.ListTechnique.Remove(RechercheTech(txtComp5.Text));
                    Valide5.Content = "✘";
                    Valide5.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    if (App.vaisseau.ListTechnique.Count < 4)
                    {
                        App.vaisseau.ListTechnique.Add(RechercheTech(txtComp5.Text));
                        Valide5.Content = "✔";
                        Valide5.Foreground = new SolidColorBrush(Colors.Green);
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (App.vaisseau.ListTechnique.Count == 4)
            {
                GridConteneur.Visibility = Visibility.Collapsed;
              
            }
        }
    }
}
