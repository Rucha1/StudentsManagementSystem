namespace StudentManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudentContext : DbContext
    {
        public StudentContext()
            : base("name=StudentContext")
        {
        }

        public DbSet<Division> division { get; set; }
        public DbSet<Standard> standard { get; set; }
        public DbSet<Subjects> subjects { get; set; }
        public DbSet<Students> students { get; set; }
        public DbSet<Marks> marks { get; set; }

    }
    public class ToDoDBCreator : DropCreateDatabaseIfModelChanges<StudentContext>
    {

    }
}
