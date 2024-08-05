using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventManagementSystem.Models;

public partial class ERSContext : IdentityDbContext<IdentityUser>
{
    public ERSContext()
    {
    }

    public ERSContext(DbContextOptions<ERSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendee> Attendees { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Attendee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Attendee");

            entity.ToTable("Attendee", "ERS");

            entity.HasIndex(e => e.Email, "UQ_Attendee_Email").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Event");

            entity.ToTable("Event", "ERS");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Organizer)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasKey(e => e.RegistrationId).HasName("PK_Registration");

            entity.ToTable("Registration", "ERS");

            entity.HasIndex(e => new { e.EventId, e.AttendeeId }, "UQ_Registration_Event_Attendee").IsUnique();

            entity.Property(e => e.AttendanceDate).HasColumnType("datetime");
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Attendee).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.AttendeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Registration_Attendee");

            entity.HasOne(d => d.Event).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Registration_Event");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
