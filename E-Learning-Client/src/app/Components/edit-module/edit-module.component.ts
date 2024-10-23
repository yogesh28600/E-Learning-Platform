import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MediaService } from '../../Services/media.service';
import { CourseService } from '../../Services/course.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UserStorageService } from '../../Services/user-storage.service';
import { ModuleDTO } from '../Models/ModuleDTO';

@Component({
  selector: 'app-edit-module',
  templateUrl: './edit-module.component.html',
  styleUrls: ['./edit-module.component.css'], // Fixed typo 'styleUrl' to 'styleUrls'
})
export class EditModuleComponent implements OnInit {
  Id!: string;
  module: ModuleDTO | null = null;
  moduleForm: FormGroup;
  videoFile: File | null = null; // To store the selected file
  isInvalid: boolean = false;

  constructor(
    private fb: FormBuilder,
    private mediaService: MediaService,
    private courseService: CourseService,
    private router: Router,
    private userStorage: UserStorageService,
    private actRouter: ActivatedRoute
  ) {
    // Extract courseId from the route
    this.Id = this.actRouter.snapshot.params['courseId'];

    // Initialize the form
    this.moduleForm = this.fb.group({
      title: ['', [Validators.required]],
      video: [null, Validators.required], // video file is required
    });
  }

  ngOnInit(): void {
    let moduleId = this.actRouter.snapshot.params['moduleId'];

    // Load the module details and pre-populate the form
    this.courseService.getModuleById(moduleId).subscribe((response) => {
      this.module = response;

      // Patch the form with existing module data
      this.moduleForm.patchValue({
        title: this.module.title,
      });
    });
  }

  // Handle file input change
  onFileChange(event: any): void {
    const file = event.target.files[0];
    if (file && file.type === 'video/mp4') {
      this.videoFile = file;
      this.moduleForm.patchValue({
        video: file, // Bind file to form control
      });
    } else {
      alert('Please select a valid mp4 file.');
      this.moduleForm.patchValue({
        video: null, // Reset video form control if invalid file
      });
    }
  }

  // Method to submit the form
  onSubmit(form: FormGroup): void {
    if (form.valid) {
      // Check if video file is available for upload
      if (this.videoFile) {
        this.mediaService.uploadMedia(this.videoFile).subscribe({
          next: (videoURL: string) => {
            // Create the module object once the video is successfully uploaded
            const module = {
              id: this.module?.id,
              title: this.moduleForm.value['title'],
              courseId: this.module?.courseId,
              videoUrl: videoURL, // Set the uploaded video URL
              additionalResources: 'dummy',
            };
            console.log(module);
            // Call courseService to create the module
            this.courseService.updateModule(module).subscribe({
              next: () => {
                this.router.navigate(['/trainer']);
              },
              error: (err) => {
                console.error('Error creating module:', err);
              },
            });
          },
          error: (err) => {
            console.error('Error uploading media:', err);
          },
        });
      } else {
        this.isInvalid = true;
      }
    } else {
      this.isInvalid = true;
    }
  }
}
