using System;
using System.ComponentModel.DataAnnotations;
using StudentManagementWebAPI.Models;

namespace StudentManagementWebAPI.ServiceLayerModels
{
    public class StudentSL
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }
        public long Mobile { get; set; }

        public string ProfileImageUrl { get; set; }

        public string Gender { get; set; }
        public AddressSL Address { get; set; }

    }
}

