using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi.DBModels;

public partial class WebapiContext : DbContext
{
    public WebapiContext()
    {
    }

    public WebapiContext(DbContextOptions<WebapiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=webapi;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Companyname)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("companyname");
            entity.Property(e => e.Mobilenumber).HasColumnName("mobilenumber");
            entity.Property(e => e.Studentname)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("studentname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
