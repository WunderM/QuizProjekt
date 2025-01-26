using System.Collections.Generic;
using System.Text.Json.Serialization;

public class QuizQuestionWrapper
{
    [JsonPropertyName("$values")]
    public List<QuizQuestion> Questions { get; set; }
}
