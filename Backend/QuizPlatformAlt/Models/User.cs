using System.ComponentModel.DataAnnotations.Schema;

[Table("Users")]
public class User
{
    [PrimaryKey("id")]
    public Guid Id { get; set; }
    
    [Column("username")]
    public string Username { get; set; }
    
    [Column("email")]
    public string Email { get; set; }
    
    [Column("password")]
    public string Password { get; set; }
}