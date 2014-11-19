namespace StudentSystem.Data
{
    using StudentSystem.Data.Repositories;
    using StudentSystem.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IStudentSystemData
    {
        IGenericRepository<Course> Courses { get; }

        IGenericRepository<Homework> Homeworks { get; }

        StudentsRepository Students { get; }

        void SaveChanges();

    }
}
