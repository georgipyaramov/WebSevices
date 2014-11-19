namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    public class StudentsController : ApiController
    {
        private IStudentSystemData data;

        public StudentsController()
            : this(new StudentsSystemData())
        {
        }

        public StudentsController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(data.Students.All().Select(StudentModel.FromStudent));
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var student = this.data
                .Students
                .All()
                .Where(s => s.Id == id)
                .Select(StudentModel.FromStudent)
                .FirstOrDefault();

            if (student == null)
            {
                return BadRequest("Student does not exist - invalid id");
            }

            return Ok(student);
        }

        [HttpGet]
        public IHttpActionResult ByName(string name)
        {
            name = name.ToLower();

            var students = this.data.Students
                              .All()
                              .Where(s => s.FirstName.ToLower().Contains(name) || s.LastName.ToLower().Contains(name))
                              .Select(StudentModel.FromStudent);

            if (students == null)
            {
                return BadRequest("Student does not exist - invalid id");
            }

            return Ok(students);
        }

        [HttpPost]
        public IHttpActionResult Create(StudentModel student)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newStudent = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName
            };

            this.data.Students.Add(newStudent);
            this.data.SaveChanges();

            student.Id = newStudent.Id;
            return Ok(student);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, StudentModel student)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingStudent = this.data.Students.All().FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return BadRequest("Such student does not exists!");
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            this.data.SaveChanges();

            student.Id = id;
            return Ok(student);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingStudent = this.data.Students.All().FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
            {
                return BadRequest("Such student does not exists!");
            }

            this.data.Students.Delete(existingStudent);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddCourse(int id, int courseId)
        {
            var student = this.data.Students.All().FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return BadRequest("Such student does not exists - invalid id!");
            }

            var course = this.data.Courses.All().FirstOrDefault(c => c.Id == courseId);
            if (course == null)
            {
                return BadRequest("Such course does not exists - invalid id!");
            }

            student.Courses.Add(course);
            this.data.SaveChanges();

            return Ok();
        }
    }
}