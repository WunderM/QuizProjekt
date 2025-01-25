using System.ComponentModel.DataAnnotations.Schema;

[Table("Quiz")]
public class Quiz
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }
    
    [Column("title")]
    public string Title { get; set; }
    
    [Column("category_id")]
    public Guid CategoryId { get; set; }
}