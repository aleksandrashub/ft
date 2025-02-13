using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using demoMatModel1.Models;

namespace demoMatModel1.Context;

public partial class User018Context : DbContext
{
    public User018Context()
    {
    }

    public User018Context(DbContextOptions<User018Context> options)
        : base(options)
    {
    }

    public virtual DbSet<AbsenceCalendar> AbsenceCalendars { get; set; }

    public virtual DbSet<Dolzhnost> Dolzhnosts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Podrazd> Podrazds { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StatusMater> StatusMaters { get; set; }

    public virtual DbSet<Models.Type> Types { get; set; }

    public virtual DbSet<TypeMater> TypeMaters { get; set; }

    public virtual DbSet<VacationCalendar> VacationCalendars { get; set; }

    public virtual DbSet<Workingcalendar> Workingcalendars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=89.110.53.87;Port=5522;Database=user018;Username=user018;Password=59328");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AbsenceCalendar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("absence_calendar_pk");

            entity.ToTable("absence_calendar", "podrazdelenie");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Cause)
                .HasColumnType("character varying")
                .HasColumnName("cause");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.IdEmpl).HasColumnName("id_empl");

            entity.HasOne(d => d.IdEmplNavigation).WithMany(p => p.AbsenceCalendars)
                .HasForeignKey(d => d.IdEmpl)
                .HasConstraintName("absence_calendar_employee_fk");
        });

        modelBuilder.Entity<Dolzhnost>(entity =>
        {
            entity.HasKey(e => e.IdDolzh).HasName("dolzhnost_pk");

            entity.ToTable("dolzhnost", "podrazdelenie");

            entity.Property(e => e.IdDolzh)
                .ValueGeneratedNever()
                .HasColumnName("id_dolzh");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.IdEmp).HasName("employee_pk");

            entity.ToTable("employee", "podrazdelenie");

            entity.Property(e => e.IdEmp)
                .ValueGeneratedNever()
                .HasColumnName("id_emp");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Cabinet)
                .HasColumnType("character varying")
                .HasColumnName("cabinet");
            entity.Property(e => e.Fio)
                .HasColumnType("character varying")
                .HasColumnName("fio");
            entity.Property(e => e.IdDolzhnost).HasColumnName("id_dolzhnost");
            entity.Property(e => e.IdPodrazd).HasColumnName("id_podrazd");
            entity.Property(e => e.IdPomoshnik).HasColumnName("id_pomoshnik");
            entity.Property(e => e.IdRukvod).HasColumnName("id_rukvod");
            entity.Property(e => e.LichnPhone)
                .HasColumnType("character varying")
                .HasColumnName("lichn_phone");
            entity.Property(e => e.Mail)
                .HasColumnType("character varying")
                .HasColumnName("mail");
            entity.Property(e => e.RabPhone)
                .HasColumnType("character varying")
                .HasColumnName("rab_phone");

            entity.HasOne(d => d.IdDolzhnostNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdDolzhnost)
                .HasConstraintName("employee_dolzhnost_fk");

            entity.HasOne(d => d.IdPodrazdNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdPodrazd)
                .HasConstraintName("employee_podrazd_fk");

            entity.HasOne(d => d.IdPomoshnikNavigation).WithMany(p => p.InverseIdPomoshnikNavigation)
                .HasForeignKey(d => d.IdPomoshnik)
                .HasConstraintName("employee_employee1_fk");

            entity.HasOne(d => d.IdRukvodNavigation).WithMany(p => p.InverseIdRukvodNavigation)
                .HasForeignKey(d => d.IdRukvod)
                .HasConstraintName("employee_employee_fk");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("event_pk");

            entity.ToTable("event", "podrazdelenie");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateBegin).HasColumnName("date_begin");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.Descr)
                .HasColumnType("character varying")
                .HasColumnName("descr");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("event_status_fk");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.IdType)
                .HasConstraintName("event_type_fk");

            entity.HasMany(d => d.IdEmployees).WithMany(p => p.IdEvents)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployerEducation",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("IdEmployee")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("education_calendar_employee_fk"),
                    l => l.HasOne<Event>().WithMany()
                        .HasForeignKey("IdEvent")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("employer_education_event_fk"),
                    j =>
                    {
                        j.HasKey("IdEvent", "IdEmployee").HasName("employer_education_pk");
                        j.ToTable("employer_education", "podrazdelenie");
                        j.IndexerProperty<int>("IdEvent").HasColumnName("id_event");
                        j.IndexerProperty<int>("IdEmployee").HasColumnName("id_employee");
                    });

            entity.HasMany(d => d.IdEmployers).WithMany(p => p.IdEventsNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "EventResponsPer",
                    r => r.HasOne<Employee>().WithMany()
                        .HasForeignKey("IdEmployer")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("event_respons_pers_employee_fk"),
                    l => l.HasOne<Event>().WithMany()
                        .HasForeignKey("IdEvent")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("event_respons_pers_event_fk"),
                    j =>
                    {
                        j.HasKey("IdEvent", "IdEmployer").HasName("event_respons_pers_pk");
                        j.ToTable("event_respons_pers", "podrazdelenie");
                        j.IndexerProperty<int>("IdEvent").HasColumnName("id_event");
                        j.IndexerProperty<int>("IdEmployer").HasColumnName("id_employer");
                    });
        });

        modelBuilder.Entity<Material>(entity =>
        {
            entity.HasKey(e => e.IdMaterial).HasName("material_pk");

            entity.ToTable("material", "podrazdelenie");

            entity.Property(e => e.IdMaterial)
                .ValueGeneratedNever()
                .HasColumnName("id_material");
            entity.Property(e => e.DateIzmenen).HasColumnName("date_izmenen");
            entity.Property(e => e.DateUtverzhd).HasColumnName("date_utverzhd");
            entity.Property(e => e.IdAuthor).HasColumnName("id_author");
            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.IdType).HasColumnName("id_type");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Oblast)
                .HasColumnType("character varying")
                .HasColumnName("oblast");

            entity.HasOne(d => d.IdAuthorNavigation).WithMany(p => p.Materials)
                .HasForeignKey(d => d.IdAuthor)
                .HasConstraintName("material_employee_fk");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Materials)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("material_status_mater_fk");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Materials)
                .HasForeignKey(d => d.IdType)
                .HasConstraintName("material_type_mater_fk");
        });

        modelBuilder.Entity<Podrazd>(entity =>
        {
            entity.HasKey(e => e.IdPodrazd).HasName("podrazd_pk");

            entity.ToTable("podrazd", "podrazdelenie");

            entity.Property(e => e.IdPodrazd)
                .ValueGeneratedNever()
                .HasColumnName("id_podrazd");
            entity.Property(e => e.Descr)
                .HasColumnType("character varying")
                .HasColumnName("descr");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");

            entity.HasMany(d => d.IdAddedPodrazds).WithMany(p => p.IdPodrazds)
                .UsingEntity<Dictionary<string, object>>(
                    "PodrazdAdded",
                    r => r.HasOne<Podrazd>().WithMany()
                        .HasForeignKey("IdAddedPodrazd")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("podrazd_added_podrazd_fk_1"),
                    l => l.HasOne<Podrazd>().WithMany()
                        .HasForeignKey("IdPodrazd")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("podrazd_added_podrazd_fk"),
                    j =>
                    {
                        j.HasKey("IdPodrazd", "IdAddedPodrazd").HasName("podrazd_added_pk");
                        j.ToTable("podrazd_added", "podrazdelenie");
                        j.IndexerProperty<int>("IdPodrazd").HasColumnName("id_podrazd");
                        j.IndexerProperty<int>("IdAddedPodrazd").HasColumnName("id_added_podrazd");
                    });

            entity.HasMany(d => d.IdPodrazds).WithMany(p => p.IdAddedPodrazds)
                .UsingEntity<Dictionary<string, object>>(
                    "PodrazdAdded",
                    r => r.HasOne<Podrazd>().WithMany()
                        .HasForeignKey("IdPodrazd")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("podrazd_added_podrazd_fk"),
                    l => l.HasOne<Podrazd>().WithMany()
                        .HasForeignKey("IdAddedPodrazd")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("podrazd_added_podrazd_fk_1"),
                    j =>
                    {
                        j.HasKey("IdPodrazd", "IdAddedPodrazd").HasName("podrazd_added_pk");
                        j.ToTable("podrazd_added", "podrazdelenie");
                        j.IndexerProperty<int>("IdPodrazd").HasColumnName("id_podrazd");
                        j.IndexerProperty<int>("IdAddedPodrazd").HasColumnName("id_added_podrazd");
                    });
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_pk");

            entity.ToTable("status", "podrazdelenie");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<StatusMater>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("status_mater_pk");

            entity.ToTable("status_mater", "podrazdelenie");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Models.Type>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("type_pk");

            entity.ToTable("type", "podrazdelenie");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<TypeMater>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("type_mater_pk");

            entity.ToTable("type_mater", "podrazdelenie");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<VacationCalendar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("vacation_calendar_pk");

            entity.ToTable("vacation_calendar", "podrazdelenie");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateBegin).HasColumnName("date_begin");
            entity.Property(e => e.DateEnd).HasColumnName("date_end");
            entity.Property(e => e.IdEmpl).HasColumnName("id_empl");

            entity.HasOne(d => d.IdEmplNavigation).WithMany(p => p.VacationCalendars)
                .HasForeignKey(d => d.IdEmpl)
                .HasConstraintName("vacation_calendar_employee_fk");
        });

        modelBuilder.Entity<Workingcalendar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("workingcalendar_pk");

            entity.ToTable("workingcalendar", "podrazdelenie", tb => tb.HasComment("Список дней исключений в производственном календаре"));

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Exceptiondate)
                .HasComment("День-исключение")
                .HasColumnName("exceptiondate");
            entity.Property(e => e.Isworkingday)
                .HasComment("0 - будний день, но законодательно принят выходным; 1 - сб или вс, но является рабочим")
                .HasColumnName("isworkingday");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
