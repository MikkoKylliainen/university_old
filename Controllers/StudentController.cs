
using Microsoft.AspNetCore.Mvc;
using university.Models;

namespace university
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet()]
        public string GetAllStudents(){
            Student objStudent = new Student();
            string result = objStudent.GetAllStudents();
            Console.WriteLine(result);
            return result;
        }
        [HttpGet("{id}")]
        public string GetOneStudent(int id){
            return "This will return id "+id;
        }
        [HttpPost]
        public string AddStudent(){
            return "Add new student";
        }
        [HttpPut("{id}")]
        public string UpdateStudent(int id){
            return "Update student "+id;
        }
        [HttpDelete("{id}")]
        public string DeleteStudent(int id){
            return "Delete student "+id;
        }                     
    }
}