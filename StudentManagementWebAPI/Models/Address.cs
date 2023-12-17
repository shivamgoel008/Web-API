using System;
using System.Collections.Generic;

namespace StudentManagementWebAPI.Models
{
    public partial class Address
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; } = null!;
        public string PostalAddress { get; set; } = null!;
        public Guid StudentId { get; set; }

        public virtual Student Student { get; set; } = null!;
    }
}
