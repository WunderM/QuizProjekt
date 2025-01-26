using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SoftwareEngineering
{
    /// <summary>
    /// Interaktionslogik für EndPage.xaml
    /// </summary>
    public partial class EndPage : Page
    {
        private int score;

        public EndPage(int score)
        {
            InitializeComponent();
            this.score = score;

            // Punktestand anzeigen
            ScoreText.Text = $"Dein Punktestand: {score} Punkte";
        }

        private void PlayAgainClick(object sender, RoutedEventArgs e)
        {
            // Zur Kategorienauswahl zurückkehren
            NavigationService.Navigate(new Categorie());
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            // Anwendung beenden
            Application.Current.Shutdown();
        }

    }
}
