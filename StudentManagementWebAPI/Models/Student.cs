using System;
using System.Collections.Generic;

namespace StudentManagementWebAPI.Models
{
    public partial class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = null!;
        public long Mobile { get; set; }
        public string ProfileImageUrl { get; set; } = null!;
        public Guid GenderId { get; set; }

        public virtual Gender Gender { get; set; } = null!;
        public virtual Address Address { get; set; } = null!;
    }
}
