using System.Data;
using DoctorManagement.BLL.Shared;
using DoctorManagement.Contract.Request;
using DoctorManagement.Contract.Response;
using DoctorManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DoctorManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorManagementController : ControllerBase
    {
        private readonly DoctorModel _doctorModel;

        public DoctorManagementController()
        {
            _doctorModel = new DoctorModel();
        }

        [HttpGet("GetAllDoctorEntries")]
        public IActionResult GetAllDoctorEntries()
        {


            var dt = _doctorModel.GetAllDoctorEntries();

            var doctorEntries = dt.AsEnumerable().Select(row => new
            {
                RegistrationId = row.Field<int>("RegistrationId"),
                LicenseNumber = row.Field<string>("LicenseNumber"),
                IssueDate = row.Field<DateTime>("IssueDate"),
                ExpiryDate = row.Field<DateTime>("ExpiryDate"),
                NetworkName = row.Field<string>("NetworkName"),
                HospitalName = row.Field<string>("HospitalName"),
                DepartmentName = row.Field<string>("DepartmentName"),
                DoctorName = row.Field<string>("DoctorName"),
                IsActive = row.Field<string>("IsActive")
            }).ToList();

            return Ok(new
            {
                Message = "Data retrieved successfully",
                Data = doctorEntries,
                Success = true
            });

           

        }

        [HttpPost("AddDoctorEntry")]
        public IActionResult AddDoctorEntry(AddDoctorRequest request)
        {


            var dt = _doctorModel.AddDoctorEntry(request);

            var result = dt.AsEnumerable().Select(row => new
            {
                Status = row.Field<string>("Status"),
                Message = row.Field<string>("Message"),
                LicenseNumber = dt.Columns.Contains("LicenseNumber") ? row.Field<string>("LicenseNumber") : null,
                IssueDate = dt.Columns.Contains("IssueDate") ? row.Field<DateTime?>("IssueDate") : null,
                ExpiryDate = dt.Columns.Contains("ExpiryDate") ? row.Field<DateTime?>("ExpiryDate") : null,
                ContactNumber = dt.Columns.Contains("ContactNumber") ? row.Field<string>("ContactNumber") : null,
                NetworkId = dt.Columns.Contains("NetworkId") ? row.Field<int?>("NetworkId") : null,
                HospitalId = dt.Columns.Contains("HospitalId") ? row.Field<int?>("HospitalId") : null,
                DepartmentId = dt.Columns.Contains("DepartmentId") ? row.Field<int?>("DepartmentId") : null,
                DoctorId = dt.Columns.Contains("DoctorId") ? row.Field<int?>("DoctorId") : null,
                IsActive = dt.Columns.Contains("IsActive") ? row.Field<string>("IsActive") : null
            }).FirstOrDefault();

            return Ok(new
            {
                Message = "Doctor entry added successfully",
                Data = result,
                Success = true
            });



        }

        [HttpPut("UpdateDoctorEntry")]
        public IActionResult UpdateDoctorEntry(UpdateDoctorRequest request)
        {


            var dt = _doctorModel.UpdateDoctorEntry(request);

            var result = dt.AsEnumerable().Select(row => new
            {
                Status = dt.Columns.Contains("Status") ? row.Field<string>("Status") : "SUCCESS",
                Message = dt.Columns.Contains("Message") ? row.Field<string>("Message") : "Doctor entry updated successfully",
                RegistrationId = dt.Columns.Contains("RegistrationId") ? row.Field<int?>("RegistrationId") : null,
                LicenseNumber = dt.Columns.Contains("LicenseNumber") ? row.Field<string>("LicenseNumber") : null,
                IssueDate = dt.Columns.Contains("IssueDate") ? row.Field<DateTime?>("IssueDate") : null,
                ExpiryDate = dt.Columns.Contains("ExpiryDate") ? row.Field<DateTime?>("ExpiryDate") : null,
                ContactNumber = dt.Columns.Contains("ContactNumber") ? row.Field<string>("ContactNumber") : null,
                NetworkId = dt.Columns.Contains("NetworkId") ? row.Field<int?>("NetworkId") : null,
                HospitalId = dt.Columns.Contains("HospitalId") ? row.Field<int?>("HospitalId") : null,
                DepartmentId = dt.Columns.Contains("DepartmentId") ? row.Field<int?>("DepartmentId") : null,
                DoctorId = dt.Columns.Contains("DoctorId") ? row.Field<int?>("DoctorId") : null,
                IsActive = dt.Columns.Contains("IsActive") ? row.Field<string>("IsActive") : null,
                ModifiedDate = dt.Columns.Contains("ModifiedDate") ? row.Field<DateTime?>("ModifiedDate") : null
            }).FirstOrDefault();

            return Ok(new
            {
                Message = "Doctor entry updated successfully",
                Data = result,
                Success = true
            });


            

        }

        [HttpDelete("DeleteDoctorEntry/{registrationId}")]
        public IActionResult DeleteDoctorEntry(int registrationId)
        {

            var dt = _doctorModel.DeleteDoctorEntry(registrationId);

            var result = dt.AsEnumerable().Select(row => new
            {
                Status = dt.Columns.Contains("Status") ? row.Field<string>("Status") : "SUCCESS",
                Message = dt.Columns.Contains("Message") ? row.Field<string>("Message") : "Doctor entry deleted successfully",
                RegistrationId = dt.Columns.Contains("RegistrationId") ? row.Field<int?>("RegistrationId") : registrationId
            }).FirstOrDefault();

            return Ok(new
            {
                Message = "Doctor entry deleted successfully",
                Data = result,
                Success = true
            });




        }

        [HttpGet("SearchDoctorEntries")]
        public IActionResult SearchDoctorEntries(string? searchTerm)
        {


            var searchRequest = new SearchDoctorRequest { SearchTerm = searchTerm };
            var dt = _doctorModel.SearchDoctorEntries(searchRequest);

            var result = dt.AsEnumerable().Select(row => new
            {
                RegistrationId = row.Field<int>("RegistrationId"),
                LicenseNumber = row.Field<string>("LicenseNumber"),
                IssueDate = row.Field<DateTime>("IssueDate"),
                ExpiryDate = row.Field<DateTime>("ExpiryDate"),
                ContactNumber = row.Field<string>("ContactNumber"),
                NetworkName = row.Field<string>("NetworkName"),
                HospitalName = row.Field<string>("HospitalName"),
                DepartmentName = row.Field<string>("DepartmentName"),
                DoctorName = row.Field<string>("DoctorName")
            }).ToList();

            return Ok(new
            {
                Message = "Search completed successfully",
                Data = result,
                Success = true
            });

            

        }


        //[HttpGet("GetDoctorById")]
        //public IActionResult GetDoctorById(int registrationId)
        //{
        //    try
        //    {
        //        // Model returns a DataTable directly
        //        DataTable dt = _doctorModel.GetDoctorById(registrationId);

        //        if (dt == null || dt.Rows.Count == 0)
        //        {
        //            return NotFound(new
        //            {
        //                Message = "No doctor found with this ID",
        //                Success = false
        //            });
        //        }

        //        var doctor = dt.AsEnumerable().Select(row => new
        //        {
        //            RegistrationId = row.Field<int>("RegistrationId"),
        //            LicenseNumber = row.Field<string>("LicenseNumber"),
        //            IssueDate = row.Field<DateTime>("IssueDate"),
        //            ExpiryDate = row.Field<DateTime>("ExpiryDate"),
        //            ContactNumber = row.Field<string>("ContactNumber"),
        //            NetworkId = row.Field<int>("NetworkId"),
        //            HospitalId = row.Field<int>("HospitalId"),
        //            DepartmentId = row.Field<int>("DepartmentId"),
        //            DoctorId = row.Field<int>("DoctorId"),
        //            IsActive = row.Field<string>("IsActive")
        //        }).FirstOrDefault();

        //        return Ok(new
        //        {
        //            Message = "Doctor details retrieved successfully",
        //            Data = doctor,
        //            Success = true
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new
        //        {
        //            Message = "Internal server error",
        //            Error = ex.Message,
        //            Success = false
        //        });
        //    }
        //}


        //[HttpGet("GetNetworks")]
        //public IActionResult GetNetworks()
        //{
        //    var dt = _doctorModel.GetNetworks();


        //    if (dt == null || dt.Rows.Count == 0)
        //    {
        //        return NotFound(new
        //        {
        //            Success = false,
        //            Message = "No networks found"
        //        });
        //    }

        //    var list = dt.AsEnumerable().Select(row => new
        //    {
        //        NetworkId = row.Field<int>("NetworkId"),
        //        HospitalNetworkName = row.Field<string>("HospitalNetworkName")
        //    }).ToList();

        //    return Ok(new
        //    {
        //        Success = true,
        //        Data = list
        //    });
        //}


        //[HttpGet("GetHospitalsByNetwork")]
        //public IActionResult GetHospitalsByNetwork(int networkId)
        //{
        //    var dt = _doctorModel.GetHospitalsByNetwork(networkId);

        //    if (dt == null || dt.Rows.Count == 0)
        //    {
        //        return NotFound(new
        //        {
        //            Success = false,
        //            Message = "No hospitals found for this network"
        //        });
        //    }

        //    var list = dt.AsEnumerable().Select(row => new
        //    {
        //        HospitalId = row.Field<int>("HospitalId"),
        //        HospitalName = row.Field<string>("HospitalName")
        //    }).ToList();

        //    return Ok(new
        //    {
        //        Success = true,
        //        Message = "Hospitals fetched successfully",
        //        Data = list
        //    });
        //}

        //[HttpGet("GetDepartmentsByHospital")]
        //public IActionResult GetDepartmentsByHospital(int hospitalId)
        //{
        //    var dt = _doctorModel.GetDepartmentsByHospital(hospitalId);

        //    if (dt == null || dt.Rows.Count == 0)
        //    {
        //        return NotFound(new
        //        {
        //            Success = false,
        //            Message = "No departments found for this hospital"
        //        });
        //    }

        //    var list = dt.AsEnumerable().Select(row => new
        //    {
        //        DepartmentId = row.Field<int>("DepartmentId"),
        //        DepartmentName = row.Field<string>("DepartmentName"),
        //        HospitalId = row.Field<int>("HospitalId"),
        //        HospitalName = row.Field<string>("HospitalName")
        //    }).ToList();

        //    return Ok(new
        //    {
        //        Success = true,
        //        Message = "Departments fetched successfully",
        //        Data = list
        //    });
        //}

        //[HttpGet("GetDoctorsByDepartment")]
        //public IActionResult GetDoctorsByDepartment(int departmentId)
        //{
        //    var dt = _doctorModel.GetDoctorsByDepartment(departmentId);

        //    if (dt == null || dt.Rows.Count == 0)
        //    {
        //        return NotFound(new
        //        {
        //            Success = false,
        //            Message = "No doctors found for this department"
        //        });
        //    }

        //    var list = dt.AsEnumerable().Select(row => new
        //    {
        //        DoctorId = row.Field<int>("DoctorId"),
        //        DoctorName = row.Field<string>("DoctorName"),
        //        HospitalId = row.Field<int>("HospitalId"),
        //        HospitalName = row.Field<string>("HospitalName"),
        //        DepartmentId = row.Field<int>("DepartmentId"),
        //        DepartmentName = row.Field<string>("DepartmentName")
        //    }).ToList();

        //    return Ok(new
        //    {
        //        Success = true,
        //        Message = "Doctors fetched successfully",
        //        Data = list
        //    });
        //}






        [HttpGet("GetMasterData")]
        public IActionResult GetMasterData(string mode, int? id)
        {

            DataTable data = _doctorModel.GetMasterData(mode, id);

            string result = JsonConvert.SerializeObject(data);
            return Ok(result);
            


        }





    }
}
