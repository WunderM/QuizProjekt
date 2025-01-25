using System.ComponentModel.DataAnnotations.Schema;

[Table("Highscore")]
public class Highscore
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }
    
    [Column("user_id")]
    public Guid UserId { get; set; }
    
    [Column("quiz_id")]
    public Guid QuizId { get; set; }
    
    [Column("score")]
    public int Score { get; set; }

    [Column("number_of_questions")]
    public int NumberOfQuestions { get; set; }
}