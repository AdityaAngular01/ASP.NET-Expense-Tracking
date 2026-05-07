import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
  AbstractControl,
  ValidationErrors,
  ValidatorFn,
} from '@angular/forms';
import { confirmPasswordValidator, passwordStrengthValidator } from './password.validators';
import { ErrorMessage } from '../../shared/error-message/error-message';

@Component({
  selector: 'app-auth',
  imports: [CommonModule, ReactiveFormsModule, ErrorMessage],
  templateUrl: './auth.html',
  styleUrl: './auth.css',
})
export class Auth implements OnInit {
  isLogin: boolean = true;
  loginForm!: FormGroup;
  registerForm!: FormGroup;
  constructor() {}

  ngOnInit() {
    this.initLoginForm();
    this.initRegisterForm();
  }

  initLoginForm() {
    this.loginForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
    });
  }

  initRegisterForm() {
    this.registerForm = new FormGroup(
      {
        name: new FormControl('', [Validators.required, Validators.minLength(3)]),
        email: new FormControl('', [Validators.required, Validators.email]),
        password: new FormControl('', [Validators.required, passwordStrengthValidator()]),
        confirmPassword: new FormControl('', [Validators.required]),
      },
      {
        validators: confirmPasswordValidator('password', 'confirmPassword'),
      },
    );
  }

  get password() {
    return this.registerForm.get('password');
  }

  get confirmPassword() {
    return this.registerForm.get('confirmPassword');
  }

  get name() {
    return this.registerForm.get('name');
  }

  get email() {
    return this.registerForm.get('email');
  }

  handleLoggedIn(): void {
    console.log(this.loginForm.value);
  }

  handleRegister(): void {
    console.log(this.registerForm.value);
  }
}
