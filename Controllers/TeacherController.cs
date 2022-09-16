using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace university.Controllers
{
    [Route("[controller]")]
    public class TeacherController : Controller
    {
        [HttpGet()]
        public string GetAllTeachers(){
            return "This will return all students.";
        }
        [HttpGet("{id}")]
        public string GetOneTeacher(int id){
            return "This will return id "+id;
        }
        [HttpPost]
        public string AddTeacher(){
            return "Add new student";
        }
        [HttpPut("{id}")]
        public string UpdateTeacher(int id){
            return "Update student "+id;
        }
        [HttpDelete("{id}")]
        public string DeleteTeacher(int id){
            return "Delete student "+id;
        } 
    }
}