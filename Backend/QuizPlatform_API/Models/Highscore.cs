using System;
using System.Collections.Generic;

namespace QuizPlatform_API.Models;

public partial class Highscore
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Standardwert setzen

    public int Score { get; set; } = 0;// `null!` entfernt, da es nicht nullable ist

    public int NumberOfQuestions { get; set; } = 0;// `null!` entfernt, da es nicht nullable ist

    public long UserId { get; set; } // Klarer benannt für Konsistenz (ohne Nullable)

    public long QuizId { get; set; } // Klarer benannt für Konsistenz (ohne Nullable)

    public virtual User UserNavigation { get; set; } = null!; // Navigationseigenschaft, `null!` für zwingenden Bezug

    public virtual Quiz QuizNavigation { get; set; } = null!; // Navigationseigenschaft, `null!` für zwingenden Bezug
}
