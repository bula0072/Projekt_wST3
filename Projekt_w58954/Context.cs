using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_w58954
{
    public class Context : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Przedmiot> Przedmiots { get; set; }
        public DbSet<Student_Przedmiot> Student_Przedmiots { get; set; }

        public Context(DbContextOptions optionsBuilder) : base(optionsBuilder) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(m =>
            {
                m.ToTable("Student");
                m.HasKey(x => x.Id);
            });


            modelBuilder.Entity<Przedmiot>(m =>
            {
                m.ToTable("Przedmiot");
                m.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Student_Przedmiot>(m =>
            {
                m.ToTable("Student_Przedmiot");
                m.HasKey(x => x.Id);
            });

            modelBuilder.Entity<Student_Przedmiot>().HasOne(pt => pt.Student).WithMany(t => t.Student_Przedmiots).HasForeignKey(pt => pt.Student_id);
            modelBuilder.Entity<Student_Przedmiot>().HasOne(pt => pt.Przedmiot).WithMany(t => t.Student_Przedmiots).HasForeignKey(pt => pt.Przedmiot_id);
        }
    }
}
