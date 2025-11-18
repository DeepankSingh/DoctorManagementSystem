import { Component, OnInit } from '@angular/core';
import { DoctorService } from 'src/app/services/doctor.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { NumberSymbol } from '@angular/common';



@Component({
  selector: 'app-add-form',
  templateUrl: './add-form.component.html',
  styleUrls: ['./add-form.component.css']
})
export class AddFormComponent {


networks: any[] = [];
hospitals: any[] = [];
departments: any[] = [];
doctors: any[] = [];
  
  showAddForm: boolean = true;

  isEditMode = false;

  addModel: any = {
  DoctorId: 0,
  LicenseNumber: "",
  ContactNumber: "",
  NetworkId: 0,
  HospitalId: 0,
  DepartmentId: 0,
  IssueDate: "",
  ExpiryDate: "",
};



  constructor(private doctorService: DoctorService, private router: Router, private route: ActivatedRoute){}

ngOnInit() {
  const id = this.route.snapshot.paramMap.get('id');

  this.loadNetworks(()=>{
    if (id) {
      this.isEditMode = true;
      this.loadDoctorData(id);
    }
  });
}

  

 async loadDoctorData(id: string) {
  await this.doctorService.getMasterData('DoctorById',Number(id)).subscribe(async(res:any)=>{
    const d = res[0];

    this.addModel = {
      RegistrationId: d.RegistrationId,
      DoctorId: Number(d.DoctorId),
      LicenseNumber: d.LicenseNumber,
      ContactNumber: d.ContactNumber,
      NetworkId: Number(d.NetworkId),
      HospitalId: 0,
      DepartmentId: Number(d.DepartmentId),
      IssueDate: d.IssueDate.split("T")[0],
      ExpiryDate: d.ExpiryDate.split("T")[0]
    };

    await this.loadHospitalsForPrefill();
    this.addModel.HospitalId = d.HospitalId;
    await this.loadDepartmentsForPrefill();
    this.addModel.DepartmentId = d.DepartmentId;
    await this.loadDoctorsForPrefill();
    this.addModel.DoctorId = d.DoctorId;

  });
}



loadNetworks(callback?: Function) {
  this.doctorService.getMasterData('Networks', 0).subscribe((res: any) => {
    this.networks = res;

    if (callback) callback();  
  });
}


async loadHospitalsForPrefill() {
  await this.doctorService.getMasterData('HospitalsByNetwork',this.addModel.NetworkId).subscribe(async(res: any) => {
    this.hospitals = res;
    // this.loadDepartmentsForPrefill();
  });
}

async loadDepartmentsForPrefill() {
 await this.doctorService.getMasterData('DepartmentsByHospitals',this.addModel.HospitalId).subscribe(async(res: any) => {
    this.departments = res;

    // this.loadDoctorsForPrefill();
  });
}

async loadDoctorsForPrefill() {
 await this.doctorService.getMasterData('DoctorsByDepartment',this.addModel.DepartmentId).subscribe(async(res: any) => {
    this.doctors = res;
  });
}

onNetworkChange() {
  console.log(this.addModel.NetworkId);
  this.doctorService.getMasterData('HospitalsByNetwork',this.addModel.NetworkId)
    .subscribe((res: any) => {
      this.hospitals = res;
      this.departments = [];
      this.doctors = [];
      this.addModel.HospitalId = null;
      this.addModel.DepartmentId = null;
      this.addModel.DoctorId = null;
    });

}

onHospitalChange() {
  this.doctorService.getMasterData('DepartmentsByHospitals',this.addModel.HospitalId)
    .subscribe((res: any) => {
      this.departments = res;
      this.doctors = [];
      this.addModel.DepartmentId = null;
      this.addModel.DoctorId = null;
    });
}

onDepartmentChange() {
  this.doctorService.getMasterData('DoctorsByDepartment',this.addModel.DepartmentId)
    .subscribe((res: any) => {
      this.doctors = res;
      this.addModel.DoctorId = null;
    });
}


  
closeAddForm() {
  this.router.navigate(['/doctor-list']);
}


updateDoctor(){
    this.addModel.IssueDate = new Date(this.addModel.IssueDate).toISOString();
  this.addModel.ExpiryDate = new Date(this.addModel.ExpiryDate).toISOString();
  
  this.doctorService.updateDoctor(this.addModel).subscribe(() => {
    
    alert('Doctor updated successfully!');
    this.router.navigate(['/doctor-list']);
  });

}

addDoctor(){
  // this.addModel.issueDate = new Date(this.addModel.issueDate).toISOString();
  // this.addModel.expiryDate = new Date(this.addModel.expiryDate).toISOString();
  
  this.doctorService.addDoctor(this.addModel).subscribe(
    (res: any) => {
      alert("Doctor added successfully!");
      this.router.navigate(['/doctor-list']);

       
    },
    (err: any) => {
      console.error(err);
      alert("Failed to add doctor.");
    }
  );

}

submitAddForm() {
   if (this.isEditMode) {
    this.updateDoctor();
  } else {
    this.addDoctor();
  }
}



}
