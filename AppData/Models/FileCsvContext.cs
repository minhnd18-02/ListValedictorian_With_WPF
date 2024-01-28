using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppData.Models;

public partial class FileCsvContext : DbContext
{
    public FileCsvContext()
    {
    }

    public FileCsvContext(DbContextOptions<FileCsvContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MarkReport> MarkReports { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<Score> Scores { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost; Database=FileCsv; Username=postgres; Password=12345678");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MarkReport>(entity =>
        {
            entity.HasKey(e => e.Sbd);

            entity.Property(e => e.Gdcd).HasColumnName("GDCD");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.ProvinceId).HasName("province_pkey");

            entity.ToTable("province");

            entity.Property(e => e.ProvinceId)
                .ValueGeneratedNever()
                .HasColumnName("province_id");
            entity.Property(e => e.ProvinceName)
                .HasMaxLength(255)
                .HasColumnName("province_name");
        });

        modelBuilder.Entity<Score>(entity =>
        {
            entity.HasKey(e => e.ScoreId).HasName("score_pkey");

            entity.ToTable("score");

            entity.Property(e => e.ScoreId)
                .ValueGeneratedNever()
                .HasColumnName("score_id");
            entity.Property(e => e.Score1).HasColumnName("score");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("student_pkey");

            entity.ToTable("student");

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("student_id");
            entity.Property(e => e.ProvinceId).HasColumnName("province_id");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("subject_pkey");

            entity.ToTable("subject");

            entity.Property(e => e.SubjectId)
                .ValueGeneratedNever()
                .HasColumnName("subject_id");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(255)
                .HasColumnName("subject_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
