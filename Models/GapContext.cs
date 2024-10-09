using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ApiGap.Models;

public partial class GapContext : DbContext
{
    public GapContext()
    {
    }

    public GapContext(DbContextOptions<GapContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Action> Actions { get; set; }

    public virtual DbSet<Actioncollaborator> Actioncollaborators { get; set; }

    public virtual DbSet<Actiontotechnology> Actiontotechnologies { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Collaborator> Collaborators { get; set; }

    public virtual DbSet<Collaboratortotechnology> Collaboratortotechnologies { get; set; }

    public virtual DbSet<Documentation> Documentations { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Meeting> Meetings { get; set; }

    public virtual DbSet<Pending> Pendings { get; set; }

    public virtual DbSet<Step> Steps { get; set; }

    public virtual DbSet<Technology> Technologies { get; set; }

    public virtual DbSet<Unity> Unities { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=gap;user=root;password=senha-mysql", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.0.1-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Action>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("action")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdUnity, "Action_idUnity_fkey");

            entity.Property(e => e.Id)
                .HasMaxLength(191)
                .HasColumnName("id");
            entity.Property(e => e.Avatar)
                .HasMaxLength(191)
                .HasColumnName("avatar");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime(3)")
                .HasColumnName("endDate");
            entity.Property(e => e.IdDocumentation)
                .HasMaxLength(191)
                .HasColumnName("idDocumentation");
            entity.Property(e => e.IdUnity)
                .HasMaxLength(191)
                .HasColumnName("idUnity");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime(3)")
                .HasColumnName("startDate");
            entity.Property(e => e.Status)
                .HasColumnType("enum('STARTED','FINISHED','IN_PROGRESS','PAUSED','CANCELED')")
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasColumnType("enum('DEVELOPMENT','ACTIVITY')")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.IdUnityNavigation).WithMany(p => p.Actions)
                .HasForeignKey(d => d.IdUnity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Action_idUnity_fkey");
        });

        modelBuilder.Entity<Actioncollaborator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("actioncollaborator")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdAction, "ActionCollaborator_idAction_fkey");

            entity.HasIndex(e => e.IdCollaborator, "ActionCollaborator_idCollaborator_fkey");

            entity.HasIndex(e => e.IdUser, "ActionCollaborator_idUser_fkey");

            entity.Property(e => e.Id)
                .HasMaxLength(191)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.IdAction)
                .HasMaxLength(191)
                .HasColumnName("idAction");
            entity.Property(e => e.IdCollaborator)
                .HasMaxLength(191)
                .HasColumnName("idCollaborator");
            entity.Property(e => e.IdUser)
                .HasMaxLength(191)
                .HasColumnName("idUser");
            entity.Property(e => e.Responsability)
                .HasColumnType("enum('DESIGNER','DEVELOPER','SUPERVISOR','SUPPORT')")
                .HasColumnName("responsability");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.IdActionNavigation).WithMany(p => p.Actioncollaborators)
                .HasForeignKey(d => d.IdAction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ActionCollaborator_idAction_fkey");

            entity.HasOne(d => d.IdCollaboratorNavigation).WithMany(p => p.Actioncollaborators)
                .HasForeignKey(d => d.IdCollaborator)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ActionCollaborator_idCollaborator_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Actioncollaborators)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ActionCollaborator_idUser_fkey");
        });

        modelBuilder.Entity<Actiontotechnology>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_actiontotechnology")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.A, e.B }, "_ActionToTechnology_AB_unique").IsUnique();

            entity.HasIndex(e => e.B, "_ActionToTechnology_B_index");

            entity.Property(e => e.A).HasMaxLength(191);
            entity.Property(e => e.B).HasMaxLength(191);

            entity.HasOne(d => d.ANavigation).WithMany()
                .HasForeignKey(d => d.A)
                .HasConstraintName("_ActionToTechnology_A_fkey");

            entity.HasOne(d => d.BNavigation).WithMany()
                .HasForeignKey(d => d.B)
                .HasConstraintName("_ActionToTechnology_B_fkey");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("address")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .HasMaxLength(191)
                .HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(191)
                .HasColumnName("city");
            entity.Property(e => e.Complement)
                .HasMaxLength(191)
                .HasColumnName("complement");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.District)
                .HasMaxLength(191)
                .HasColumnName("district");
            entity.Property(e => e.Number)
                .HasMaxLength(191)
                .HasColumnName("number");
            entity.Property(e => e.State)
                .HasMaxLength(191)
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .HasMaxLength(191)
                .HasColumnName("street");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("updatedAt");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(191)
                .HasColumnName("zipCode");
        });

        modelBuilder.Entity<Collaborator>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("collaborator")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdAddress, "Collaborator_idAddress_fkey");

            entity.HasIndex(e => e.IdUser, "Collaborator_idUser_fkey");

            entity.Property(e => e.Id)
                .HasMaxLength(191)
                .HasColumnName("id");
            entity.Property(e => e.AcademicFormation)
                .HasMaxLength(191)
                .HasColumnName("academicFormation");
            entity.Property(e => e.AcademicInstitution)
                .HasMaxLength(191)
                .HasColumnName("academicInstitution");
            entity.Property(e => e.AdmissionDate)
                .HasColumnType("datetime(3)")
                .HasColumnName("admissionDate");
            entity.Property(e => e.ConclusionYear).HasColumnName("conclusionYear");
            entity.Property(e => e.Cpf)
                .HasMaxLength(191)
                .HasColumnName("cpf");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime(3)")
                .HasColumnName("dateOfBirth");
            entity.Property(e => e.IdAddress)
                .HasMaxLength(191)
                .HasColumnName("idAddress");
            entity.Property(e => e.IdUser)
                .HasMaxLength(191)
                .HasColumnName("idUser");
            entity.Property(e => e.Phone)
                .HasMaxLength(191)
                .HasColumnName("phone");
            entity.Property(e => e.ResignationDate)
                .HasColumnType("datetime(3)")
                .HasColumnName("resignationDate");
            entity.Property(e => e.Rg)
                .HasMaxLength(191)
                .HasColumnName("rg");
            entity.Property(e => e.StudyArea)
                .HasMaxLength(191)
                .HasColumnName("studyArea");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.IdAddressNavigation).WithMany(p => p.Collaborators)
                .HasForeignKey(d => d.IdAddress)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Collaborator_idAddress_fkey");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Collaborators)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Collaborator_idUser_fkey");
        });

        modelBuilder.Entity<Collaboratortotechnology>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("_collaboratortotechnology")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => new { e.A, e.B }, "_CollaboratorToTechnology_AB_unique").IsUnique();

            entity.HasIndex(e => e.B, "_CollaboratorToTechnology_B_index");

            entity.Property(e => e.A).HasMaxLength(191);
            entity.Property(e => e.B).HasMaxLength(191);

            entity.HasOne(d => d.ANavigation).WithMany()
                .HasForeignKey(d => d.A)
                .HasConstraintName("_CollaboratorToTechnology_A_fkey");

            entity.HasOne(d => d.BNavigation).WithMany()
                .HasForeignKey(d => d.B)
                .HasConstraintName("_CollaboratorToTechnology_B_fkey");
        });

        modelBuilder.Entity<Documentation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("documentation")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdAction, "Documentation_idAction_fkey");

            entity.Property(e => e.Id)
                .HasMaxLength(191)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.IdAction)
                .HasMaxLength(191)
                .HasColumnName("idAction");
            entity.Property(e => e.Report)
                .HasMaxLength(191)
                .HasColumnName("report");
            entity.Property(e => e.RequirementsGathering)
                .HasMaxLength(191)
                .HasColumnName("requirementsGathering");
            entity.Property(e => e.SatisfactionIndex)
                .HasMaxLength(191)
                .HasColumnName("satisfactionIndex");
            entity.Property(e => e.TechnicalDocumentation)
                .HasMaxLength(191)
                .HasColumnName("technicalDocumentation");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UsabilityManual)
                .HasMaxLength(191)
                .HasColumnName("usabilityManual");

            entity.HasOne(d => d.IdActionNavigation).WithMany(p => p.Documentations)
                .HasForeignKey(d => d.IdAction)
                .HasConstraintName("Documentation_idAction_fkey");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("log")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdUser, "Log_idUser_fkey");

            entity.Property(e => e.Id)
                .HasMaxLength(191)
                .HasColumnName("id");
            entity.Property(e => e.Action)
                .HasColumnType("enum('CREATE','UPDATE','DELETE')")
                .HasColumnName("action");
            entity.Property(e => e.ColumnName)
                .HasMaxLength(191)
                .HasColumnName("columnName");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.IdObject)
                .HasMaxLength(191)
                .HasColumnName("idObject");
            entity.Property(e => e.IdUser)
                .HasMaxLength(191)
                .HasColumnName("idUser");
            entity.Property(e => e.NewValue)
                .HasMaxLength(191)
                .HasColumnName("newValue");
            entity.Property(e => e.OldValue)
                .HasMaxLength(191)
                .HasColumnName("oldValue");
            entity.Property(e => e.TableName)
                .HasMaxLength(191)
                .HasColumnName("tableName");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Logs)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Log_idUser_fkey");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("login")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdUser, "Login_idUser_fkey");

            entity.Property(e => e.Id)
                .HasMaxLength(191)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.IdUser)
                .HasMaxLength(191)
                .HasColumnName("idUser");
            entity.Property(e => e.IpUser)
                .HasMaxLength(191)
                .HasColumnName("ipUser");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Logins)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Login_idUser_fkey");
        });

        modelBuilder.Entity<Meeting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("meeting")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdAction, "Meeting_idAction_fkey");

            entity.Property(e => e.Id)
                .HasMaxLength(191)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.Date)
                .HasColumnType("datetime(3)")
                .HasColumnName("date");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IdAction)
                .HasMaxLength(191)
                .HasColumnName("idAction");
            entity.Property(e => e.Topic).HasColumnName("topic");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.IdActionNavigation).WithMany(p => p.Meetings)
                .HasForeignKey(d => d.IdAction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Meeting_idAction_fkey");
        });

        modelBuilder.Entity<Pending>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("pending")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdMeeting, "Pending_idMeeting_fkey");

            entity.Property(e => e.Id)
                .HasMaxLength(191)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.IdMeeting)
                .HasMaxLength(191)
                .HasColumnName("idMeeting");
            entity.Property(e => e.PendingDescription).HasColumnName("pendingDescription");
            entity.Property(e => e.Status)
                .HasColumnType("enum('PENDING','FINISHED','NO_PENDING')")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.IdMeetingNavigation).WithMany(p => p.Pendings)
                .HasForeignKey(d => d.IdMeeting)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Pending_idMeeting_fkey");
        });

        modelBuilder.Entity<Step>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("step")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.IdAction, "Step_idAction_fkey");

            entity.Property(e => e.Id)
                .HasMaxLength(191)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.IdAction)
                .HasMaxLength(191)
                .HasColumnName("idAction");
            entity.Property(e => e.IsChecked).HasColumnName("isChecked");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasColumnType("enum('PENDING','IN_PROGRESS','FINISHED')")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.IdActionNavigation).WithMany(p => p.Steps)
                .HasForeignKey(d => d.IdAction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Step_idAction_fkey");
        });

        modelBuilder.Entity<Technology>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("technology")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .HasMaxLength(191)
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<Unity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("unity")
                .UseCollation("utf8mb4_unicode_ci");

            entity.Property(e => e.Id)
                .HasMaxLength(191)
                .HasColumnName("id");
            entity.Property(e => e.Alias)
                .HasMaxLength(191)
                .HasColumnName("alias");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("user")
                .UseCollation("utf8mb4_unicode_ci");

            entity.HasIndex(e => e.Email, "User_email_key").IsUnique();

            entity.HasIndex(e => e.IdUnity, "User_idUnity_fkey");

            entity.Property(e => e.Id)
                .HasMaxLength(191)
                .HasColumnName("id");
            entity.Property(e => e.Avatar)
                .HasMaxLength(191)
                .HasColumnName("avatar");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP(3)")
                .HasColumnType("datetime(3)")
                .HasColumnName("createdAt");
            entity.Property(e => e.Email)
                .HasMaxLength(191)
                .HasColumnName("email");
            entity.Property(e => e.IdUnity)
                .HasMaxLength(191)
                .HasColumnName("idUnity");
            entity.Property(e => e.Job)
                .HasMaxLength(191)
                .HasColumnName("job");
            entity.Property(e => e.Name)
                .HasMaxLength(191)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(191)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasColumnType("enum('DEFAULT','COLLABORATOR')")
                .HasColumnName("role");
            entity.Property(e => e.Status)
                .HasColumnType("enum('ACTIVE','INACTIVE','LICENSE','VACATION')")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime(3)")
                .HasColumnName("updatedAt");

            entity.HasOne(d => d.IdUnityNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdUnity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("User_idUnity_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
