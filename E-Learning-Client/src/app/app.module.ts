import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './Components/register/register.component';
import { HeaderComponent } from './Components/header/header.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { provideHttpClient } from '@angular/common/http';
import { LearnerHomeComponent } from './Components/learner-home/learner-home.component';
import { TrainerHomeComponent } from './Components/trainer-home/trainer-home.component';
import { LoginComponent } from './Components/login/login.component';
import { CourseFormComponent } from './Components/course-form/course-form.component';
import { CourseDetailsComponent } from './Components/course-details/course-details.component';
import { HomeComponent } from './Components/home/home.component';
import { ModuleFormComponent } from './Components/module-form/module-form.component';
import { ViewCoursesComponent } from './Components/view-courses/view-courses.component';
import { ViewCourseComponent } from './Components/view-course/view-course.component';
import { BrowseCoursesComponent } from './Components/browse-courses/browse-courses.component';
import { EnrollCourseComponent } from './Components/enroll-course/enroll-course.component';
import { NotFoundComponent } from './Components/not-found/not-found.component';
import { PaymentCompleteComponent } from './Components/payment-complete/payment-complete.component';
import { EditModuleComponent } from './Components/edit-module/edit-module.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    HeaderComponent,
    LearnerHomeComponent,
    TrainerHomeComponent,
    LoginComponent,
    CourseFormComponent,
    CourseDetailsComponent,
    HomeComponent,
    ModuleFormComponent,
    ViewCoursesComponent,
    ViewCourseComponent,
    BrowseCoursesComponent,
    EnrollCourseComponent,
    NotFoundComponent,
    PaymentCompleteComponent,
    EditModuleComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, ReactiveFormsModule, FormsModule],
  providers: [provideHttpClient()],
  bootstrap: [AppComponent],
})
export class AppModule {}
