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
    }
}

