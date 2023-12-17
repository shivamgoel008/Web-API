using System;
using Microsoft.EntityFrameworkCore;
using StudentManagementWebAPI.Models;

namespace StudentManagementWebAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private StudentDBContext context;
        public StudentRepository(StudentDBContext _studentDBContext)
        {
            context = _studentDBContext;
        }
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            List<Student> students = await context.Students.ToListAsync();
            return students;
        }
    }
}

