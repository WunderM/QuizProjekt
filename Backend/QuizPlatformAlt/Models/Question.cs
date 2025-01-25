using System.ComponentModel.DataAnnotations.Schema;

using Postgrest.Attributes;

[Table("Question")]
public class Question
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }
    
    [Column("quiz_id")]
    public Guid QuizId { get; set; }
    
    [Column("question_text")]
    public string QuestionText { get; set; }
    
    [Column("answer")]
    public string Answer { get; set; }
    
    [Column("answerfalse_one")]
    public string AnswerFalseOne { get; set; }

    [Column("answer_false_two")]
    public string AnswerFalseTwo { get; set; }

    [Column("answer_false_three")]
    public string AnswerFalseThree { get; set; }

    [Column("hint")]
    public string Hint { get; set; }
}