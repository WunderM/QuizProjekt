using System.Collections.Generic;

public class AnswerSubmissionRequest
{
    public long UserId { get; set; }
    public long QuizId { get; set; }
    public List<AnswerSubmission> Answers { get; set; } = new();
}