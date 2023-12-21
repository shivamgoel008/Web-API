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

        public async Task<bool> CheckStudentId(Guid studentId)
        {
            var student = context.Students.Where(x => x.Id == studentId).FirstOrDefaultAsync();
            if (student != null)
                return true;
            return false;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            List<Student> students = await context.Students.ToListAsync();
            return students;
        }

        public async Task<Student> UpdateStudent(Guid id, StudentSL student)
        {
            var studentDto = new Student();
            using (var contextNew = new StudentDBContext())
            {
                studentDto = await contextNew.Students.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            studentDto.FirstName = string.IsNullOrEmpty(student.FirstName) ? studentDto.FirstName : student.FirstName;
            studentDto.LastName = string.IsNullOrEmpty(student.LastName) ? studentDto.LastName : student.LastName;
            studentDto.DateOfBirth = string.IsNullOrEmpty(student.DateOfBirth.ToString()) ? studentDto.DateOfBirth : student.DateOfBirth;
            studentDto.Email = string.IsNullOrEmpty(student.Email) ? studentDto.Email : student.Email;
            studentDto.Mobile = string.IsNullOrEmpty(student.Mobile.ToString()) ? studentDto.Mobile : student.Mobile;
            studentDto.ProfileImageUrl = string.IsNullOrEmpty(student.ProfileImageUrl) ? studentDto.ProfileImageUrl : student.ProfileImageUrl;
            if (string.IsNullOrEmpty(student.Gender))
            {
                var genderId = await context.Genders.Where(x => x.Description == student.Gender).FirstOrDefaultAsync();
                studentDto.GenderId = genderId.Id;
            }
            context.Students.Update(studentDto);
            context.SaveChanges();
            return studentDto;
        }
        public async Task<Student> DeleteStudent(Guid studentId)
        {
            using (var contextDb= new StudentDBContext())
            {
                var student = await contextDb.Students.Where(x => x.Id == studentId).FirstOrDefaultAsync();
                if (student != null)
                {
                    contextDb.Students.Remove(student);
                    await context.SaveChangesAsync();
                    return student;
                }
                return null;
            }
        }

    }
}

