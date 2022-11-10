using Generator.Entities;
using Microsoft.EntityFrameworkCore;

namespace Generator.DataAccess.EntityFramework
{
    public class OracleContext : DbContext
    {
        public DbSet<ActionOption> ActionOptions { get; set; }
        public DbSet<StringOption> StringOptions { get; set; }
        public DbSet<ServiceOption> ServiceOptions { get; set; }
        public DbSet<MenuOption> MenuOptions { get; set; }
        public DbSet<PageOption> PageOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TABLE NAME
            modelBuilder.Entity<ActionOption>().ToTable("UX_ACTION_OPTION");
            modelBuilder.Entity<StringOption>().ToTable("UX_STRING_OPTION");
            modelBuilder.Entity<ServiceOption>().ToTable("UX_SERVICE_OPTION");
            modelBuilder.Entity<MenuOption>().ToTable("UX_MENU_OPTION");
            modelBuilder.Entity<PageOption>().ToTable("UX_PAGE_OPTION");

            //Primary Key
            modelBuilder.Entity<ActionOption>()
                .HasKey(o => new { o.DomainId, o.Environment, o.ApplicationId, o.ActionId });
            modelBuilder.Entity<StringOption>()
                .HasKey(o => new { o.LanguageId, o.KeyId });
            modelBuilder.Entity<ServiceOption>()
                .HasKey(o => new { o.DomainId, o.Environment, o.ServiceId });
            modelBuilder.Entity<MenuOption>().HasKey(o => new { o.DomainId, o.Environment, o.ApplicationId, o.MenuId });
            modelBuilder.Entity<PageOption>().HasKey(o => new { o.DomainId, o.Environment, o.ApplicationId, o.PageId });

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

            //Menu Option
            modelBuilder.Entity<MenuOption>().Property(s => s.DomainId).HasColumnName("DOMAIN_ID");
            modelBuilder.Entity<MenuOption>().Property(s => s.Environment).HasColumnName("ENVIRONMENT");
            modelBuilder.Entity<MenuOption>().Property(s => s.ApplicationId).HasColumnName("APPLICATION_ID");
            modelBuilder.Entity<MenuOption>().Property(s => s.MenuId).HasColumnName("MENU_ID");
            modelBuilder.Entity<MenuOption>().Property(s => s.ParentMenuId).HasColumnName("PARENT_MENU_ID");
            modelBuilder.Entity<MenuOption>().Property(s => s.PageId).HasColumnName("PAGE_ID");
            modelBuilder.Entity<MenuOption>().Property(s => s.Name).HasColumnName("NAME");
            modelBuilder.Entity<MenuOption>().Property(s => s.Icon).HasColumnName("ICON");
            modelBuilder.Entity<MenuOption>().Property(s => s.SortId).HasColumnName("SORT_ID");
            modelBuilder.Entity<MenuOption>().Property(s => s.ValidFlag).HasColumnName("VALID_FLAG");
            
            //PageOption
            modelBuilder.Entity<PageOption>().Property(s => s.DomainId).HasColumnName("DOMAIN_ID");
            modelBuilder.Entity<PageOption>().Property(s => s.Environment).HasColumnName("ENVIRONMENT");
            modelBuilder.Entity<PageOption>().Property(s => s.ApplicationId).HasColumnName("APPLICATION_ID");
            modelBuilder.Entity<PageOption>().Property(s => s.PageId).HasColumnName("PAGE_ID");
            modelBuilder.Entity<PageOption>().Property(s => s.Name).HasColumnName("NAME");
            modelBuilder.Entity<PageOption>().Property(s => s.ValidFlag).HasColumnName("VALID_FLAG");

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