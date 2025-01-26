using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace SoftwareEngineering
{
    public class SharedViewModel : INotifyPropertyChanged
    {
        private bool _isLoggedIn;
        private string _username;
        private long _userId;

        private Page _currentPage;

        public SharedViewModel()
        {
        }

        public Page CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        public void StartQuiz(long quizId, int numberOfQuestions){
            CurrentPage  = new QuizQuestionPage(quizId, numberOfQuestions); 
        }

        public void ShowEndPage(long quizId, int numberOfAnswers,double Score){
            CurrentPage = new ScorePage(Score, quizId,numberOfAnswers);
        }


        public void ChangePage(string pageName, long Id)
        {
            switch (pageName)
            {
                case "Quiz":
                    CurrentPage = new QuizPage(Id);
                    break;
                default:
                    throw new ArgumentException($"Page '{pageName}' does not exist.");
            }
        }

        public void ChangePage(string pageName)
        {
            switch (pageName)
            {
                case "StartPage":
                    CurrentPage = new StartPage();
                    break;
                case "LoginPage":
                    CurrentPage = new LoginPage();
                    break;
                case "SignInPage":
                    CurrentPage = new SignInPage();
                    break;
                case "CategoriePage":
                    CurrentPage = new CategoryPage();
                    break;
                default:
                    throw new ArgumentException($"Page '{pageName}' does not exist.");
            }
        }

        // Login-Status
        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set
            {
                _isLoggedIn = value;
                if (_isLoggedIn)
                {
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsLoggedIn));
                    OnPropertyChanged(nameof(LogoutButtonVisibility));
                    OnPropertyChanged(nameof(LoginButtonVisibility));
                    OnPropertyChanged(nameof(HeaderUsername));
                    ChangePage("CategoriePage");
                }
                else
                {
                    ChangePage("StartPage");
                }

            }
        }

        public long UserID{
            get => _userId;
            set{
                _userId = value;
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
