import { Component } from '@angular/core';
import { CourseService } from '../../Services/course.service';
import { CourseDTO } from '../Models/CourseDTO';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-course-details',
  templateUrl: './view-course.component.html',
  styleUrls: ['./view-course.component.css'],
})
export class ViewCourseComponent {
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
  selectedVideoUrl: string | null = null;

  playVideo(videoUrl: string): void {
    console.log(videoUrl);
    this.selectedVideoUrl = videoUrl;
  }
}
