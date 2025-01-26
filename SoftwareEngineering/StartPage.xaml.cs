using System.Windows;
using System.Windows.Controls;

namespace SoftwareEngineering
{
    public partial class StartPage : Page
    {
        private readonly ApiClient _apiClient;

        public StartPage()
        {
            InitializeComponent();
            _apiClient = new ApiClient();

            DataContext = App.SharedViewModel;
        }

        private void SignInClick(object sender, RoutedEventArgs e)
        {
           App.SharedViewModel.ChangePage("SignInPage"); 
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            App.SharedViewModel.ChangePage("LoginPage"); 
        }

        private void GuestClick(object sender, RoutedEventArgs e)
        {
            App.SharedViewModel.ChangePage("CategoriePage"); 
        }
    }
}
