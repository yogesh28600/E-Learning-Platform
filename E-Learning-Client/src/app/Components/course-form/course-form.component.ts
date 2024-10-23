import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MediaService } from '../../Services/media.service';
import { CourseDTO } from '../Models/CourseDTO';
import { CourseService } from '../../Services/course.service';
import { Router } from '@angular/router';
import { UserStorageService } from '../../Services/user-storage.service';

@Component({
  selector: 'app-course-form',
  templateUrl: './course-form.component.html',
  styleUrl: './course-form.component.css',
})
export class CourseFormComponent {
  courseForm: FormGroup;
  id!: string;
  isInvalid: boolean = false;
  thumbnailFile: File | null = null; // To store the selected file
  constructor(
    private fb: FormBuilder,
    private mediaService: MediaService,
    private courseService: CourseService,
    private router: Router,
    private userStorage: UserStorageService
  ) {
    this.courseForm = this.fb.group({
      title: ['', [Validators.required]],
      description: ['', [Validators.required]],
      category: ['', Validators.required],
      thumbnail: [null, Validators.required],
      price: ['', [Validators.required, Validators.min(0)]],
    });
    this.userStorage.getUser().subscribe((response) => {
      response && (this.id = response?.id);
    });
  }
  // Handle file input change
  onFileChange(event: any): void {
    const file = event.target.files[0];
    if (file && file.type === 'image/png') {
      this.thumbnailFile = file;
      this.courseForm.patchValue({
        thumbnail: file, // Bind file to form control
      });
    } else {
      alert('Please select a valid PNG file.');
      this.courseForm.patchValue({
        thumbnail: null, // Reset thumbnail form control if invalid file
      });
    }
  }
  // Method to submit the form
  onSubmit(form: FormGroup): void {
    console.log(form.value);
    if (this.courseForm.valid) {
      // Check if thumbnail file is available for upload
      if (this.thumbnailFile) {
        this.mediaService.uploadMedia(this.thumbnailFile).subscribe({
          next: (thumbnailURL: string) => {
            // Create the course object once the thumbnail is successfully uploaded
            let course: any = {
              title: form.value['title'],
              description: form.value['description'],
              category: form.value['category'],
              trainerId: this.id, // You will replace this with the actual trainer ID
              thumbnail: thumbnailURL, // Set the uploaded thumbnail URL
              price: form.value['price'],
            };
            this.courseService.createCourse(course).subscribe((data) => {
              if (data) {
                this.router.navigate(['/trainer']);
              }
            });
          },
          error: (err) => {
            console.error('Error uploading media:', err);
          },
        });
      } else {
        console.error('No valid thumbnail file selected');
      }
    } else {
      this.isInvalid = true;
    }
  }
}
