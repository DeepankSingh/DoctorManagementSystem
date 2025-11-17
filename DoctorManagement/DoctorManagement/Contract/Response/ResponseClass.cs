using System.Data;

namespace DoctorManagement.Contract.Response
{
    public class ResponseClass
    {
        public string? Message { get; set; }
        public DataTable? DataTable { get; set; }
        public bool Success { get; set; }
    }
}
