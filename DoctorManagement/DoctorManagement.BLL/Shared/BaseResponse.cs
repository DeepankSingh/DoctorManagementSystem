using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorManagement.BLL.Shared
{
    public abstract class BaseResponse
    {
        public string? Message { get; set; }
        public DataTable? DataTable { get; set; }
        public bool Success { get; set; }
    }
}
