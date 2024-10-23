import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseDTO } from '../Models/CourseDTO';
import { CourseService } from '../../Services/course.service';

@Component({
  selector: 'app-course-details',
  templateUrl: './course-details.component.html',
  styleUrls: ['./course-details.component.css'], // Fixed typo 'styleUrl' to 'styleUrls'
})
export class CourseDetailsComponent {
  courseId: string;
  course!: CourseDTO;

  constructor(
    private routeParam: ActivatedRoute,
    private courseService: CourseService
  ) {
    this.courseId = this.routeParam.snapshot.params['courseId'];
    this.loadCourseDetails();
  }

  // Method to load course details and its associated modules
  loadCourseDetails() {
    this.courseService.getCourseById(this.courseId).subscribe((response) => {
      this.course = response;
      this.loadModules();
    });
  }

  // Method to load modules associated with the course
  loadModules() {
    this.courseService.getModules().subscribe((response) => {
      this.course.modules = response.filter(
        (x) => x.courseId === this.courseId
      );
    });
  }

  // Method to delete a module and refresh the module list
  deleteModule(id: string) {
    this.courseService.deleteModule(id).subscribe(() => {
      // Refresh the module list after successful deletion
      this.loadModules();
    });
  }
}
