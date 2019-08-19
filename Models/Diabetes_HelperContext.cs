using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Diabeatit.Models
{
    public partial class Diabetes_HelperContext : DbContext
    {
        public Diabetes_HelperContext()
        {
        }

        public Diabetes_HelperContext(DbContextOptions<Diabetes_HelperContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BloodSugarRange> BloodSugarRange { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<InsulinDosage> InsulinDosage { get; set; }
        public virtual DbSet<LogBook> LogBook { get; set; }
        public virtual DbSet<MealRoutine> MealRoutine { get; set; }
        public virtual DbSet<Medicine> Medicine { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<UserSetting> UserSetting { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=Diabetes_Helper;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<BloodSugarRange>(entity =>
            {
                entity.ToTable("Blood_Sugar_Range");

                entity.Property(e => e.BloodSugarRangeId).HasColumnName("Blood_Sugar_Range_ID");

                entity.Property(e => e.BloodSugarRangeFrom).HasColumnName("Blood_Sugar_Range_From");

                entity.Property(e => e.BloodSugarRangeTo).HasColumnName("Blood_Sugar_Range_To");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.CityId)
                    .HasColumnName("City_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasColumnName("City_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.CountryId).HasColumnName("Country_ID");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId)
                    .HasColumnName("Country_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasColumnName("Country_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<InsulinDosage>(entity =>
            {
                entity.HasKey(e => new { e.DosageId, e.UserId });

                entity.ToTable("Insulin_Dosage");

                entity.Property(e => e.DosageId).HasColumnName("Dosage_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.BloodSugarRangeId).HasColumnName("Blood_Sugar_Range_ID");

                entity.Property(e => e.InsulinDosage1).HasColumnName("Insulin_Dosage");
            });

            modelBuilder.Entity<LogBook>(entity =>
            {
                entity.HasKey(e => new { e.LogBookId, e.UserId });

                entity.ToTable("Log_Book");

                entity.Property(e => e.LogBookId)
                    .HasColumnName("Log_Book_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.LogDate)
                    .HasColumnName("Log_Date")
                    .HasColumnType("date");

                entity.Property(e => e.LogNotes)
                    .HasColumnName("Log_Notes")
                    .HasColumnType("ntext");

                entity.Property(e => e.LogTime).HasColumnName("Log_Time");

                entity.Property(e => e.MeterReading).HasColumnName("Meter_Reading");

                entity.Property(e => e.RoutineId).HasColumnName("Routine_ID");
            });

            modelBuilder.Entity<MealRoutine>(entity =>
            {
                entity.HasKey(e => new { e.RoutineId, e.UserId });

                entity.ToTable("Meal_Routine");

                entity.Property(e => e.RoutineId)
                    .HasColumnName("Routine_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.FromDate)
                    .HasColumnName("From_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ToDate)
                    .HasColumnName("To_Date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.Property(e => e.MedicineId).HasColumnName("Medicine_ID");

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasColumnName("Medicine_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => new { e.ScheduleId, e.UserId });

                entity.Property(e => e.ScheduleId)
                    .HasColumnName("Schedule_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.FromDate)
                    .HasColumnName("From_Date")
                    .HasColumnType("date");

                entity.Property(e => e.ToDate)
                    .HasColumnName("To_Date")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.Property(e => e.SettingId)
                    .HasColumnName("Setting_ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.SettingKey)
                    .IsRequired()
                    .HasColumnName("Setting_Key")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserSetting>(entity =>
            {
                entity.HasKey(e => new { e.SettingId, e.UserId });

                entity.ToTable("User_Setting");

                entity.Property(e => e.SettingId)
                    .HasColumnName("Setting_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.SettingKey).HasColumnName("Setting_Key");

                entity.Property(e => e.SettingValue)
                    .IsRequired()
                    .HasColumnName("Setting_Value")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.CellPhone)
                    .HasColumnName("Cell_Phone")
                    .HasMaxLength(20);

                entity.Property(e => e.CityId).HasColumnName("City_ID");

                entity.Property(e => e.CountryId).HasColumnName("Country_ID");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("Date_of_Birth")
                    .HasColumnType("date");

                entity.Property(e => e.DiabetesType).HasColumnName("Diabetes_Type");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstDiagnosed)
                    .HasColumnName("First_Diagnosed")
                    .HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.LastActivity)
                    .HasColumnName("Last_Activity")
                    .HasColumnType("date");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.MedicineId).HasColumnName("Medicine_ID");
            });
        }
    }
}
