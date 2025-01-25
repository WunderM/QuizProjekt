using System;
using System.Windows;
using System.Windows.Controls;

namespace SoftwareEngineering
{
    public partial class LoginWindow : Window
    {
        public string Name1 { get; set; }
        public string Password { get; set; }

        public LoginWindow()
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
            Password = LoginPassword.Password; // Korrektur: .Password statt .Text

            if (CheckLogin(Name1, Password))
            {
                var categorieWindow = new Categorie();
                this.Close();
                categorieWindow.ShowDialog();
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

            if (string.IsNullOrEmpty(Name1))
            {
                MessageBox.Show("Bitte Namen eingeben.");
            }
        }

        private void LoginPassword_TextChanged(object sender, RoutedEventArgs e)
        {
            Password = LoginPassword.Password; // Korrektur: .Password statt .Text

            if (string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Bitte Passwort eingeben.");
            }
        }
    }
}
