import { Routes } from '@angular/router';
import { Home } from './components/home/home';
import { CourseList } from './components/course-list/course-list';
import { StudentProfile } from './components/student-profile/student-profile';

export const routes: Routes = [
  { path: '', component: Home },
  { path: 'courses', component: CourseList },
  { path: 'profile', component: StudentProfile }
];