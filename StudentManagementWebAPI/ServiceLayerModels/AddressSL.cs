using System;
namespace StudentManagementWebAPI.ServiceLayerModels
{
    public class AddressSL
    {
        public Guid Id { get; set; }
        public string PhysicalAddress { get; set; } = null!;
        public string PostalAddress { get; set; } = null!;
        public Guid StudentId { get; set; }
    }
}

