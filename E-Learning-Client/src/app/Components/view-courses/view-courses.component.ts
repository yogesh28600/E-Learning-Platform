import { Component } from '@angular/core';
import { CourseDTO } from '../Models/CourseDTO';
import { CourseService } from '../../Services/course.service';

@Component({
  selector: 'app-view-courses',
  templateUrl: './view-courses.component.html',
  styleUrl: './view-courses.component.css',
})
export class ViewCoursesComponent {
  courses!: CourseDTO[];
  constructor(private courseService: CourseService) {
    this.courseService.getCourses().subscribe((response) => {
      this.courses = response;
      this.courseService.getModules().subscribe((response) => {
        this.courses.map((course) => {
          course.modules = response.filter((c) => c.courseId == course.id);
        });
      });
    });
  }
}
