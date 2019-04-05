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
            btnVaisseau.Margin = new Thickness(App.coordX, App.coordY, App.coordW, App.coordZ);
            if (App.AfterEvent)
                ApresEvent(0, false);

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
    }
}
