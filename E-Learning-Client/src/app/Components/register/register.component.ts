import { Component } from '@angular/core';
import {
  EmailValidator,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { UserService } from '../../Services/user.service';
import { UserStorageService } from '../../Services/user-storage.service';
import { Router } from '@angular/router';
import { UserDTO } from '../Models/UserDTO';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  registerForm: FormGroup;
  userExists: boolean = false;
  isInValid: boolean = false;
  constructor(
    private _form: FormBuilder,
    private userService: UserService,
    private userStorage: UserStorageService,
    private router: Router
  ) {
    this.registerForm = _form.group({
      FirstName: ['', Validators.required],
      LastName: ['', Validators.required],
      Email: ['', Validators.required],
      PasswordHash: ['', Validators.required],
      Role: ['', Validators.required],
    });
  }
  registerUser(form: FormGroup) {
    if (form.valid) {
      this.userService.getUsers().subscribe((response) => {
        let user = response.find((x) => x.email === form.value['Email']);
        if (user) {
          this.userExists = true;
        } else {
          this.userService.createUser(form.value).subscribe((response) => {
            this.userService.getUserById(response).subscribe((data) => {
              this.userStorage.setUser(data);
              if (data.role === 'LEARNER') {
                this.router.navigate(['/learner']);
              } else {
                this.router.navigate(['/trainer']);
              }
            });
          });
        }
      });
    } else {
      this.isInValid = true;
    }
  }
}
