using System;
using System.Collections.Generic;

namespace DoctorManagement.DAL.Entities;

public partial class DoctorRegistration
{
    public int RegistrationId { get; set; }

    public string LicenseNumber { get; set; } = null!;

    public DateOnly IssueDate { get; set; }

    public DateOnly ExpiryDate { get; set; }

    public string ContactNumber { get; set; } = null!;

    public int NetworkId { get; set; }

    public int HospitalId { get; set; }

    public int DepartmentId { get; set; }

    public int DoctorId { get; set; }

    public string IsActive { get; set; } = null!;

    public DateTime? CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }
}
