import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Course } from './course/models/course.model';
import { CourseComponent } from './course/course.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,CourseComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = '6_CourseCatalogDisplay';
}
