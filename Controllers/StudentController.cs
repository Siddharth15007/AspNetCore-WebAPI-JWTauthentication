using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models;
using StudentWebApi.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace StudentWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private StudentContext _studentContext;
        public StudentController(StudentContext context)
        {
            _studentContext = context;
        }

       // Get All Student
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            var stud =  _studentContext.Students
                        .ToList();
             return stud;
            
        }

        // [HttpGet]
        // public IEnumerable<string> Get(){
        //     return _studentContext.Users.Select(u => u.UserName).ToArray();
        // }

        [HttpGet]
        [Route("getbyid/{id}")]
        public ActionResult<Student> GetById(int id)
        {
            if(id == 0){
                return NotFound();
            }

            Student student = _studentContext.Students.FirstOrDefault(s => s.StudentID == id);

            if(student == null){
                return NotFound("Student Not Found");
            }
            return Ok(student);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Student student){
            if(student == null){
                return NotFound("Student Data is not Supplied");
            }

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            Console.WriteLine(student);
            await _studentContext.Students.AddAsync(student);
            await _studentContext.SaveChangesAsync();
            return Ok(student);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody]Student student)
        {
             if(student == null){
                return NotFound("Student Data is not Supplied");
            }
             if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            Student exstingStudent = _studentContext.Students.FirstOrDefault(s => s.StudentID == student.StudentID);

            if(exstingStudent == null){
                return NotFound("This Perticular Student does not Exsit in database");
            }

            exstingStudent.Name = student.Name;
            exstingStudent.Semester = student.Semester;
            exstingStudent.Department = student.Department; 
            _studentContext.Attach(exstingStudent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _studentContext.SaveChangesAsync();
            return Ok(exstingStudent);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
             if(id == null){
                return NotFound("Student Data is not Found");
            }
            Student student = _studentContext.Students.FirstOrDefault(s => s.StudentID == id);

             if(student == null){
                return NotFound("Student Not Found with particular id!!!");
            }
            _studentContext.Students.Remove(student);
            await _studentContext.SaveChangesAsync();
            return Ok("Student data is deleted!!!");

        }

        ~StudentController(){
            _studentContext.Dispose(); 
        }
    }
}