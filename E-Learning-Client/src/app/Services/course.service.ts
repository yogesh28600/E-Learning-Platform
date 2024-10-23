import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CourseDTO } from '../Components/Models/CourseDTO';
import { ModuleDTO } from '../Components/Models/ModuleDTO';

@Injectable({
  providedIn: 'root',
})
export class CourseService {
  private baseUrl = 'http://localhost:5162/course-service/Course'; // adjust this as needed

  constructor(private http: HttpClient) {}

  // Set headers
  private headers = new HttpHeaders({
    'Content-Type': 'application/json',
  });

  // Get all courses
  getCourses(): Observable<CourseDTO[]> {
    return this.http.get<CourseDTO[]>(`${this.baseUrl}/GetCourses`, {
      headers: this.headers,
    });
  }

  // Get a course by Id
  getCourseById(id: string): Observable<CourseDTO> {
    return this.http.get<CourseDTO>(`${this.baseUrl}/GetCourseById/${id}`, {
      headers: this.headers,
    });
  }

  // Create a new course
  createCourse(course: CourseDTO): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/CreateCourse`, course, {
      headers: this.headers,
    });
  }

  // Update a course
  updateCourse(course: CourseDTO): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/UpdateCourse`, course, {
      headers: this.headers,
    });
  }

  // Delete a course by Id
  deleteCourse(id: string): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/DeleteCourse?id=${id}`, {
      headers: this.headers,
    });
  }

  // Get all modules
  getModules(): Observable<ModuleDTO[]> {
    return this.http.get<ModuleDTO[]>(`${this.baseUrl}/GetModules`, {
      headers: this.headers,
    });
  }

  // Get a module by Id
  getModuleById(id: string): Observable<ModuleDTO> {
    return this.http.get<ModuleDTO>(`${this.baseUrl}/GetModule?id=${id}`, {
      headers: this.headers,
    });
  }

  // Create a new module
  createModule(module: any): Observable<any> {
    return this.http.post<any>(`${this.baseUrl}/CreateModule`, module, {
      headers: this.headers,
    });
  }

  // Update a module
  updateModule(module: ModuleDTO): Observable<any> {
    return this.http.put<any>(`${this.baseUrl}/UpdateMoulue`, module, {
      headers: this.headers,
    });
  }

  // Delete a module by Id
  deleteModule(id: string): Observable<any> {
    return this.http.delete<any>(`${this.baseUrl}/DeleteModule?id=${id}`, {
      headers: this.headers,
    });
  }
}
