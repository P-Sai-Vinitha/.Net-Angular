import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { Student } from './student/student.model';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'student-list-management-app';

  students: Student[] = [
    { name: 'Alice', marks: 85, status: true },
    { name: 'Bob', marks: 42, status: false },
    { name: 'Charlie', marks: 73, status: true }
  ];
}
