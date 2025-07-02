import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Student } from './student.model';

@Component({
  selector: 'app-student',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentListComponent {
  
}
