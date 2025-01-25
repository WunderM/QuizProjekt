using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuizPlatform_API.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Highscore> Highscores { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<QuizCategory> QuizCategorys { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("User Id=postgres;Password=quiz;Server=db.dafrqudbuzywgwgyqcuh.supabase.co;Port=5432;Database=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<QuizCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("QuizCategory_pkey");

            entity.ToTable("quiz_category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasColumnName("title")
                .HasColumnType("character varying");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("createdAt");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Quiz_pkey");

            entity.ToTable("quiz");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Title)
                .HasColumnName("title")
                .HasColumnType("character varying");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");

            entity.HasOne(d => d.Category)
                .WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("quiz_category_fkey");
        });

        modelBuilder.Entity<Highscore>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Highscore_pkey");

            entity.ToTable("highscore");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.NumberOfQuestions).HasColumnName("number_of_questions");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.QuizId).HasColumnName("quiz_id");

            entity.HasOne(d => d.UserNavigation)
                .WithMany(p => p.Highscores)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("highscore_user_fkey");

            entity.HasOne(d => d.QuizNavigation)
                .WithMany(p => p.Highscores)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("highscore_quiz_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("User_pkey");

            entity.ToTable("user");

            entity.HasIndex(e => e.Username, "user_username_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.LastLogin)
                .HasColumnName("last_login")
                .HasColumnType("timestamp with time zone");
            entity.Property(e => e.Username)
                .HasColumnName("username")
                .HasColumnType("character varying");
            entity.Property(e => e.PasswordHash)
                .HasColumnName("password_hash")
                .HasColumnType("character varying");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
