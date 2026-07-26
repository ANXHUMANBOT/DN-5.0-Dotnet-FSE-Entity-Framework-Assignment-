import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class Course {

  getCourses() {
    return [
      'Angular',
      '.NET',
      'Java',
      'SQL'
    ];
  }

}