using System.Collections.Generic;

namespace pocoinheritance.Models
{
    public class Student : Person
{
    public Student()
    {
        Friends=new List<Person>();
    }
    public virtual List<Person> Friends { get; set; }
    public int StudentAge { get; set; }
}
}