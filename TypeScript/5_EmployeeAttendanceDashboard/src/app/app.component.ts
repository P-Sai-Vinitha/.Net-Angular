
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Employee } from './employee/employee.model';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet,CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class App {
  title = 'employee-attendance-dashboard-app';

  employees: Employee[] = [
    { Name: 'Alice', Department: 'IT', IsPresent: true, WorkFromHome: false },
    { Name: 'Bob', Department: 'HR', IsPresent: false, WorkFromHome: true  },
    { Name: 'Charlie', Department: 'Sales', IsPresent: false, WorkFromHome: false  },
  ];
}
