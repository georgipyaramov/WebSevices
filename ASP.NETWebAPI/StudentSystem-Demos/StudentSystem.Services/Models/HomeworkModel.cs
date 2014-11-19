namespace StudentSystem.Services.Models
{
    using StudentSystem.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    public class HomeworkModel
    {
        public static Expression<Func<Homework, HomeworkModel>> FromHomework
        {
            get
            {
                return a => new HomeworkModel
                {
                    TimeSent = a.TimeSent,
                    FileUrl = a.FileUrl,
                    CourseId = a.CourseId,
                    StudentIdentification = a.StudentIdentification
                };
            }
        }

        [Required]
        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }

        public int StudentIdentification { get; set; }

        public Guid CourseId { get; set; }
    }
}