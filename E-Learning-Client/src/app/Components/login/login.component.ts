import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../../Services/user.service';
import { UserStorageService } from '../../Services/user-storage.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  loginForm: FormGroup;
  isInValid: boolean = false;
  constructor(
    private _form: FormBuilder,
    private userService: UserService,
    private userStorage: UserStorageService,
    private router: Router
  ) {
    this.loginForm = _form.group({
      Email: ['', Validators.required],
      PasswordHash: ['', Validators.required],
    });
  }
  loginUser(form: FormGroup) {
    if (form.valid) {
      this.userService.getUsers().subscribe((response) => {
        console.log(response);
        var user = response.find((u) => u['email'] === form.value['Email']);
        if (user && user.passwordHash === form.value['PasswordHash']) {
          this.userStorage.setUser(user);
          if (user.role == 'LEARNER') {
            this.router.navigate(['/learner']);
          } else {
            this.router.navigate(['/trainer']);
          }
        } else {
          this.isInValid = true;
        }
      });
    } else {
      this.isInValid = true;
    }
  }
}
