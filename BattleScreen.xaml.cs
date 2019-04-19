using NetVori.Entite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
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
    public sealed partial class BattleScreen : Page
    {
        private double vieJoueur;
        private double vieIA;
        private JVaisseau vaisseauA = new JVaisseau();


        public BattleScreen()
        {
            this.InitializeComponent();
            vaisseauA.ListTechnique = new List<Technique>();
            btnAttaqueA.Content = App.vaisseau.ListTechnique[0].Nom;
            btnAttaqueB.Content = App.vaisseau.ListTechnique[1].Nom;
            btnAttaqueC.Content = App.vaisseau.ListTechnique[2].Nom;
            btnAttaqueD.Content = App.vaisseau.ListTechnique[3].Nom;
            vieJoueur = App.vaisseau.PoindDeVie * 10;
            StatsEnemis();
            vieIA = vaisseauA.PoindDeVie * 10;
            BarreDeVieJoueur.Value = 100;
            BarreDeVieEnemis.Value = 100;
            Grid_Victoire.Visibility = Visibility.Collapsed;
            Grid_defaite.Visibility = Visibility.Collapsed;
            TxtBoxLoot1.Text = App.ListLoot[new Random().Next(0, App.ListLoot.Count)].Nom;
            TxtBoxLoot2.Text = App.ListLoot[new Random().Next(1, App.ListLoot.Count)].Nom;
        }

        public void StatsEnemis()
        {
            vaisseauA.PoindDeVie = new Random().Next(3, 10);
            vaisseauA.PuissanceDeTir = new Random().Next(3, 10);
            vaisseauA.Bouclier = new Random().Next(0, 2);
            vaisseauA.ListTechnique = new List<Technique>();
            vaisseauA.ListTechnique.Add(new Technique("A", new Random().Next(1, 5)));
            vaisseauA.ListTechnique.Add(new Technique("B", new Random().Next(1, 5)));
            vaisseauA.ListTechnique.Add(new Technique("C", new Random().Next(1, 5)));
            vaisseauA.ListTechnique.Add(new Technique("D", new Random().Next(1, 5)));
        }

        private int calculVie(bool Joueur)
        {
            if (Joueur)
            {
                if (Convert.ToInt32((vieJoueur * 100) / (App.vaisseau.PoindDeVie * 10)) < 25)
                    BarreDeVieJoueur.Foreground = new SolidColorBrush(Colors.Red);
                return Convert.ToInt32((vieJoueur * 100) / (App.vaisseau.PoindDeVie * 10));
            }
            else
            {
                if (Convert.ToInt32((vieIA * 100) / (vaisseauA.PoindDeVie * 10)) < 25)
                    BarreDeVieEnemis.Foreground = new SolidColorBrush(Colors.Red);
                return Convert.ToInt32((vieIA * 100) / (vaisseauA.PoindDeVie * 10));
            }

        }

        private void btnAttaqueB_Click(object sender, RoutedEventArgs e)
        {
            vieIA -= App.vaisseau.ListTechnique[1].Degat + (App.vaisseau.PuissanceDeTir / 2);
            BarreDeVieEnemis.Value = calculVie(false);
            if (vieIA > 0)
            {
                attaqueEnemis();
                if (vieJoueur < 0)
                    Defaite();
            }
            else
                Victoire();

        }

        private void btnAttaqueA_Click(object sender, RoutedEventArgs e)
        {
            vieIA -= App.vaisseau.ListTechnique[0].Degat + (App.vaisseau.PuissanceDeTir / 2);
            BarreDeVieEnemis.Value = calculVie(false);
            if (vieIA > 0)
            {
                attaqueEnemis();
                if (vieJoueur < 0)
                    Defaite();
            }
            else
                Victoire();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vieIA -= App.vaisseau.ListTechnique[3].Degat + (App.vaisseau.PuissanceDeTir / 2); ;
            BarreDeVieEnemis.Value = calculVie(false);
            if (vieIA > 0)
            {
                attaqueEnemis();
                if (vieJoueur < 0)
                    Defaite();
            }
            else
                Victoire();

        }

        private void btnAttaqueC_Click(object sender, RoutedEventArgs e)
        {
            vieIA -= App.vaisseau.ListTechnique[2].Degat;
            BarreDeVieEnemis.Value = calculVie(false);
            if (vieIA > 0)
            {
                attaqueEnemis();
                if (vieJoueur < 0)
                    Defaite();
            }
            else
                Victoire();

        }

        public void attaqueEnemis()
        {
            vieJoueur -= vaisseauA.ListTechnique[new Random().Next(0, 3)].Degat;
            BarreDeVieJoueur.Value = calculVie(true);
        }

        public async void Victoire()
        {
            Grid_Victoire.Visibility = Visibility.Visible;
            BarreDeVieEnemis.Visibility = Visibility.Collapsed;
            BarreDeVieEnemis.Visibility = Visibility.Collapsed;
            BorderMenu.Visibility = Visibility.Collapsed;
            btnAttaqueA.Visibility = Visibility.Collapsed;
            btnAttaqueB.Visibility = Visibility.Collapsed;
            btnAttaqueC.Visibility = Visibility.Collapsed;
            btnAttaqueD.Visibility = Visibility.Collapsed;
            Vaisseau1.Visibility = Visibility.Collapsed;
            Vaisseau2.Visibility = Visibility.Collapsed;
            ArgentGagner();
            txtComp1V.Text = App.vaisseau.ListTechnique[0].Nom;
            txtComp2V.Text = App.vaisseau.ListTechnique[1].Nom;
            txtComp3V.Text = App.vaisseau.ListTechnique[2].Nom;
            txtComp4V.Text = App.vaisseau.ListTechnique[3].Nom;
           

        }
        public async void Defaite()
        {
            Grid_defaite.Visibility = Visibility.Visible;
            BarreDeVieEnemis.Visibility = Visibility.Collapsed;
            BarreDeVieEnemis.Visibility = Visibility.Collapsed;
            BorderMenu.Visibility = Visibility.Collapsed;
            btnAttaqueA.Visibility = Visibility.Collapsed;
            btnAttaqueB.Visibility = Visibility.Collapsed;
            btnAttaqueC.Visibility = Visibility.Collapsed;
            btnAttaqueD.Visibility = Visibility.Collapsed;
            ArgentGagner();
            txtComp1Def.Text = App.vaisseau.ListTechnique[0].Nom;
            txtComp2Def.Text = App.vaisseau.ListTechnique[1].Nom;
            txtComp3Def.Text = App.vaisseau.ListTechnique[2].Nom;
            txtComp4Def.Text = App.vaisseau.ListTechnique[3].Nom;
        }
        public void ArgentGagner()
        {
            Random aleatoire = new Random();
            int goldar = aleatoire.Next(100, 200);
            TxtArgent.Text = goldar.ToString();
            TxtArgentD.Text = "0";
        }

        private void BtnValiderV_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }

        private void BtnValiderDefaite_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Game));
        }
    }

}
