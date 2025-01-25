using System.ComponentModel.DataAnnotations.Schema;

[Table("QuizCategory")]
public class QuizCategory
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
}