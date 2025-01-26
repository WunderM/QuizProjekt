using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SoftwareEngineering
{
    public partial class QuizPage : Page
    {
        private readonly ApiClient _apiClient;
        private List<Quiz> _availableQuizzes;
        private Quiz _selectedQuiz;
        private int _selectedQuestionCount;

        public QuizPage(long categoryId)
        {
            InitializeComponent();

            DataContext = App.SharedViewModel;
            _apiClient = new ApiClient();
            _availableQuizzes = new List<Quiz>();
            _selectedQuestionCount = 5; // Standardwert
            LoadQuizzes(categoryId);
        }

        private async void LoadQuizzes(long categoryId)
        {
            try
            {
                // Quiz-Daten von der API laden
                _availableQuizzes = await _apiClient.GetAvailableQuizzesAsync(categoryId);

                // Quiz-Selector mit Daten füllen
                QuizSelector.ItemsSource = _availableQuizzes;
                QuizSelector.DisplayMemberPath = "Title";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Quiz: {ex.Message}");
            }
        }

        private async void LoadHighscores(long quizId)
        {
            try
            {
                // Highscores von der API abrufen
                var highscores = await _apiClient.GetHighscoresAsync(quizId);

                // Highscore-Tabelle aktualisieren
                HighscoreTable.ItemsSource = highscores;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Highscores: {ex.Message}");
            }
        }

        private void QuizSelector_Changed(object sender, SelectionChangedEventArgs e)
        {
            _selectedQuiz = QuizSelector.SelectedItem as Quiz;
            LoadHighscores(_selectedQuiz.Id);
            UpdateStartButtonState();
        }

        private void QuestionCountSelector_Changed(object sender, SelectionChangedEventArgs e)
        {
            if (QuestionCountSelector.SelectedItem is ComboBoxItem selectedItem)
            {
                _selectedQuestionCount = int.Parse(selectedItem.Content.ToString() ?? "5");
                UpdateStartButtonState();
            }
        }

        private void UpdateStartButtonState()
        {
            // Der Start-Button wird aktiviert, wenn ein Quiz ausgewählt wurde
            StartQuizButton.IsEnabled = _selectedQuiz != null;
        }

        private void StartQuizButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedQuiz != null)
            {
                // Übergibt die Auswahl an das nächste Fenster
                var quizPage = new QuizQuestionPage(_selectedQuiz.Id, _selectedQuestionCount);
                NavigationService.Navigate(quizPage);
            }
        }
    }
}
