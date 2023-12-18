using System;
using StudentManagementWebAPI.Models;

namespace StudentManagementWebAPI.ServiceLayerModels
{
    public class StudentSL
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }
        public long Mobile { get; set; }

        public string ProfileImageUrl { get; set; }

        public string Gender { get; set; }
        public AddressSL Address { get; set; }

    }
}

