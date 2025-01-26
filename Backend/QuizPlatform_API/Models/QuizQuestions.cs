using System;

namespace QuizPlatform_API.Models;

public partial class QuizQuestion
{
    public long Id { get; set; }

    public string Question { get; set; } = string.Empty; // Frage ist Pflicht, daher Standardwert setzen

    public string AnswerTrue { get; set; } = string.Empty; // Korrekte Antwort, Pflichtfeld mit Standardwert

    public string AnswerFalseOne { get; set; } = string.Empty; // Erste falsche Antwort, Pflichtfeld mit Standardwert
    public string AnswerFalseTwo { get; set; } = string.Empty; // Zweite falsche Antwort, Pflichtfeld mit Standardwert
    public string AnswerFalseThree { get; set; } = string.Empty; // Dritte falsche Antwort, Pflichtfeld mit Standardwert

    public long QuizId { get; set; } // Fremdschlüssel zu Quiz

    public virtual Quiz? Quiz { get; set; } // Navigationseigenschaft zur zugehörigen Quiz-Entität
}
