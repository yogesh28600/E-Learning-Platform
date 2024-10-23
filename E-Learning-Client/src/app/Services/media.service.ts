import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class MediaService {
  private apiUrl = 'http://localhost:5140/api/media'; // Replace with your actual API URL

  constructor(private http: HttpClient) {}

  // Upload a media file (image or video)
  uploadMedia(file: File): Observable<string> {
    const formData = new FormData();
    formData.append('file', file);

    return this.http.post(this.apiUrl + '/upload', formData, {
      responseType: 'text', // Expect plain text response
    });
  }

  // // Download a media file by its filename
  // downloadMedia(filename: string): Observable<Blob> {
  //   return this.http.get(`${this.apiUrl}/download/${filename}`, {
  //     responseType: 'blob'
  //   });
  // }

  // // Delete a media file by its URL
  // deleteMedia(url: string): Observable<any> {
  //   const encodedUrl = encodeURIComponent(url);  // Ensure the URL is properly encoded
  //   return this.http.delete(`${this.apiUrl}/delete/${encodedUrl}`);
  // }
}
