using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using DoctorManagement.BLL.Contract;
using DoctorManagement.BLL.Shared;
using DoctorManagement.DAL.Behavior;
using DoctorManagement.DAL.Contract;

namespace DoctorManagement.BLL.Behavior
{
    public class DoctorService : BaseBehavior
    {
        private readonly DoctorRepository _repository;

        public DoctorService()
        {
            _repository = new DoctorRepository();
        }

        public override BaseResponse Execute(BaseRequest request)
        {
            DoctorRequestBLL doctorRequest = (DoctorRequestBLL)request;
            DoctorResponseBLL response = new DoctorResponseBLL();

            switch (doctorRequest.BehaviorAction?.ToLower())
            {
                case "get_all_doctor_entries":
                    response = GetAllDoctorEntries();
                    break;

                case "add_doctor_entry":
                    response = AddDoctorEntry(doctorRequest);
                    break;

                case "update_doctor_entry":
                    response = UpdateDoctorEntry(doctorRequest);
                    break;

                case "delete_doctor_entry":
                    response = DeleteDoctorEntry(doctorRequest);
                    break;

                case "search_doctor_entry":
                    response = SearchDoctorEntries(doctorRequest);
                    break;
                case "get_doctor_by_id":
                    response = GetDoctorById(doctorRequest);
                    break;
                case "get_network":
                    response = GetNetworks();
                   break;
                case "get_hospitals_by_network":
                    response = GetHospitalsByNetwork(doctorRequest);
                    break;
                case "get_departments_by_hospital":
                    response = GetDepartmentsByHospital(doctorRequest);
                    break;
                case "get_doctors_by_department":
                    response = GetDoctorsByDepartment(doctorRequest);   
                    break;
                case "get_master_data":
                    response = GetMasterData(doctorRequest);
                    break;
                default:
                    response.Success = false;
                    response.Message = "Invalid behavior action";
                    break;
            }

            return response;
        }

        private DoctorResponseBLL GetMasterData(DoctorRequestBLL request)
        {
            DoctorRequestDAL dalrequest = new DoctorRequestDAL
            {
                Mode = request.Mode,
                RegistrationId = request.RegistrationId,
                NetworkId = request.NetworkId,
                HospitalId = request.HospitalId,
                DepartmentId = request.DepartmentId,
                DoctorId = request.DoctorId

            };

            DoctorResponseDAL response = _repository.GetMasterData(dalrequest);

            return new DoctorResponseBLL
            {
                DataTable = response.DataTable,
                Message = response.Message,
                Success = response.Success
            };
        }

        private DoctorResponseBLL GetAllDoctorEntries()
        {
            DoctorResponseDAL dalResponse = _repository.GetAllDoctorRegistrations();

            return new DoctorResponseBLL
            {
                DataTable = dalResponse.DataTable,
                Message = dalResponse.Message,
                Success = dalResponse.Success
            };
        }

        private DoctorResponseBLL AddDoctorEntry(DoctorRequestBLL request)
        {
            DoctorRequestDAL dalRequest = new DoctorRequestDAL
            {
                LicenseNumber = request.LicenseNumber,
                IssueDate = request.IssueDate,
                ExpiryDate = request.ExpiryDate,
                ContactNumber = request.ContactNumber,
                NetworkId = request.NetworkId,
                HospitalId = request.HospitalId,
                DepartmentId = request.DepartmentId,
                DoctorId = request.DoctorId,
                IsActive = request.IsActive
            };

            DoctorResponseDAL dalResponse = _repository.InsertDoctorRegistration(dalRequest);

            return new DoctorResponseBLL
            {
                DataTable = dalResponse.DataTable,
                Message = dalResponse.Message,
                Success = dalResponse.Success
            };
        }

