import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EnrollmentDTO } from '../Components/Models/EnrollmentDTO'; // Adjust the path as necessary

@Injectable({
  providedIn: 'root',
})
export class EnrollmentService {
  private baseUrl = 'http://localhost:5050/enrollment-service/enrollment'; // Adjust base URL as needed

  constructor(private http: HttpClient) {}

  // Enrollment Methods
  getEnrollments(): Observable<EnrollmentDTO[]> {
    return this.http.get<EnrollmentDTO[]>(`${this.baseUrl}/GetEnrollment`);
  }

  getEnrollmentById(id: string): Observable<EnrollmentDTO> {
    return this.http.get<EnrollmentDTO>(
      `${this.baseUrl}/GetEnrollmentById?id=${id}`
    );
  }

  createEnrollment(enrollment: any): Observable<EnrollmentDTO> {
    return this.http.post<EnrollmentDTO>(
      `${this.baseUrl}/CreateEnrollment`,
      enrollment
    );
  }

  updateEnrollment(enrollment: EnrollmentDTO): Observable<EnrollmentDTO> {
    return this.http.put<EnrollmentDTO>(
      `${this.baseUrl}/UpdateEnrollment`,
      enrollment
    );
  }

  deleteEnrollment(id: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/DeleteEnrollment?id=${id}`);
  }
}
