import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserDTO } from '../Components/Models/UserDTO';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private baseUrl = 'http://localhost:5072/user-service/User'; // Update this with your actual API URL

  constructor(private http: HttpClient) {}

  // Set headers
  private headers = new HttpHeaders({
    'Content-Type': 'application/json',
  });

  // Get all users
  getUsers(): Observable<UserDTO[]> {
    return this.http.get<UserDTO[]>(`${this.baseUrl}/GetUsers`, {
      headers: this.headers,
    });
  }

  // Get a user by Id
  getUserById(id: string): Observable<UserDTO> {
    return this.http.get<UserDTO>(`${this.baseUrl}/GetUser?id=${id}`, {
      headers: this.headers,
    });
  }

  // Create a new user
  createUser(user: UserDTO): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/CreateUser`, user, {
      headers: this.headers,
    });
  }

  // Update an existing user
  updateUser(user: UserDTO): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/UpdateUser`, user, {
      headers: this.headers,
    });
  }

  // Delete a user by Id
  deleteUser(id: string): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/DeleteUser?id=${id}`, {
      headers: this.headers,
    });
  }
}
