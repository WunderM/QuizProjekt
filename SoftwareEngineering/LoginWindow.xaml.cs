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
using System.Windows.Shapes;

namespace SoftwareEngineering
{
    /// <summary>
    /// Interaktionslogik für LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public string Name1;
        public string Password;

       
        public LoginWindow()
        {
            InitializeComponent();
        }
        public bool Checklogin(string name, string password)
        {
            if (name == null || password == null)
            {
                return false;
            }
            else return true;
        }
        private void LogIn(object sender, RoutedEventArgs e)
        {
            if (Checklogin(Name1, Password) == true)
            {
                var C = new Categorie();
                this.Close();
                C.ShowDialog();
               


            }
            else if (Name1 == null || Password == null)
            {
                MessageBox.Show("Bitte füllen sie beide Felder aus");
            }
            else
            {
                MessageBox.Show("Name oder Passwort falsch");
            }

            }
        private void LoginName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string name;
            name = LoginName.Text;
            if (name == null)
            {
                MessageBox.Show("Bitte Namen eingeben");
            }
         
            Name1 = name;
        }

        private void LoginPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            string password;
            password = LoginPassword.Text;
            if (password == null)
            {
                MessageBox.Show("Bitte Password eingeben");
            }
           
            Password = password;
        }
        class checkLogin
        {

        }

     
    }
}
