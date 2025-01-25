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
            var success = await _apiClient.LoginAsync(username, password);

            if (success)
            {
                MessageBox.Show("Login erfolgreich!");
                // Hier kannst du zur nächsten Seite navigieren
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow.MainW.Content = new Page(); // Beispielseite
            }
            else
            {
                MessageBox.Show("Login fehlgeschlagen. Bitte überprüfen Sie Ihre Eingaben.");
            }
        }
    }
}
