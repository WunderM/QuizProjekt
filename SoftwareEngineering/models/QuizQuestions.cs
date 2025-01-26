using System.Collections.Generic;
using System.Text.Json.Serialization;

public class QuizQuestion
{
    public long Id { get; set; }
    public string Question { get; set; }

    [JsonConverter(typeof(NestedValuesConverter))]
    public List<string> Answers { get; set; }
}