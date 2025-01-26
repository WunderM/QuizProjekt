using System.Windows;
using System.Windows.Controls;

namespace SoftwareEngineering
{
    public partial class ScorePage : Page
    {
        private readonly double _score;
        private readonly long _quizId;

        private readonly int _numberOfQuestions;

        public ScorePage(double score, long quizId, int numberOfQuestions)
        {
            InitializeComponent();

            // Punktestand und Quiz-ID speichern
            _score = score;
            _quizId = quizId;
            _numberOfQuestions = numberOfQuestions;

            // Punktestand anzeigen
            ScoreText.Text = $"{_score:F0} Punkte"; // Rundet auf ganze Zahlen
        }

        private void BackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            // Zurück zum Hauptmenü navigieren
            App.SharedViewModel.ChangePage("CategoriePage");
        }

        private void RestartQuiz_Click(object sender, RoutedEventArgs e)
        {
            // Quiz neu starten
            App.SharedViewModel.StartQuiz(_quizId, _numberOfQuestions);
        }
    }
}
