using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorManagement.BLL.Contract
{
    public class NetworkResponseBLL
    {
        public DataTable DataTable { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

    }
}