        private DoctorResponseBLL UpdateDoctorEntry(DoctorRequestBLL request)
        {
            DoctorRequestDAL dalRequest = new DoctorRequestDAL
            {
                RegistrationId = request.RegistrationId,
                LicenseNumber = request.LicenseNumber,
                IssueDate = request.IssueDate,
                ExpiryDate = request.ExpiryDate,
                ContactNumber = request.ContactNumber,
                NetworkId = request.NetworkId,
                HospitalId = request.HospitalId,
                DepartmentId = request.DepartmentId,
                DoctorId = request.DoctorId,
                IsActive = request.IsActive
            };

            DoctorResponseDAL dalResponse = _repository.UpdateDoctorRegistration(dalRequest);

            return new DoctorResponseBLL
            {
                DataTable = dalResponse.DataTable,
                Message = dalResponse.Message,
                Success = dalResponse.Success
            };
        }

        private DoctorResponseBLL DeleteDoctorEntry(DoctorRequestBLL request)
        {
            DoctorRequestDAL dalRequest = new DoctorRequestDAL
            {
                RegistrationId = request.RegistrationId
            };

            DoctorResponseDAL dalResponse = _repository.DeleteDoctorRegistration(dalRequest);

            return new DoctorResponseBLL
            {
                DataTable = dalResponse.DataTable,
                Message = dalResponse.Message,
                Success = dalResponse.Success
            };
        }

        private DoctorResponseBLL SearchDoctorEntries(DoctorRequestBLL request)
        {
            DoctorRequestDAL dalRequest = new DoctorRequestDAL
            {
                SearchTerm = request.SearchTerm
            };

            DoctorResponseDAL dalResponse = _repository.SearchDoctorRegistrations(dalRequest);

            return new DoctorResponseBLL
            {
                DataTable = dalResponse.DataTable,
                Message = dalResponse.Message,
                Success = dalResponse.Success
            };
        }

        private DoctorResponseBLL GetDoctorById(DoctorRequestBLL doctorRequest)
        {

            DoctorRequestDAL dalRequest = new DoctorRequestDAL
            {
                RegistrationId = doctorRequest.RegistrationId
            };

            DoctorResponseDAL dalResponse = _repository.GetDoctorById(dalRequest);

            if (dalResponse == null)
            {
                return new DoctorResponseBLL
                {
                    Success = false,
                    Message = "No response received from repository."
                };
            }

            return new DoctorResponseBLL
            {
                DataTable = dalResponse.DataTable,
                Message = dalResponse.Message,
                Success = dalResponse.Success
            };
        }

        public DoctorResponseBLL GetNetworks()
        {
            var dalResponse = _repository.GetNetworks();

            return new DoctorResponseBLL
            {
                DataTable = dalResponse.DataTable,
                Message = dalResponse.Message,
                Success = dalResponse.Success
            };
        }


        public DoctorResponseBLL GetHospitalsByNetwork(DoctorRequestBLL hospitalRequest)
        {
            DoctorRequestDAL dalRequest = new DoctorRequestDAL
            {
                NetworkId = hospitalRequest.NetworkId
            };

            var dalResponse = _repository.GetHospitalsByNetwork(dalRequest);

            return new DoctorResponseBLL
            {
                DataTable = dalResponse.DataTable,
                Message = dalResponse.Message,
                Success = dalResponse.Success
            };
        }


        private DoctorResponseBLL GetDepartmentsByHospital(DoctorRequestBLL request)
        {
            DoctorRequestDAL dalRequest = new DoctorRequestDAL
            {
                HospitalId = request.HospitalId
            };

            var dalResponse = _repository.GetDepartmentsByHospital(dalRequest);

            return new DoctorResponseBLL
            {
                DataTable = dalResponse.DataTable,
                Message = dalResponse.Message,
                Success = dalResponse.Success
            };
        }

        private DoctorResponseBLL GetDoctorsByDepartment(DoctorRequestBLL request)
        {
            var dalReq = new DoctorRequestDAL
            {
                DepartmentId = request.DepartmentId
            };

            var dalRes = _repository.GetDoctorsByDepartment(dalReq);

            return new DoctorResponseBLL
            {
                DataTable = dalRes.DataTable,
                Success = dalRes.Success,
                Message = dalRes.Message
            };
        }



    }
}
