﻿using NetVori.Entite;
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
            txtNbrPoint.Text = nbrPoint.ToString();
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
        }

        private void txtNom_TextChanged(object sender, TextChangedEventArgs e)
        {
            App.vaisseau.Nom = txtNom.Text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.vaisseau.ListTechnique = new List<Technique>();
            App.vaisseau.ListTechnique.Add(new Technique("Attaque A", 2));
            App.vaisseau.ListTechnique.Add(new Technique("Attaque B", 3));
            App.vaisseau.ListTechnique.Add(new Technique("Attaque C", 0));
            App.vaisseau.ListTechnique.Add(new Technique("Attaque D", 5));
            Frame.Navigate(typeof(Game));
        }
    }
}