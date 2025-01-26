using System.Windows;
using System.Windows.Controls;

namespace SoftwareEngineering
{
    public partial class AboutPage : Page
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void BackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            // Zurück zum Hauptmenü navigieren
            App.SharedViewModel.ChangePage("CategoriePage");
        }
    }
}
