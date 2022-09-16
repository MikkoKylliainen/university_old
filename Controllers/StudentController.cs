using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace university
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet()]
        public string GetAllStudents(){
            return "This will return all students.";
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