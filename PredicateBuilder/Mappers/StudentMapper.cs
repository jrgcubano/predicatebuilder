using PredicateBuilder.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace PredicateBuilder.Mappers
{

    class StudentMapper : EntityTypeConfiguration<Student>
    {
        public StudentMapper()
        {
            this.ToTable("Students");              
            this.HasKey(s => s.Id);
            this.Property(s => s.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(s => s.Id).IsRequired();
            this.Property(s => s.Id).HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("Index1")));

            this.Property(s => s.UserName).IsRequired();
            //this.Property(s => s.UserName).HasMaxLength(50);
            this.Property(s => s.UserName).IsUnicode(false);


            this.Property(s => s.Email).IsRequired();
            //this.Property(s => s.Email).HasMaxLength(255);
            this.Property(s => s.Email).IsUnicode(false);
         
            this.Property(s => s.FirstName).IsRequired();
            //this.Property(s => s.FirstName).HasMaxLength(50);

            this.Property(s => s.LastName).IsRequired();
            //this.Property(s => s.LastName).HasMaxLength(50);

            this.Property(s => s.DateOfBirth).IsRequired();
            this.Property(s => s.DateOfBirth).HasColumnType("smalldatetime");
        }        
    }
}
