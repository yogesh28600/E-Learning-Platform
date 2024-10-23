import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './Components/register/register.component';
import { LearnerHomeComponent } from './Components/learner-home/learner-home.component';
import { LoginComponent } from './Components/login/login.component';
import { TrainerHomeComponent } from './Components/trainer-home/trainer-home.component';
import { CourseFormComponent } from './Components/course-form/course-form.component';
import { CourseDetailsComponent } from './Components/course-details/course-details.component';
import { HomeComponent } from './Components/home/home.component';
import { ModuleFormComponent } from './Components/module-form/module-form.component';
import { ViewCourseComponent } from './Components/view-course/view-course.component';
import { BrowseCoursesComponent } from './Components/browse-courses/browse-courses.component';
import { EnrollCourseComponent } from './Components/enroll-course/enroll-course.component';
import { NotFoundComponent } from './Components/not-found/not-found.component';
import { PaymentCompleteComponent } from './Components/payment-complete/payment-complete.component';
import { EditModuleComponent } from './Components/edit-module/edit-module.component';

const routes: Routes = [
  { path: 'register', component: RegisterComponent },
  { path: 'learner', component: LearnerHomeComponent },
  { path: 'trainer', component: TrainerHomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'create-course', component: CourseFormComponent },
  { path: 'course-details/:courseId', component: CourseDetailsComponent },
  { path: 'create-module/:courseId', component: ModuleFormComponent },
  { path: 'view-course/:courseId', component: ViewCourseComponent },
  { path: 'browse-courses', component: BrowseCoursesComponent },
  { path: 'enroll-course/:courseId', component: EnrollCourseComponent },
  { path: 'edit-module/:moduleId', component: EditModuleComponent },
  { path: '', component: HomeComponent },
  {
    path: 'payment-success/:enrollmentId',
    component: PaymentCompleteComponent,
  },
  { path: 'not-found', component: NotFoundComponent },
  { path: '**', redirectTo: '/not-found' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
