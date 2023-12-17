using System;
using System.Collections.Generic;

namespace StudentManagementWebAPI.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Students = new HashSet<Student>();
        }

        public Guid Id { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}
