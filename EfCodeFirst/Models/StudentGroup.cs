namespace EfCodeFirst.Models;

public class StudentGroup
{
    public int IdStudent { get; set; }
    public int IdGroup { get; set; }
    
    public virtual Group IdGroupNavigation { get; set; }
    public virtual Student IdStudentNavigation { get; set; }
}