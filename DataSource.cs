using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FinalExam.Models
{
    public partial class DataSource : DbContext
    {
        public DataSource()
            : base("name=DataSource")
        {
        }

        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<database_firewall_rules> database_firewall_rules { get; set; }
        public virtual DbSet<ipv6_database_firewall_rules> ipv6_database_firewall_rules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Division>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Division)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Team>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.start_ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<database_firewall_rules>()
                .Property(e => e.end_ip_address)
                .IsUnicode(false);

            modelBuilder.Entity<ipv6_database_firewall_rules>()
                .Property(e => e.start_ipv6_address)
                .IsUnicode(false);

            modelBuilder.Entity<ipv6_database_firewall_rules>()
                .Property(e => e.end_ipv6_address)
                .IsUnicode(false);
        }
    }
}
