using System;
using StudentManagementWebAPI.Models;

namespace StudentManagementWebAPI.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
    }
}

