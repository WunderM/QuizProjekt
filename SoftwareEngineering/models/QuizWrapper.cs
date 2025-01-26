using System.Collections.Generic;
using System.Text.Json.Serialization;

public class QuizWrapper
{
    [JsonPropertyName("$values")]
    public List<Quiz> Quizzes { get; set; }
}
