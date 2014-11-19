using StudentSystem.Data;
using StudentSystem.Models;
using StudentSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace StudentSystem.Services.Controllers
{
    public class CoursesController : ApiController
    {
        private IStudentSystemData data;

        public CoursesController()
            : this(new StudentsSystemData())
        {
        }

        public CoursesController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(data.Courses.All().Select(CourseModel.FromCourse));
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var course = this.data
                .Courses
                .All()
                .Where(c => c.Id == id)
                .Select(CourseModel.FromCourse)
                .FirstOrDefault();

            if (course == null)
            {
                return BadRequest("Course does not exist - invalid id");
            }

            return Ok(course);
        }

        [HttpGet]
        public IHttpActionResult ByName(string name)
        {
            name = name.ToLower();

            var courses = this.data.Courses
                              .All()
                              .Where(c => c.Name.ToLower().Contains(name))
                              .Select(CourseModel.FromCourse);

            if (courses == null)
            {
                return BadRequest("Course does not exist - invalid id");
            }

            return Ok(courses);
        }

        [HttpPost]
        public IHttpActionResult Create(CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCourse = new Course
            {
                Name = course.Name,
                Description = course.Description

            };

            this.data.Courses.Add(newCourse);
            this.data.SaveChanges();

            course.Id = newCourse.Id;
            return Ok(course);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, CourseModel course)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCourse = this.data.Courses.All().FirstOrDefault(s => s.Id == id);
            if (existingCourse == null)
            {
                return BadRequest("Such course does not exist!");
            }

            existingCourse.Name = course.Name;
            existingCourse.Description = course.Description;
            this.data.SaveChanges();

            course.Id = id;
            return Ok(course);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingCourse = this.data.Courses.All().FirstOrDefault(s => s.Id == id);
            if (existingCourse == null)
            {
                return BadRequest("Such student does not exists!");
            }

            this.data.Courses.Delete(existingCourse);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddStudent(int id, int studentId)
        {
            var course = this.data.Courses.All().FirstOrDefault(s => s.Id == id);
            if (course == null)
            {
                return BadRequest("Such course does not exists - invalid id!");
            }

            var student = this.data.Students.All().FirstOrDefault(c => c.Id == studentId);
            if (student == null)
            {
                return BadRequest("Such student does not exists - invalid id!");
            }

            course.Students.Add(student);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddHomework(int id, int homeworkId)
        {
            var course = this.data.Courses.All().FirstOrDefault(s => s.Id == id);
            if (course == null)
            {
                return BadRequest("Such course does not exists - invalid id!");
            }

            var homework = this.data.Homeworks.All().FirstOrDefault(c => c.Id == homeworkId);
            if (homework == null)
            {
                return BadRequest("Such homework does not exists - invalid id!");
            }

            course.Homeworks.Add(homework);
            this.data.SaveChanges();

            return Ok();
        }
    }
}