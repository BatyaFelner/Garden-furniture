import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AuthService {

  signUpFields = [
    { label: 'ID', name: 'id', type: 'text', required: true, pattern: /^\d{9}$/, errorMessage: 'ID must be 9 digits' },
    { label: 'Name', name: 'clientName', type: 'text', required: true, minlength: 2, errorMessage: 'Name is too short' },
    { label: 'Phone', name: 'phone', type: 'text', required: true, pattern: /^05\d{8}$/, errorMessage: 'Invalid phone number' },
    { label: 'Email', name: 'email', type: 'email', required: true, pattern: /^\S+@\S+\.\S+$/, errorMessage: 'Invalid email address' },
    { label: 'Birth Date', name: 'bearthDate', type: 'date', required: true, errorMessage: 'Birth date is required' },
  ];

  loginFields = [
    { label: 'Email', name: 'email', type: 'email', required: true, pattern: /\S+@\S+\.\S+/ },
    { label: 'Password', name: 'password', type: 'password', required: true, minlength: 6 },
  ];


  getFields(l:string) {
    return l == 'signUp' ? this.signUpFields : this.loginFields;
  }
}
