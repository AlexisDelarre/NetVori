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

        }


        private void btnVendre(object sender, RoutedEventArgs e)
        {
            GridConteneur.Visibility = Visibility.Visible;
            btnConteneur.IsEnabled = false;
            btnConteneur.Opacity = 0;
            btnConteneur_Copy.IsEnabled = false;
            btnConteneur_Copy.Opacity = 0;
        }

        private void btnAcheter(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridConteneur.Visibility = Visibility.Collapsed;
            btnConteneur.IsEnabled = true;
            btnConteneur.Opacity = 100;
            btnConteneur_Copy.IsEnabled = true;
            btnConteneur_Copy.Opacity = 100;
        }
    }
}
