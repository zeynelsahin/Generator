using Generator.Entities;
using Microsoft.EntityFrameworkCore;

namespace Generator.DataAccess.EntityFramework
{
    public class OracleContext : DbContext
    {
        public DbSet<ActionOption> ActionOptions { get; set; }
        public DbSet<StringOption> StringOptions { get; set; }
        public DbSet<ServiceOption> ServiceOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TABLE NAME
            modelBuilder.Entity<ActionOption>().ToTable("UX_ACTION_OPTION");
            modelBuilder.Entity<StringOption>().ToTable("UX_STRING_OPTION");
            modelBuilder.Entity<ServiceOption>().ToTable("UX_SERVICE_OPTION");

            //Primary Key
            modelBuilder.Entity<ActionOption>()
                .HasKey(o => new { o.DomainId, o.Environment, o.ApplicationId, o.ActionId });
            modelBuilder.Entity<StringOption>()
                .HasKey(o => new { o.LanguageId, o.KeyId });
            modelBuilder.Entity<ServiceOption>()
                .HasKey(o => new { o.DomainId, o.Environment, o.ServiceId });

            //Schema
            modelBuilder.HasDefaultSchema("CMS_CFG");


            //Action Option
            modelBuilder.Entity<ActionOption>().Property(s => s.DomainId).HasColumnName("DOMAIN_ID");
            modelBuilder.Entity<ActionOption>().Property(s => s.Environment).HasColumnName("ENVIRONMENT");
            modelBuilder.Entity<ActionOption>().Property(s => s.ApplicationId).HasColumnName("APPLICATION_ID");
            modelBuilder.Entity<ActionOption>().Property(s => s.ActionId).HasColumnName("ACTION_ID");
            modelBuilder.Entity<ActionOption>().Property(s => s.ServiceActionName).HasColumnName("SERVICE_ACTION_NAME");
            modelBuilder.Entity<ActionOption>().Property(s => s.Description).HasColumnName("DESCRIPTION");
            modelBuilder.Entity<ActionOption>().Property(s => s.ValidFlag).HasColumnName("VALID_FLAG");
            modelBuilder.Entity<ActionOption>().Property(s => s.ServiceId).HasColumnName("SERVICE_ID");

            //String Option
            modelBuilder.Entity<StringOption>().Property(s => s.LanguageId).HasColumnName("LANGUAGE_ID");
            modelBuilder.Entity<StringOption>().Property(s => s.KeyId).HasColumnName("KEY_ID");
            modelBuilder.Entity<StringOption>().Property(s => s.Value).HasColumnName("VALUE");

            //Service Option
            modelBuilder.Entity<ServiceOption>().Property(s => s.DomainId).HasColumnName("DOMAIN_ID");
            modelBuilder.Entity<ServiceOption>().Property(s => s.Environment).HasColumnName("ENVIRONMENT");
            modelBuilder.Entity<ServiceOption>().Property(s => s.ServiceId).HasColumnName("SERVICE_ID");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(
                @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=OracleServer)(PORT=1521))(CONNECT_DATA=(SID=ORCLSRV19)));User Id=CMS_APP_USER;Password=Panda1881");
        }
    }
}