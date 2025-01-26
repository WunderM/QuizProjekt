using System.Windows;
using System.Windows.Controls;

namespace SoftwareEngineering
{
    public partial class LoginPage : Page
    {
        private readonly ApiClient _apiClient;

        public LoginPage()
        {
            InitializeComponent();
            _apiClient = new ApiClient();

            DataContext = App.SharedViewModel;
        }

        private async void LogIn(object sender, RoutedEventArgs e)
        {
            var username = LoginName.Text;
            var password = LoginPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Bitte füllen Sie beide Felder aus.");
                return;
            }

            // API-Aufruf: Login
            var userId  = await _apiClient.LoginAsync(username, password);

            if (userId != null)
            {
                App.SharedViewModel.UserID = userId ?? 0;
                App.SharedViewModel.IsLoggedIn = true;
                App.SharedViewModel.Username = username;
            }
            else
            {
                MessageBox.Show("Login fehlgeschlagen. Bitte überprüfen Sie Ihre Eingaben.");
            }
        }
    }
}
