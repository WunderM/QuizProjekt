using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SoftwareEngineering
{
    public class SharedViewModel : INotifyPropertyChanged
    {
        private bool _isLoggedIn;
        private string _username;

        // Login-Status
        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set
            {
                _isLoggedIn = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(LogoutButtonVisibility));
                OnPropertyChanged(nameof(LoginButtonVisibility));
                OnPropertyChanged(nameof(HeaderUsername));
            }
        }

        // Aktueller Benutzername
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HeaderUsername));
            }
        }

        // Sichtbarkeit des Logout-Buttons
        public Visibility LogoutButtonVisibility => IsLoggedIn ? Visibility.Visible : Visibility.Collapsed;

        // Sichtbarkeit des Login-Buttons
        public Visibility LoginButtonVisibility => !IsLoggedIn ? Visibility.Visible : Visibility.Collapsed;

        // Benutzername im Header
        public string HeaderUsername => IsLoggedIn ? $"Willkommen, {Username}" : "Nicht eingeloggt";

        // INotifyPropertyChanged-Implementierung
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
