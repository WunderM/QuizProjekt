using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaktionslogik für Questions.xaml
    /// </summary>
    public partial class Questions : Page
    {
        private List<Question> questions; // Liste der Fragen
        private int currentQuestionIndex = 0; // Aktuelle Frage
        private int score = 0; // Punktestand

        public Questions(string category)
        {
            InitializeComponent();

            // Kategorie-Titel setzen
            CategoryTitle.Text = $"Kategorie: {category}";

            // Fragen laden
            LoadQuestions(category);

            if (questions.Any())
            {
                DisplayQuestion(questions[currentQuestionIndex]);
            }
            else
            {
                MessageBox.Show("Keine Fragen für diese Kategorie verfügbar.");
                NavigationService.GoBack();
            }
        }

        private void LoadQuestions(string category)
        {
            string csvPath = "questions.csv"; // Pfad zur CSV-Datei

            if (File.Exists(csvPath))
            {
                questions = File.ReadAllLines(csvPath)
                    .Skip(1) // Überspringe die Kopfzeile
                    .Select(line => line.Split(';'))
                    .Where(columns => columns[0] == category) // Filtere nach Kategorie
                    .Select(columns => new Question
                    {
                        QuestionText = columns[1],
                        CorrectAnswer = columns[2],
                        WrongAnswers = new List<string> { columns[3], columns[4], columns[5] }
                    })
                    .ToList();
            }
            else
            {
                MessageBox.Show("Die CSV-Datei wurde nicht gefunden.");
                questions = new List<Question>();
            }
        }

        private void DisplayQuestion(Question question)
        {
            // Frage anzeigen
            QuestionText.Text = question.QuestionText;

            // Antworten mischen
            var allAnswers = new List<string> { question.CorrectAnswer }
                .Concat(question.WrongAnswers)
                .OrderBy(_ => Guid.NewGuid()) // Zufällige Reihenfolge
                .ToList();

            // Antworten den Buttons zuweisen
            AnswerButton1.Content = allAnswers[0];
            AnswerButton2.Content = allAnswers[1];
            AnswerButton3.Content = allAnswers[2];
            AnswerButton4.Content = allAnswers[3];

            // Fortschritt anzeigen
            ProgressText.Text = $"Frage {currentQuestionIndex + 1} von {questions.Count}";
        }

        private void AnswerClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                var selectedAnswer = button.Content.ToString();
                var currentQuestion = questions[currentQuestionIndex];

                if (selectedAnswer == currentQuestion.CorrectAnswer)
                {
                    score++; // Punktestand erhöhen
                    MessageBox.Show("Richtig!");
                }
                else
                {
                    MessageBox.Show($"Falsch! Die richtige Antwort ist: {currentQuestion.CorrectAnswer}");
                }

                // Nächste Frage oder Ende
                currentQuestionIndex++;
                if (currentQuestionIndex < questions.Count)
                {
                    DisplayQuestion(questions[currentQuestionIndex]);
                }
                else
                {
                    // Ende der Fragen: Zur EndPage navigieren
                    NavigationService.Navigate(new EndPage(score));
                }
            }
        }
    }

    // Frage-Klasse zur Modellierung der Daten
    public class Question
    {
        public string QuestionText { get; set; } // Die Frage
        public string CorrectAnswer { get; set; } // Die richtige Antwort
        public List<string> WrongAnswers { get; set; } // Die falschen Antworten
    }
}
