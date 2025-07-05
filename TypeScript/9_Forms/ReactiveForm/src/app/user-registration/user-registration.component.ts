import { Component } from '@angular/core';
import { UserRegistration } from './models/user-registration.model';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-registration',
  imports: [ReactiveFormsModule,CommonModule],
  templateUrl: './user-registration.component.html',
  styleUrl: './user-registration.component.css'
})
export class UserRegistrationComponent {
  registrationForm: FormGroup = new FormGroup(
  {
    fullName:new FormControl(),
    email:new FormControl(),
    gender:new FormControl(),
    country:new FormControl(),
    agreeToTerms:new FormControl(0)
  }
);
  
OnSubmit(){
    const userData:UserRegistration=this.registrationForm.value;
    console.log('Registration Data:',userData);
  }
}
