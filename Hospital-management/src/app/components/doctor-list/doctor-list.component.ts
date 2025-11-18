import { Component,OnInit } from '@angular/core';
import { DoctorService } from '../../services/doctor.service';
import {Router} from '@angular/router';

@Component({
  selector: 'app-doctor-list',
  templateUrl: './doctor-list.component.html',
  styleUrls: ['./doctor-list.component.css']
})
export class DoctorListComponent {

doctorList: any[] = [];
  searchTerm: string = "";
  showAddForm: boolean = false;


  


  constructor(private doctorService: DoctorService, private router: Router) {}

  editEntry(id: number){
    this.router.navigate(['/add',id]);
  }

  ngOnInit(): void {
    this.loadDoctorEntries();
          

  }


  

  loadDoctorEntries() {
    this.doctorService.getAllDoctorEntries().subscribe({
      next: (res) => {
        this.doctorList = res.data; 
      },
      error: (err) => {
        console.error("API Error:", err);
      }
    });
  }


  
  

  // Search
  searchDoctors() {
    if (!this.searchTerm.trim()) {
      this.loadDoctorEntries();
      return;
    }

    this.doctorService.searchDoctorEntries(this.searchTerm).subscribe({
      next: (res) => {
        this.doctorList = res.data;
      },
      error: (err) => console.error("Search API Error:", err)
    });
  }

  //  Reset Search
  resetSearch() {
    this.searchTerm = "";
    this.loadDoctorEntries();
  }

  

  // Delete 
  deleteDoctor(id: number) {

    
    if (confirm("Are you sure you want to delete this doctor?")) {
      this.doctorService.deleteDoctorEntry(id).subscribe({
        next: (res) => {
          console.log("Deleting doctor:", res);
          alert("Doctor deleted!");
          
          this.loadDoctorEntries();
        },
        error: (err) => console.error("Delete Error:", err)
      });
    }
  }


  

goToAddForm(){
  this.router.navigate(['/add-registration']);
  this.showAddForm = true;
  
}

editDoctor(id: number){
  this.router.navigate(['/add-registration', id]);
}


}

