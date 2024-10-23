import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CourseDTO } from '../Models/CourseDTO';
import { CourseService } from '../../Services/course.service';

@Component({
  selector: 'app-course-details',
  templateUrl: './course-details.component.html',
  styleUrl: './course-details.component.css',
})
export class CourseDetailsComponent {
  courseId: string;
  course!: CourseDTO;
  constructor(
    private routeParam: ActivatedRoute,
    private courseService: CourseService
  ) {
    this.courseId = this.routeParam.snapshot.params['courseId'];
    this.courseService.getCourseById(this.courseId).subscribe((response) => {
      this.course = response;
      this.courseService.getModules().subscribe((response) => {
        this.course.modules = response.filter(
          (x) => x.courseId === this.courseId
        );
      });
    });
  }
}
