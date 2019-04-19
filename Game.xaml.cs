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
        private List<Button> listeBouton = new List<Button>();
        private List<Image> listeImages = new List<Image>();

        public Game()
        {
            this.InitializeComponent();
            GridConteneur.Visibility = Visibility.Collapsed;
           
            btnVaisseau.Margin = new Thickness(App.coordX, App.coordY, App.coordW, App.coordZ);

            txtComp1.Text = App.inventaire.Inventary[0].Nom;
            txtComp2.Text = App.inventaire.Inventary[1].Nom;
            txtComp3.Text = App.inventaire.Inventary[2].Nom;
            txtComp4.Text = App.inventaire.Inventary[3].Nom;
            if(App.inventaire.Inventary.Count > 4) 
                txtComp5.Text = App.inventaire.Inventary[4].Nom;
            if (App.inventaire.Inventary.Count > 5)
                txtComp6.Text = App.inventaire.Inventary[5].Nom;

            listeBouton.Add(btnAlea1);
            listeBouton.Add(btnAlea2);
            listeBouton.Add(btnAlea3);
            listeBouton.Add(btnAlea4);
            listeBouton.Add(btnAlea5);
            listeBouton.Add(btnAlea6);
            listeBouton.Add(btnAlea7);

            listeImages.Add(imgAlea1);
            listeImages.Add(imgAlea2);
            listeImages.Add(imgAlea3);
            listeImages.Add(imgAlea4);
            listeImages.Add(imgAlea5);
            listeImages.Add(imgAlea6);
            listeImages.Add(imgAlea7);

            if (App.ListEventDejaFait.Count != 0)
            {
                foreach(int i in App.ListEventDejaFait)
                {
                    listeBouton[i-1].Opacity = 0;
                    listeBouton[i-1].IsEnabled = false;
                    listeImages[i-1].Opacity = 0;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BattleScreen));
            App.coordX = 1730;
            App.coordY = 884;
            App.coordW = 46;
            App.coordZ = 10;
            App.ListEventDejaFait.Add(1);
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BattleScreen));
            App.coordX = 1556;
            App.coordY = 134;
            App.coordW = 246;
            App.coordZ = 760;
            App.ListEventDejaFait.Add(2);
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BattleScreen));
            App.coordX = 1102;
            App.coordY = 227;
            App.coordW = 709;
            App.coordZ = 667;
            App.ListEventDejaFait.Add(3);
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BattleScreen));
            App.coordX = 370;
            App.coordY = 655;
            App.coordW = 709;
            App.coordZ = 270;
            App.ListEventDejaFait.Add(4);
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BattleScreen));
            App.coordX = 42;
            App.coordY = 337;
            App.coordW = 1769;
            App.coordZ = 557;
            App.ListEventDejaFait.Add(5);
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BattleScreen));
            App.coordX = 756;
            App.coordY = 928;
            App.coordW = 1055;
            App.coordZ = -34;
            App.ListEventDejaFait.Add(6);
        }
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(BattleScreen));
            App.coordX = 1460;
            App.coordY = 836;
            App.coordW = 351;
            App.coordZ = 58;
            App.ListEventDejaFait.Add(7);
        }

        private void btnVaisseau_Click(object sender, RoutedEventArgs e)
        {
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
