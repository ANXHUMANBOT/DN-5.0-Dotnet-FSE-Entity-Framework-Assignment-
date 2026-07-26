import { Component } from '@angular/core';

@Component({
  selector: 'app-student-profile',
  imports: [],
  templateUrl: './student-profile.html',
  styleUrl: './student-profile.css'
})
export class StudentProfile {

  student = {
    name: 'Anshuman Dhal',
    regNo: '2301020225',
    branch: 'CSE (AI & ML)',
    college: 'CV Raman Global University'
  };

  profileImage = 'https://via.placeholder.com/150';

}