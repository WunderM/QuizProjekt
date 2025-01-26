using System;
using System.Windows;
using System.Windows.Controls;

namespace SoftwareEngineering
{
    public partial class LoginPage : Page
    {
        public string Name1 { get; set; }
        public string Password { get; set; }

        public LoginPage()
        {
            InitializeComponent();
        }

        public bool CheckLogin(string name, string password)
        {
            return !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(password);
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            Name1 = LoginName.Text;
            Password = LoginPassword.Password; // Richtig: PasswordBox verwendet Password-Eigenschaft.

            if (CheckLogin(Name1, Password))
            {
                // Lade eine andere Seite (z. B. Kategorienseite) in den Haupt-Frame
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.Login.Content = new Page(); // Beispiel-Seite für Kategorien
            }
            else
            {
                MessageBox.Show(string.IsNullOrEmpty(Name1) || string.IsNullOrEmpty(Password)
                    ? "Bitte füllen Sie beide Felder aus."
                    : "Name oder Passwort falsch.");
            }
        }

        private void LoginName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Name1 = LoginName.Text;
        }

        private void LoginPassword_TextChanged(object sender, RoutedEventArgs e)
        {
            Password = LoginPassword.Password;
        }
    }
}
