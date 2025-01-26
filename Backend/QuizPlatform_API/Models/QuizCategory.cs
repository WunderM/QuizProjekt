using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuizPlatform_API.Models;

public partial class QuizCategory
{
    public long Id { get; set; }

    public string Title { get; set; } = string.Empty; // Standardwert, um Nullreferenzen zu vermeiden

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Erstellungsdatum mit Standardwert

    [JsonIgnore]
    public virtual ICollection<Quiz> Quizzes { get; set; } = new List<Quiz>(); // Navigationseigenschaft für Quiz
}
