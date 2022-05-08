import { Component, OnInit } from '@angular/core';
import {
  FormBuilder as FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;

  constructor(
    private formBuildr: FormBuilder,
    private authService: AuthService
  ) {
    this.registerForm = this.formBuildr.group({
      email: ['', Validators.email],
      username: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  ngOnInit(): void {}

  register() {
    this.authService.register(this.registerForm.value).subscribe((data) => {
      console.log(data);
    });
  }

  get Email() {
    return this.registerForm.get('email');
  }
  get Username() {
    return this.registerForm.get('username');
  }
  get Password() {
    return this.registerForm.get('password');
  }
}
