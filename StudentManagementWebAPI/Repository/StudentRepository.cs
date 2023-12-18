using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagementWebAPI.Models;
using StudentManagementWebAPI.ServiceLayerModels;

namespace StudentManagementWebAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentDBContext context;
        public StudentRepository(StudentDBContext _studentDBContext)
        {
            context = _studentDBContext;
        }

        public async Task<Student> AddStudent(StudentSL student)
        {
            var genderId = await context.Genders.Where(x => x.Description == student.Gender).Select(x => x.Id).FirstOrDefaultAsync();
            Student studentDto = new Student
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Email = student.Email,
                Mobile = student.Mobile,
                ProfileImageUrl = student.ProfileImageUrl,
                GenderId = genderId,
            };
            this.context.Students.Add(studentDto);
            context.SaveChanges();
            return studentDto;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            List<Student> students = await context.Students.ToListAsync();
            return students;
        }
    }
}

