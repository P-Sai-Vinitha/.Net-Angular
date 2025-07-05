import { Component } from '@angular/core';
import { UserRegistration } from './models/user-registration.model';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-user-registration',
  imports: [FormsModule,CommonModule],
  templateUrl: './user-registration.component.html',
  styleUrl: './user-registration.component.css'
})
export class UserRegistrationComponent {
  user:UserRegistration={
    fullName:'',
    email:'',
    gender:'',
    country:'',
    agreeToTerms:false
  }

  onSubmit(form: any) {
    if (form.valid) {
      console.log('Form Submitted',this.user);
    }else{
      console.log('Form is invalid');
    }
  }

}
