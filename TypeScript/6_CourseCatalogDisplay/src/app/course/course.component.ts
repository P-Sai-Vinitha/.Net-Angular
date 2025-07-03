import { Component } from '@angular/core';
import { Course } from './models/course.model';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-course',
  imports: [CommonModule],
  templateUrl: './course.component.html',
  styleUrl: './course.component.css'
})
export class CourseComponent {
  courses: Course[] = [
    {
      id: 1,
      title: 'ANGULAR FUNDAMENTALS',
      instructor: 'john doe',
      startDate: new Date(2025, 6, 15),
      price: 4999.99,
      description: 'Learn the basics of Angular includ...'
    },
    {
      id: 2,
      title: 'REACT BASICS',
      instructor: 'jane smith',
      startDate: new Date(2025, 7, 20),
      price: 3499,
      description: 'Build Interactive UIs with Reac...'
    }
  ];
}
