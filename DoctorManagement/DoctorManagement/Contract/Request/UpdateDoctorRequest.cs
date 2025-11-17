namespace DoctorManagement.Contract.Request
{
    public class UpdateDoctorRequest
    {

        public int? RegistrationId { get; set; }
        public string? LicenseNumber { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string? ContactNumber { get; set; }
        public int? NetworkId { get; set; }
        public int? HospitalId { get; set; }
        public int? DepartmentId { get; set; }
        public int? DoctorId { get; set; }
        public bool? IsActive { get; set; }
    }
}
