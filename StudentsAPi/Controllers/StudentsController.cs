using bussinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsAPi.Data;
using StudentsAPi.Model;
using System.Linq;

namespace StudentsAPi.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult <List<sclass.Students>> GetAllStudents()
        {
            if (BussinessLogic.getAllStudents() != null)
            {
                return Ok(BussinessLogic.getAllStudents());
            }
            return NotFound(new { message = "there is no students" });
        }

        [HttpGet("passed")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<List<sclass.Students>> GetPassedStudents()
        {
            var passed = BussinessLogic.getPassedStudents();
            if (passed == null)
            {
                return NotFound(new { message = "no one passed" });
            }
            return Ok(passed);
        }


        [HttpGet("{id}", Name = "GetStudentById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<sclass.Students> GetStudentById(string id)
        {
            if (!int.TryParse(id, out int result) || result < 0)
            {
                return BadRequest(new { message = "invaild id Name!" }); 
            }
            
            var student = BussinessLogic.getStudentById(result);
            if (student == null)
            {
                return NotFound(new { message = $"student with id {id} does not exist" });
            }
            return Ok(student);
        }

        [HttpPost("add",Name = "AddStudent")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<sclass.Students> AddStudent(sclass.Students student)
        {
            if (BussinessLogic.addStudent(student) == null)
            {
                return BadRequest(new { message = "couldn't add new student"});
            }
            return CreatedAtRoute("GetStudentById", new { id = student.id }, student);
        }


        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<sclass.Students>deleteStudent(string id)
        {
            if (!int.TryParse(id, out int result) || result < 0)
            {
                return BadRequest( new{ message = "invaild id Name!"});
            }
            if (BussinessLogic.deleteStudent(result))
            {
                return Ok( new{message =  $"Student with id {id} was deleted successfully"});
            }
            else
            {
                return NotFound(new{message  =  $"Student with id {id} does not exist"});
            }
        }
        [HttpPut("update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<sclass.Students>updateStudent(sclass.Students student)
        {
           
            if (BussinessLogic.updateStudent(student)!=null)
            {
                return Ok(new { message = $"Student with id {student.id} was updated successfully" });
            }
            return  BadRequest(new { message = "couldn't add new student" });





        }
    }
}
