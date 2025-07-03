import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { StudentFeedback } from './student-feedback/models/student-feedback.model';
import { StudentFeedbackComponent } from './student-feedback/student-feedback.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,StudentFeedbackComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = '7_StudentFeedbackForm';
}
