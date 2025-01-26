using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SoftwareEngineering
{
    public partial class QuizQuestionPage : Page
    {
        private readonly ApiClient _apiClient;
        private List<QuizQuestion> _questions;
        private int _currentQuestionIndex;
        private List<AnswerSubmission> _answers; // Speichert die Antworten des Spielers

        private long _quizId; 

        public QuizQuestionPage(long quizId, int numberOfQuestions)
        {
            InitializeComponent();

            DataContext = App.SharedViewModel;
            _quizId = quizId;
            _apiClient = new ApiClient();
            _answers = new List<AnswerSubmission>();
            LoadQuestions(quizId, numberOfQuestions);
        }

        private async void LoadQuestions(long quizId, int numberOfQuestions)
        {
            try
            {
                // Hole die Fragen von der API
                _questions = await _apiClient.GetQuizQuestionsAsync(quizId, numberOfQuestions);

                if (_questions == null || _questions.Count == 0)
                {
                    MessageBox.Show("Es konnten keine Fragen geladen werden.");
                    return;
                }

                _currentQuestionIndex = 0;
                DisplayQuestion();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Fragen: {ex.Message}");
            }
        }

        private void DisplayQuestion()
        {
            if (_currentQuestionIndex >= _questions.Count)
            {
                // Alle Fragen beantwortet -> Ergebnisse an den Server senden
                SubmitAnswers();
                return;
            }

            var currentQuestion = _questions[_currentQuestionIndex];
            QuestionText.Text = currentQuestion.Question;

            // Buttons mit Antworten füllen
            var answerButtons = new[] { AnswerButton1, AnswerButton2, AnswerButton3, AnswerButton4 };
            for (int i = 0; i < answerButtons.Length; i++)
            {
                if (i < currentQuestion.Answers.Count)
                {
                    answerButtons[i].Content = currentQuestion.Answers[i];
                    answerButtons[i].Visibility = Visibility.Visible;
                }
                else
                {
                    answerButtons[i].Visibility = Visibility.Collapsed;
                }
            }
        }

        private void AnswerSelected(object sender, RoutedEventArgs e)
        {
            var selectedAnswer = (sender as Button)?.Content?.ToString();
            if (selectedAnswer == null)
                return;

            // Speichere die Antwort
            var currentQuestion = _questions[_currentQuestionIndex];
            _answers.Add(new AnswerSubmission
            {
                QuestionId = currentQuestion.Id,
                SelectedAnswer = selectedAnswer
            });

            _currentQuestionIndex++;
            DisplayQuestion();
        }

        private async void SubmitAnswers()
        {
            if(App.SharedViewModel.UserID > 0 ){
                try
                {
                    var result = await _apiClient.SubmitAnswersAsync(_quizId, _answers);
                    App.SharedViewModel.ShowEndPage(_quizId, _answers.Count, result.Score);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Fehler beim Übermitteln der Antworten: {ex.Message}");
                }
            }
        }
    }
}
