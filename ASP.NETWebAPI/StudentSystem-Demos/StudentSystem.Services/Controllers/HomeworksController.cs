namespace StudentSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;
    
    public class HomeworksController : ApiController
    {
        private StudentsSystemData data = new StudentsSystemData();

        public IHttpActionResult All()
        {
            var homeworks = this.data.Homeworks.All().Select(HomeworkModel.FromHomework);

            return Ok(homeworks);
        }

        public IHttpActionResult ById(int id)
        {
            var homeworkToGet = this.data.Homeworks.All().Where(homework => homework.Id == id).Select(HomeworkModel.FromHomework).FirstOrDefault();
            if (homeworkToGet == null)
            {
                return BadRequest("Homework does not exist.");
            }
            return Ok(homeworkToGet);
        }

        public IHttpActionResult AddHomework(HomeworkModel newHomework)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid new homework.");
            }

            this.data.Homeworks.Add(new Homework()
            {
                TimeSent = newHomework.TimeSent,
                FileUrl = newHomework.FileUrl,
                CourseId = newHomework.CourseId,
                StudentIdentification = newHomework.StudentIdentification
            });
            this.data.SaveChanges();

            return Ok( "Homework added.");
        }

        [HttpPut]
        public IHttpActionResult UpdateFileUrl(int id, string newFileUrl)
        {
            var homeworkToUpdate = this.data.Homeworks.All().FirstOrDefault(homework => homework.Id == id);
            if (homeworkToUpdate == null)
            {
                return BadRequest( "Homework does not exist.");
            }

            homeworkToUpdate.FileUrl = newFileUrl;
            this.data.Homeworks.Update(homeworkToUpdate);
            this.data.SaveChanges();
            return Ok( "Hoemwork updated.");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var homeworkToDelete = this.data.Homeworks.All().FirstOrDefault(homework => homework.Id == id);
            if (homeworkToDelete == null)
            {
                return BadRequest( "Homework does not exist.");
            }

            this.data.Homeworks.Delete(homeworkToDelete);
            this.data.SaveChanges();
            return Ok();
        }
    }
}