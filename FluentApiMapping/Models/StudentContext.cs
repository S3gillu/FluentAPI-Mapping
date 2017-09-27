using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FluentApiMapping.Models
{
    public class StudentContext :DbContext
    {
        public StudentContext() : base("name=Stu_Connect")
        {

        }
        public DbSet<NewStudent>NewStudents{ get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("Stu");

               // One-to-zero
                modelBuilder.Entity<NewStudent>()
                    .HasKey(e => e.StudentId)
                  .HasOptional(s => s.Address)
                  .WithRequired(ad => ad.NewStudent); 
               // Configure StudentId as PK for StudentAddress
                modelBuilder.Entity<StudentAddress>()
                    .HasKey(e => e.StudentId);

                // Configure StudentId as FK for StudentAddress
                modelBuilder.Entity<NewStudent>()
                            .HasRequired(s => s.Address)
                            .WithRequiredPrincipal(ad => ad.NewStudent);


           




        }


    }
}