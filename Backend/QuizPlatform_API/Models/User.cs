using System;
using System.Collections.Generic;

namespace QuizPlatform_API.Models;

public partial class User
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Standardwert setzen

    public string Username { get; set; } = string.Empty; // Null vermeiden

    public string PasswordHash { get; set; } = string.Empty; // Hash statt Klartext verwenden
    public DateTime LastLogin { get; set; } // Optionales Feld für den letzten Login-Zeitpunkt


    public virtual ICollection<Highscore> Highscores { get; set; } = new List<Highscore>(); // Highscore-Verknüpfungen
}
