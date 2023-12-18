using System;
using StudentManagementWebAPI.Models;
using StudentManagementWebAPI.ServiceLayerModels;

namespace StudentManagementWebAPI.Repository
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> AddStudent(StudentSL student);
    }
}

