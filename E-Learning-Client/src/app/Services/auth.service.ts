import { Injectable } from '@angular/core';
import { User } from '../Types/User';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private current_user!: string;
  constructor() {
    console.log('hi');
  }
  setUserId(id: string) {
    this.current_user = id;
  }
  getUserId() {
    return this.current_user;
  }
}
