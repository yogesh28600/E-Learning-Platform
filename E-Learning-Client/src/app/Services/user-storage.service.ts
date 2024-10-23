import { Injectable } from '@angular/core';
import { UserDTO } from '../Components/Models/UserDTO';
import { User } from '../Types/User';
import { BehaviorSubject, Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserStorageService {
  private readonly USER_KEY = 'user'; // Key for storing user object in sessionStorage
  private userSubject = new BehaviorSubject<User | null>(null); // BehaviorSubject to hold user state

  constructor() {
    this.loadUserFromStorage(); // Load user from sessionStorage on service initialization
  }

  private loadUserFromStorage(): void {
    const userData = sessionStorage.getItem(this.USER_KEY);
    const user = userData ? JSON.parse(userData) : null;
    this.userSubject.next(user); // Emit the user state
  }

  // Method to set the user object and store it in sessionStorage
  setUser(user: UserDTO): Observable<void> {
    const data: User = {
      id: user.id,
      firstName: user.firstName,
      lastName: user.lastName,
      email: user.email,
      role: user.role, // Ensure this is the correct property
    };
    sessionStorage.setItem(this.USER_KEY, JSON.stringify(data));
    this.userSubject.next(data); // Update the BehaviorSubject with the new user
    return of(); // Return an observable that emits when done
  }

  // Method to get the user object from sessionStorage
  getUser(): Observable<User | null> {
    return this.userSubject.asObservable(); // Return the BehaviorSubject as an Observable
  }

  // Method to clear the user object from sessionStorage
  clearUser(): Observable<void> {
    sessionStorage.removeItem(this.USER_KEY);
    this.userSubject.next(null); // Clear the user state
    return of(); // Return an observable that emits when done
  }
}
