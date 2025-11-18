import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {


  private apiUrl = 'https://localhost:7070/api/DoctorManagement';

  constructor(private http: HttpClient) { }

  // GET ALL
  getAllDoctorEntries() {
    return this.http.get<any>(`${this.apiUrl}/GetAllDoctorEntries`);
  }

  // SEARCH 
  searchDoctorEntries(searchTerm: string) {
    return this.http.get<any>(`${this.apiUrl}/SearchDoctorEntries/${searchTerm}`);
  }

  // DELETE 
  deleteDoctorEntry(id: number) {
    return this.http.delete<any>(`${this.apiUrl}/DeleteDoctorEntry/${id}`);
  }

  // ADD DOCTOR
  addDoctor(data: any) {
    return this.http.post<any>(`${this.apiUrl}/AddDoctorEntry`, data);
  }

  


  updateDoctor(model: any) {
    return this.http.put(`${this.apiUrl}/UpdateDoctorEntry`, model);
  }

  //for prefilled data
  getDoctorById(id: number) {
    return this.http.get(`${this.apiUrl}/GetDoctorById?registrationId=${id}`);
  }

  // getNetworks() {
  //   return this.http.get(`${this.apiUrl}/GetNetworks`);
  // }

  // getHospitalsByNetwork(networkId: number) {
  //   return this.http.get(`${this.apiUrl}/GetHospitalsByNetwork?networkId=${networkId}`);
  // }


  //GetHospitalsByNetwork

  // getDepartmentsByHospital(hospitalId: number) {
  //   return this.http.get(`${this.apiUrl}/GetDepartmentsByHospital?hospitalId=${hospitalId}`);
  // }

  // getDoctorsByDepartment(departmentId: number) {
  //   return this.http.get(`${this.apiUrl}/GetDoctorsByDepartment?departmentId=${departmentId}`);
  // }

  getMasterData(mode: string, id?: number) {
  return this.http.get(`${this.apiUrl}/GetMasterData?mode=${mode}&id=${id}`);
}


}
