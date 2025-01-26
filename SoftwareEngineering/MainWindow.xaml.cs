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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();

            // Setze das ViewModel als DataContext
            DataContext = App.SharedViewModel;
        }

        private void HomeClick(object sender, RoutedEventArgs e)
        {
            // Lade die Startseite in den Hauptinhalt
            if(App.SharedViewModel.IsLoggedIn){
                App.SharedViewModel.ChangePage("CategoriePage");
            }
            else{
                App.SharedViewModel.ChangePage("StartPage");
            }
            
        }

        private void AboutClick(object sender, RoutedEventArgs e)
        {
            // Zeige Informationen über die App
            MessageBox.Show("About-Button wurde geklickt!");
        }

        private void HelpClick(object sender, RoutedEventArgs e)
        {
            // Zeige Hilfeseite
            MessageBox.Show("Help-Button wurde geklickt!");
        }

        private void LogoutClick(object sender, RoutedEventArgs e)
        {
            // Setze den Login-Status zurück und navigiere zur Login-Seite
            App.SharedViewModel.IsLoggedIn = false;
            App.SharedViewModel.Username = string.Empty;
            
        }

         private void LoginClick(object sender, RoutedEventArgs e)
        {
            // Setze den Login-Status zurück und navigiere zur Login-Seite
            App.SharedViewModel.ChangePage("LoginPage");
        }

        private void closeMainWindow(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Möchten Sie das Fenster wirklich schließen?",
                "Fenster schließen",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
