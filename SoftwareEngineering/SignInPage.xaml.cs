using System.Windows;
using System.Windows.Controls;

namespace SoftwareEngineering
{
    public partial class SignInPage : Page
    {
        private readonly ApiClient _apiClient;

        public SignInPage()
        {
            InitializeComponent();
            _apiClient = new ApiClient();
            DataContext = App.SharedViewModel;
        }

        private async void Register(object sender, RoutedEventArgs e)
        {
            var username = SigninName.Text;
            var password = SigninPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Bitte füllen Sie beide Felder aus.");
                return;
            }

            // API-Aufruf: Registrierung
            var success = await _apiClient.RegisterAsync(username, password);

            if (success)
            {
                MessageBox.Show("Registrierung erfolgreich!");
                // Hier kannst du zum Login weiterleiten
                
            }
            else
            {
                MessageBox.Show("Registrierung fehlgeschlagen. Benutzername könnte bereits vergeben sein.");
            }
        }
    }
}
