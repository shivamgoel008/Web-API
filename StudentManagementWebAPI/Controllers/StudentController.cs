using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentManagementWebAPI.Models;
using StudentManagementWebAPI.Repository;
using StudentManagementWebAPI.ServiceLayerModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManagementWebAPI.Controllers
{
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mapper;

        public StudentController(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> GetStudents()
        {
            List<Student> students = await studentRepository.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpPost]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> AddStudent([FromBody] StudentSL student)
        {
            Student response = await studentRepository.AddStudent(student);
            return Ok(response);
        }

        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] StudentSL request)
        {
            bool check = await studentRepository.CheckStudentId(studentId);
            if (check)
            {
                var updatedStudent = await studentRepository.UpdateStudent(studentId, request);
                if (updatedStudent != null)
                {
                    return Ok(updatedStudent);
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
            bool check = await studentRepository.CheckStudentId(studentId);
            if (check)
            {
                var student = await studentRepository.DeleteStudent(studentId);
                return Ok(student);
            }

            return NotFound();
        }
    }
}

