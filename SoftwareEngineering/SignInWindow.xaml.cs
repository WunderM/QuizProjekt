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
    /// Interaktionslogik für SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();
        }
        public string Signinname1;
        public string Signinpassword1;
        public bool CheckSignin(string name, string password)
        {
            if (name == null || password == null)
            {
                return false;
            }
            else return true;
        }
        private void EnterSignIn(object sender, RoutedEventArgs e)
        {
            if (CheckSignin(Signinname1, Signinpassword1) == true)
            {
                var C = new Categorie();
                this.Close();
                C.ShowDialog();
                
                

            }
            else { MessageBox.Show("Bitte füllen sie beide Felder aus"); }
           
        }

        private void SigninName_TextChanged(object sender, TextChangedEventArgs e)
        {
            string loginname;
            loginname = SigninName.Text;
            Signinname1 = loginname;
        }

        private void SigninPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            string loginpassword;
            loginpassword = SigninPassword.Text;
            Signinpassword1 = loginpassword;

        }
    }
}
