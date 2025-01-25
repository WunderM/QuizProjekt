using Microsoft.EntityFrameworkCore;
using QuizPlatform.Models;

namespace QuizPlatform.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Tabellen-Definitionen
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<QuizCategory> QuizCategories { get; set; }
        public DbSet<Highscore> Highscores { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Beispiel für Konfigurationen
            modelBuilder.Entity<Question>()
                .Property(q => q.QuestionText)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();
        }
    }
}