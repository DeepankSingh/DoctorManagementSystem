using System;
using System.Data;
using Azure.Core;
using DoctorManagement.DAL.Contract;
using DoctorManagement.DAL.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DoctorManagement.DAL.Behavior
{
    public class DoctorRepository
    {
        private readonly string? _dbstring = new HealthcareManagementContext().Database.GetConnectionString();



        // GET ALL
            public DoctorResponseDAL GetAllDoctorRegistrations()
        {
            DoctorResponseDAL response = new DoctorResponseDAL();
            DataTable dt = new DataTable();


            using (SqlConnection con = new SqlConnection(_dbstring))
            using (SqlCommand cmd = new SqlCommand("SP_GetAllDoctorRegistrations", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            response.DataTable = dt;
            response.Success = true;
            response.Message = "Records fetched successfully.";


            return response;
        }

        // INSERT
        public DoctorResponseDAL InsertDoctorRegistration(DoctorRequestDAL req)
        {
            DoctorResponseDAL response = new DoctorResponseDAL();
            DataTable dt = new DataTable();


            using (SqlConnection con = new SqlConnection(_dbstring))
            using (SqlCommand cmd = new SqlCommand("SP_InsertDoctorRegistration", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LicenseNumber", req.LicenseNumber);
                cmd.Parameters.AddWithValue("@IssueDate", req.IssueDate);
                cmd.Parameters.AddWithValue("@ExpiryDate", req.ExpiryDate);
                cmd.Parameters.AddWithValue("@ContactNumber", req.ContactNumber);
                cmd.Parameters.AddWithValue("@NetworkId", req.NetworkId);
                cmd.Parameters.AddWithValue("@HospitalId", req.HospitalId);
                cmd.Parameters.AddWithValue("@DepartmentId", req.DepartmentId);
                cmd.Parameters.AddWithValue("@DoctorId", req.DoctorId);
                //cmd.Parameters.AddWithValue("@IsActive", req.IsActive);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            response.DataTable = dt;
            response.Success = true;
            response.Message = "New doctor registration added.";


            return response;
        }



        // UPDATE
        public DoctorResponseDAL UpdateDoctorRegistration(DoctorRequestDAL req)
        {
            DoctorResponseDAL response = new DoctorResponseDAL();
            DataTable dt = new DataTable();


            using (SqlConnection con = new SqlConnection(_dbstring))
            using (SqlCommand cmd = new SqlCommand("SP_UpdateDoctorRegistration", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RegistrationId", req.RegistrationId);
                cmd.Parameters.AddWithValue("@LicenseNumber", req.LicenseNumber);
                cmd.Parameters.AddWithValue("@IssueDate", req.IssueDate);
                cmd.Parameters.AddWithValue("@ExpiryDate", req.ExpiryDate);
                cmd.Parameters.AddWithValue("@ContactNumber", req.ContactNumber);
                cmd.Parameters.AddWithValue("@NetworkId", req.NetworkId);
                cmd.Parameters.AddWithValue("@HospitalId", req.HospitalId);
                cmd.Parameters.AddWithValue("@DepartmentId", req.DepartmentId);
                cmd.Parameters.AddWithValue("@DoctorId", req.DoctorId);
                //cmd.Parameters.AddWithValue("@IsActive", req.IsActive);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            response.DataTable = dt;
            response.Success = true;
            response.Message = "Doctor registration updated.";


            return response;
        }

        // DELETE 
        public DoctorResponseDAL DeleteDoctorRegistration(DoctorRequestDAL req)
        {
            DoctorResponseDAL response = new DoctorResponseDAL();
            DataTable dt = new DataTable();


            using (SqlConnection con = new SqlConnection(_dbstring))
            using (SqlCommand cmd = new SqlCommand("SP_DeleteDoctorRegistration", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RegistrationId", req.RegistrationId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            response.DataTable = dt;
            response.Success = true;
            response.Message = "Doctor registration deleted.";


            return response;
        }

        // SEARCH
        public DoctorResponseDAL SearchDoctorRegistrations(DoctorRequestDAL req)
        {
            DoctorResponseDAL response = new DoctorResponseDAL();
            DataTable dt = new DataTable();


            using (SqlConnection con = new SqlConnection(_dbstring))
            using (SqlCommand cmd = new SqlCommand("SP_SearchDoctorRegistrations", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@SearchTerm", req.SearchTerm ?? (object)DBNull.Value);


                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            response.DataTable = dt;
            response.Success = true;
            response.Message = "Search completed.";

            return response;
        }

        public DoctorResponseDAL GetDoctorById(DoctorRequestDAL dalRequest)
        {
            DoctorResponseDAL response = new DoctorResponseDAL();
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = new SqlConnection(_dbstring))
                using (SqlCommand cmd = new SqlCommand("SP_GetDoctorById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistrationId", SqlDbType.Int).Value = dalRequest.RegistrationId;

                    con.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                response.DataTable = dt;

                if (dt.Rows.Count > 0)
                {
                    response.Success = true;
                    response.Message = "Record fetched successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "No record found for the given ID.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error: " + ex.Message;
            }

            return response;
        }



        public DoctorResponseDAL GetNetworks()
        {
            DoctorResponseDAL response = new DoctorResponseDAL();

            try
            {
                using (SqlConnection conn = new SqlConnection(_dbstring))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetNetworks", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        response.DataTable = dt;
                        response.Success = true;
                        response.Message = "Networks fetched successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }


        public DoctorResponseDAL GetHospitalsByNetwork(DoctorRequestDAL request)
        {
            DoctorResponseDAL response = new DoctorResponseDAL();

            try
            {
                using (SqlConnection conn = new SqlConnection(_dbstring))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_GetHospitalsByNetwork", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@NetworkId", request.NetworkId);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        response.DataTable = dt;
                        response.Success = true;
                        response.Message = "Hospitals fetched successfully";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }



        public DoctorResponseDAL GetDepartmentsByHospital(DoctorRequestDAL request)
        {
            DoctorResponseDAL response = new DoctorResponseDAL();

            try
            {
                using (SqlConnection con = new SqlConnection(_dbstring))
                using (SqlCommand cmd = new SqlCommand("sp_GetDepartmentsByHospital", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@HospitalId", request.HospitalId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    response.DataTable = dt;
                    response.Message = "Departments fetched successfully";
                    response.Success = true;
                }
            }
            catch (Exception ex)
            {
                response.DataTable = null;
                response.Message = ex.Message;
                response.Success = false;
            }

            return response;
        }


        public DoctorResponseDAL GetDoctorsByDepartment(DoctorRequestDAL request)
        {
            DoctorResponseDAL response = new DoctorResponseDAL();

            try
            {
                using (SqlConnection con = new SqlConnection(_dbstring))
                using (SqlCommand cmd = new SqlCommand("sp_GetDoctorsByDepartment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DepartmentId", request.DepartmentId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    response.DataTable = dt;
                    response.Success = true;
                    response.Message = "Doctors fetched successfully";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

      

        public DoctorResponseDAL GetMasterData(DoctorRequestDAL dalrequest)
        {
            DoctorResponseDAL response = new DoctorResponseDAL();
            DataTable dt = new DataTable();

            using(SqlConnection con = new SqlConnection(_dbstring))
            using (SqlCommand cmd = new SqlCommand("Sp_GetMasterData", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Mode", dalrequest.Mode);
                cmd.Parameters.AddWithValue("@RegistrationId", dalrequest.RegistrationId ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NetworkId", dalrequest.NetworkId ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@HospitalId", dalrequest.HospitalId ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DepartmentId", dalrequest.DepartmentId ?? (object)DBNull.Value);


                SqlDataAdapter da = new SqlDataAdapter(cmd);    
                da.Fill(dt);
            }

            response.DataTable = dt;
            response.Message = "Data fetched successfully";
            response.Success = true;

            return response;
        }
    }
}





