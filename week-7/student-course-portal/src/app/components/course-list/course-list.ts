import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Course } from '../../services/course';

@Component({
  selector: 'app-course-list',
  imports: [CommonModule],
  templateUrl: './course-list.html',
  styleUrl: './course-list.css'
})
export class CourseList {

  courses: string[] = [];

  constructor(private courseService: Course) {
    this.courses = this.courseService.getCourses();
  }

}