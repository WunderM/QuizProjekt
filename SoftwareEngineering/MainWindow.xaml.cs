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

            SignInWindow signin = new SignInWindow();
            signin.ShowDialog();
        }
        private void LoginClick(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.ShowDialog();
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
            var C = new Categorie();
            C.ShowDialog();
        }
            

    }
}
