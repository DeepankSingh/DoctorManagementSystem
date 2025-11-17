using System.Data;
using DoctorManagement.Contract.Request;
using DoctorManagement.BLL.Contract;
using DoctorManagement.BLL.Shared;

namespace DoctorManagement.Model
{
    public class DoctorModel
    {
        private readonly ServiceLocator _serviceLocator;

        public DoctorModel()
        {
            _serviceLocator = new ServiceLocator();
        }

        public DataTable? GetAllDoctorEntries()
        {
            DoctorRequestBLL request = new DoctorRequestBLL
            {
                BehaviorAction = "get_all_doctor_entries",
                BehaviorType = "DoctorManagement.BLL.Behavior.DoctorService"
            };

            BaseResponse response = _serviceLocator.Execute(request);
            return response.DataTable;
        }

        public DataTable? AddDoctorEntry(AddDoctorRequest addRequest)
        {
            DoctorRequestBLL request = new DoctorRequestBLL
            {
                BehaviorAction = "add_doctor_entry",
                BehaviorType = "DoctorManagement.BLL.Behavior.DoctorService",
                LicenseNumber = addRequest.LicenseNumber,
                IssueDate = addRequest.IssueDate,
                ExpiryDate = addRequest.ExpiryDate,
                ContactNumber = addRequest.ContactNumber,
                NetworkId = addRequest.NetworkId,
                HospitalId = addRequest.HospitalId,
                DepartmentId = addRequest.DepartmentId,
                DoctorId = addRequest.DoctorId,
                IsActive = addRequest.IsActive
            };

            BaseResponse response = _serviceLocator.Execute(request);
            return response.DataTable;
        }

        public DataTable? UpdateDoctorEntry(UpdateDoctorRequest updateRequest)
        {
            DoctorRequestBLL request = new DoctorRequestBLL
            {
                BehaviorAction = "update_doctor_entry",
                BehaviorType = "DoctorManagement.BLL.Behavior.DoctorService",
                LicenseNumber = updateRequest.LicenseNumber,
                IssueDate = updateRequest.IssueDate,
                ExpiryDate = updateRequest.ExpiryDate,
                ContactNumber = updateRequest.ContactNumber,
                NetworkId = updateRequest.NetworkId,
                HospitalId = updateRequest.HospitalId,
                DepartmentId = updateRequest.DepartmentId,
                DoctorId = updateRequest.DoctorId,
                IsActive = updateRequest.IsActive,
                RegistrationId = updateRequest.RegistrationId
            };

            BaseResponse response = _serviceLocator.Execute(request);
            return response.DataTable;
        }

        public DataTable? DeleteDoctorEntry(int registrationId)
        {
            DoctorRequestBLL request = new DoctorRequestBLL
            {
                BehaviorAction = "delete_doctor_entry",
                BehaviorType = "DoctorManagement.BLL.Behavior.DoctorService",
                RegistrationId = registrationId
            };

            BaseResponse response = _serviceLocator.Execute(request);
            return response.DataTable;
        }

        public DataTable? SearchDoctorEntries(SearchDoctorRequest searchRequest)
        {
            DoctorRequestBLL request = new DoctorRequestBLL
            {
                BehaviorAction = "search_doctor_entry",
                BehaviorType = "DoctorManagement.BLL.Behavior.DoctorService",
                SearchTerm = searchRequest.SearchTerm
            };

            BaseResponse response = _serviceLocator.Execute(request);
            return response.DataTable;
        }

        //public DataTable? GetDoctorById(int registrationId)
        //{
        //    DoctorRequestBLL request = new DoctorRequestBLL
        //    {
        //        BehaviorAction = "get_doctor_by_id",
        //        BehaviorType = "DoctorManagement.BLL.Behavior.DoctorService",
        //        RegistrationId = registrationId
        //    };

        //    BaseResponse response = _serviceLocator.Execute(request);

        //    return response != null ? response.DataTable : null;
        //}

        //public DataTable? GetNetworks()
        //{
        //    DoctorRequestBLL request = new DoctorRequestBLL
        //    {
        //        BehaviorAction = "get_network",
        //        BehaviorType = "DoctorManagement.BLL.Behavior.DoctorService",

        //    };
        //    BaseResponse response = _serviceLocator.Execute(request);

        //    return response != null ? response.DataTable : null;


        //}


        //public DataTable? GetHospitalsByNetwork(int networkId)
        //{
        //    DoctorRequestBLL request = new DoctorRequestBLL
        //    {
        //        BehaviorAction = "get_hospitals_by_network",
        //        BehaviorType = "DoctorManagement.BLL.Behavior.DoctorService",
        //        NetworkId = networkId
        //    };

        //    BaseResponse response = _serviceLocator.Execute(request);

        //    return response != null ? response.DataTable : null;
        //}

        //public DataTable? GetDepartmentsByHospital(int hospitalId)
        //{
        //    DoctorRequestBLL request = new DoctorRequestBLL
        //    {
        //        HospitalId = hospitalId,
        //        BehaviorAction = "get_departments_by_hospital",
        //        BehaviorType = "DoctorManagement.BLL.Behavior.DoctorService"
        //    };

        //    BaseResponse response = _serviceLocator.Execute(request);

        //    return response != null ? response.DataTable : null;
        //}

        //public DataTable? GetDoctorsByDepartment(int departmentId)
        //{
        //    DoctorRequestBLL request = new DoctorRequestBLL
        //    {
        //        DepartmentId = departmentId,
        //        BehaviorAction = "get_doctors_by_department",
        //        BehaviorType = "DoctorManagement.BLL.Behavior.DoctorService"
        //    };

        //    BaseResponse response = _serviceLocator.Execute(request);

        //    return response != null ? response.DataTable : null;
        //}

        public DataTable? GetMasterData(string mode,int? id)
        {
            DoctorRequestBLL request = new DoctorRequestBLL
            {
                BehaviorAction = "get_master_data",
                BehaviorType = "DoctorManagement.BLL.Behavior.DoctorService",
                Mode = mode,
                RegistrationId = id,
                NetworkId = id,
                HospitalId = id,
                DepartmentId = id
            };

            BaseResponse response = _serviceLocator.Execute(request);
            return response.DataTable;

        }
    }
}
