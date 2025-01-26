using System.Collections.Generic;
using System.Text.Json.Serialization;

public class HighscoreWrapper
{
    [JsonPropertyName("$values")]
    public List<Highscore> Highscores { get; set; }
}
