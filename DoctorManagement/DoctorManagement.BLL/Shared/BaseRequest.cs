using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorManagement.BLL.Shared
{
    public abstract class BaseRequest
    {
        public string? BehaviorAction { get; set; }
        public string? BehaviorType { get; set; }
    }
}
