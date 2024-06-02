using EfCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCodeFirst.EfConfigurations;

public class StudentGroupEfConfiguration : IEntityTypeConfiguration<StudentGroup>
{
    public void Configure(EntityTypeBuilder<StudentGroup> builder)
    {
        builder.ToTable("Student_Group");

        builder.HasKey(sg => new { sg.IdGroup, sg.IdStudent });

        builder.HasOne<Student>(sg => sg.IdStudentNavigation)
            .WithMany(s => s.StudentGroups)
            .HasForeignKey(sg => sg.IdStudent);

        builder.HasOne<Group>(sg => sg.IdGroupNavigation)
            .WithMany(g => g.StudentGroups)
            .HasForeignKey(sg => sg.IdGroup);
    }
}