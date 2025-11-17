using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoctorManagement.DAL.Contract
{
    public class NetworkResponseDAL
    {

        public DataTable DataTable { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

    }
}
