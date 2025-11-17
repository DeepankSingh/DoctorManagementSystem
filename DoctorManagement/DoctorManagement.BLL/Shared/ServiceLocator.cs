using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorManagement.BLL.Shared
{
    public class ServiceLocator
    {
        public BaseResponse Execute(BaseRequest request)
        {
            Type? classType = Type.GetType(request.BehaviorType ?? string.Empty);

            if (classType == null)
            {
                throw new InvalidOperationException($"Behavior type '{request.BehaviorType}' not found.");
            }

            BaseBehavior? instance = (BaseBehavior?)Activator.CreateInstance(classType);

            if (instance == null)
            {
                throw new InvalidOperationException($"Failed to create instance of type '{request.BehaviorType}'.");
            }

            BaseResponse responseObj = instance.Execute(request);
            return responseObj;
        }
    }
}
