﻿namespace EfCodeFirst.Models;

public class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public virtual ICollection<StudentGroup> StudentGroups { get; set; }
}