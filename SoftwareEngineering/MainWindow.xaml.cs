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
        }

        private void SignInClick(object sender, RoutedEventArgs e)
        {
            Signin.Content = new SignInPage();
            ShowFrame("Signin");
        }

        private void ShowFrame(string frameName)
        {
            // Alle Frames ausblenden
            MainW.Visibility = Visibility.Collapsed;
            Guest.Visibility = Visibility.Collapsed;
            Login.Visibility = Visibility.Collapsed;
            Signin.Visibility = Visibility.Collapsed;

            // Nur den gewünschten Frame anzeigen
            switch (frameName)
            {
                case "MainW":
                    MainW.Visibility = Visibility.Visible;
                    break;
                case "Guest":
                    Guest.Visibility = Visibility.Visible;
                    break;
                case "Login":
                    Login.Visibility = Visibility.Visible;
                    break;
                case "Signin":
                    Signin.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            Login.Content = new LoginPage();
            ShowFrame("Login");
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
        private void GuestClick(object sender, RoutedEventArgs e)
        {
            Guest.Content = new CategoryPage();
            ShowFrame("Guest");
        }

        private void HomeClick(object sender, RoutedEventArgs e)
        {
            // Lade die Startseite in den Hauptinhalt
            MessageBox.Show("Home-Button wurde geklickt!");
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
            // Logout-Logik (z. B. zum Login-Fenster zurückkehren)
            MessageBox.Show("Logout-Button wurde geklickt!");
        }

    }
}
