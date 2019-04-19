using NetVori.Entite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace NetVori
{
    /// <summary>
    /// Fournit un comportement spécifique à l'application afin de compléter la classe Application par défaut.
    /// </summary>
    sealed partial class App : Application
    {

        public static int coordX = 10;
        public static int coordY = 10;
        public static int coordW = 1781;
        public static int coordZ = 822;
        public static bool AfterEvent = false;
        public static JVaisseau vaisseau = new JVaisseau();
        public static List<Technique> ListeDeCompetenceBase;
        public static List<Technique> ListLoot;
        public static List<Technique> ToutesLesCompetence;
        public static Inventaire inventaire = new Inventaire();
        public static List<int> ListEventDejaFait = new List<int>();

        /// <summary>
        /// Initialise l'objet d'application de singleton.  Il s'agit de la première ligne du code créé
        /// à être exécutée. Elle correspond donc à l'équivalent logique de main() ou WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            InitCompetence();
            InitLoot();
        }

        /// <summary>
        /// Invoqué lorsque l'application est lancée normalement par l'utilisateur final.  D'autres points d'entrée
        /// seront utilisés par exemple au moment du lancement de l'application pour l'ouverture d'un fichier spécifique.
        /// </summary>
        /// <param name="e">Détails concernant la requête et le processus de lancement.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Ne répétez pas l'initialisation de l'application lorsque la fenêtre comporte déjà du contenu,
            // assurez-vous juste que la fenêtre est active
            if (rootFrame == null)
            {
                // Créez un Frame utilisable comme contexte de navigation et naviguez jusqu'à la première page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: chargez l'état de l'application précédemment suspendue
                }

                // Placez le frame dans la fenêtre active
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // Quand la pile de navigation n'est pas restaurée, accédez à la première page,
                    // puis configurez la nouvelle page en transmettant les informations requises en tant que
                    // paramètre
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Vérifiez que la fenêtre actuelle est active
                Window.Current.Activate();
            }
        }

        /// <summary>
        /// Appelé lorsque la navigation vers une page donnée échoue
        /// </summary>
        /// <param name="sender">Frame à l'origine de l'échec de navigation.</param>
        /// <param name="e">Détails relatifs à l'échec de navigation</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Appelé lorsque l'exécution de l'application est suspendue.  L'état de l'application est enregistré
        /// sans savoir si l'application pourra se fermer ou reprendre sans endommager
        /// le contenu de la mémoire.
        /// </summary>
        /// <param name="sender">Source de la requête de suspension.</param>
        /// <param name="e">Détails de la requête de suspension.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: enregistrez l'état de l'application et arrêtez toute activité en arrière-plan
            deferral.Complete();
        }


        public void InitCompetence()
        {
            ListeDeCompetenceBase = new List<Technique>();
            ListeDeCompetenceBase.Add(new Technique("Tir Laser", 2));
            ListeDeCompetenceBase.Add(new Technique("Impulsion Électromagnétique", 0));
            ListeDeCompetenceBase.Add(new Technique("Tir de Plasma", 4));
            ListeDeCompetenceBase.Add(new Technique("Missile", 1));
            ListeDeCompetenceBase.Add(new Technique("Tir de Lumière", 8));
            ListeDeCompetenceBase.Add(new Technique("Tir d'Ion",3));
        }

        public void InitLoot()
        {
            ListLoot = new List<Technique>();
            ListLoot.Add(new Technique("Tir Gamma", 20));
            ListLoot.Add(new Technique("Tir Laser II", 3));
            ListLoot.Add(new Technique("Impulsion Électromagnétique II", 1));
            ListLoot.Add(new Technique("Tir de Plasma II", 7));
            ListLoot.Add(new Technique("Missile II", 2));
            ListLoot.Add(new Technique("Tir de Lumière II", 10));
            ListLoot.Add(new Technique("Tir d'Ion II", 5));
            ListLoot.Add(new Technique("Tir Laser III", 4));
            ListLoot.Add(new Technique("Impulsion Électromagnétique III", 2));
            ListLoot.Add(new Technique("Tir de Plasma III", 9));
            ListLoot.Add(new Technique("Missile III", 3));
            ListLoot.Add(new Technique("Tir Gravitationnelle", 11));
            ListLoot.Add(new Technique("Tir d'Ion III", 7));
            ListLoot.Add(new Technique("Tir de Matière Noir", 17));
        }

        public void InitTtesLesCompt()
        {
            ToutesLesCompetence = new List<Technique>();
            ToutesLesCompetence.Add(new Technique("Tir Laser", 2));
            ToutesLesCompetence.Add(new Technique("Impulsion Électromagnétique", 0));
            ToutesLesCompetence.Add(new Technique("Tir de Plasma", 4));
            ToutesLesCompetence.Add(new Technique("Missile", 1));
            ToutesLesCompetence.Add(new Technique("Tir de Lumière", 8));
            ToutesLesCompetence.Add(new Technique("Tir d'Ion", 3));
            ToutesLesCompetence.Add(new Technique("Tir Gamma", 20));
            ToutesLesCompetence.Add(new Technique("Tir Laser II", 3));
            ToutesLesCompetence.Add(new Technique("Impulsion Électromagnétique II", 1));
            ToutesLesCompetence.Add(new Technique("Tir de Plasma II", 7));
            ToutesLesCompetence.Add(new Technique("Missile II", 2));
            ToutesLesCompetence.Add(new Technique("Tir de Lumière II", 10));
            ToutesLesCompetence.Add(new Technique("Tir d'Ion II", 5));
            ToutesLesCompetence.Add(new Technique("Tir Laser III", 4));
            ToutesLesCompetence.Add(new Technique("Impulsion Électromagnétique III", 2));
            ToutesLesCompetence.Add(new Technique("Tir de Plasma III", 9));
            ToutesLesCompetence.Add(new Technique("Missile III", 3));
            ToutesLesCompetence.Add(new Technique("Tir Gravitationnelle", 11));
            ToutesLesCompetence.Add(new Technique("Tir d'Ion III", 7));
            ToutesLesCompetence.Add(new Technique("Tir de Matière Noir", 17));
        }
        
    }
}
