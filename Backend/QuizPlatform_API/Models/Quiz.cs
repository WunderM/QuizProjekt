using System;
using System.Collections.Generic;

namespace QuizPlatform_API.Models;

public partial class Quiz
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty; // Null vermeiden und Standardwert setzen

    public long? CategoryId { get; set; } // Fremdschlüssel für die Kategorie

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Standardwert für das Erstellungsdatum

    public virtual QuizCategory? Category { get; set; } // Navigationseigenschaft für die Kategorie

    public virtual ICollection<Highscore> Highscores { get; set; } = new List<Highscore>(); // Verknüpfte Highscores

    public virtual ICollection<QuizQuestion> QuizQuestions { get; set; } = new List<QuizQuestion>(); // Verknüpfte Highscores
}
