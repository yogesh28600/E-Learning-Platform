# E-Learning Platform

## 1. Introduction
The E-Learning platform enables learners to enroll in courses, watch lectures, and interact with content, while trainers can create and manage courses. The platform will be built using .NET Core Web API for the backend and Angular for the frontend, following a microservices architecture to allow for scalability, flexibility, and ease of development.

## 2. Features

### 2.1. Learner Features
- **Account Creation/Management**: Learners can register, log in, and manage their profiles.
- **Course Enrollment**: Learners can browse available courses, view course details, and enroll.
- **Course Progress Tracking**: Track the progress of each course, including completed lectures and assessments.
- **Watch Classes**: Stream or download pre-recorded lectures or live sessions.

### 2.2. Trainer Features
- **Trainer Registration**: Trainers can sign up and manage their profile.
- **Course Creation/Management**: Trainers can create, edit, and delete courses with multiple modules and lectures.
- **Upload Course Material**: Upload videos, PDF materials, assignments, and quizzes.
- **View Learner Progress**: Monitor the progress and performance of enrolled learners.

### 2.3. Admin Features
- **User Management**: Admin can manage learners, trainers, and their roles.
- **Course Approval**: Review and approve courses submitted by trainers before publishing.
- **Platform Analytics**: View overall platform statistics like user growth, active users, and course performance.

## 3. Non-Functional Requirements
- **Performance**: API response times must be under 200ms for most actions.
- **Reliability**: Ensure high availability of services with appropriate fault-tolerant mechanisms.
- **Maintainability**: The codebase should be modular and follow best practices for microservices.

---

## Project Architecture

### 1. Architecture Overview
The platform will follow a microservices architecture, where each core feature (e.g., user management, course management) will be managed by individual services. Communication between services will be done via REST APIs, and data will be stored in separate databases to maintain loose coupling.

### 2. Core Microservices

#### 2.1. User Service
- **Responsibilities**: Manages user data (learners, trainers, and admins), authentication, and role management.
- **Tech Stack**: .NET Core Web API.
- **Database**: SQLLite.

#### 2.2. Course Service
- **Responsibilities**: Manages course creation, updates, deletion, and the storage of course content.
- **Tech Stack**: .NET Core Web API.
- **Database**: SQLLite.

#### 2.3. Enrollment Service
- **Responsibilities**: Handles learner enrollments, tracks progress, and manages enrollments.
- **Tech Stack**: .NET Core Web API.
- **Database**: SQLLite for tracking enrollments.

#### 2.4. Media Service
- **Responsibilities**: Handles video uploads, streaming, and storage of course materials.
- **Tech Stack**: .NET Core, integrates with a CDN (e.g., Azure Media Services or AWS S3).
- **Database**: Blob storage (Azure Blob).

#### 2.5. Assessment Service
- **Responsibilities**: Manages quizzes, tests, and grading for courses.
- **Tech Stack**: .NET Core Web API.
- **Database**: SQLLite.

### 3. Frontend Application
- **Tech Stack**: Angular
- **Responsibilities**:
  - Single-page application (SPA) to consume the backend APIs.
  - Display and manage the frontend views for learners, trainers, and admins.
  - Responsive UI, designed using a component-based architecture, and styled using Angular Material or Bootstrap.

### 4. API Gateway
- **Responsibilities**:
  - Acts as a single entry point for all the microservices.
  - Handles routing, authentication, and rate limiting.
  - Load balances requests to different services.

### 5. Service Communication
- **Type**: Primarily HTTP REST API communication.
- **Service Discovery**: Use Consul or Eureka for service discovery, allowing dynamic discovery of services across different environments.

### 6. Database Architecture
- **User Data**: SQL Server for structured data like user profiles, enrollments, and course tracking.
- **Course Content**: NoSQL database (e.g., MongoDB) for storing course metadata and related documents.
- **Media Storage**: Blob storage (Azure Blob or AWS S3) for video and large file storage.

### 7. Authentication & Authorization
- **Identity Server**: Centralized authentication using OAuth 2.0 or OpenID Connect.
- **Role-Based Access Control (RBAC)**: Implement role-based access at the API Gateway to restrict access based on user roles (admin, trainer, learner).

### 8. DevOps and CI/CD
- **Containerization**: Each microservice will be containerized using Docker.
- **Orchestration**: Use Kubernetes or Docker Swarm for managing containers.
- **CI/CD Pipeline**: Jenkins or Azure DevOps for automated build, testing, and deployment.

---

## Database Models
### User Model
This model handles both learners and trainers since they share common attributes but differ in roles.
```
public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }  // For storing hashed passwords
    public string Role { get; set; }  // Learner, Trainer, Admin
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
```
- **Role**: Can be `Learner`, `Trainer`, or `Admin`.
- **Email**: Unique constraint.

### Course Model
This will hold the course-related data created by trainers.
```
public class Course
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Guid TrainerId { get; set; }  // Foreign key to User (Trainer)
    public string Category { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<Module> Modules { get; set; }  // One-to-many relationship
}
```
- **TrainerId**: Foreign key referencing the User table (Trainer role).
- **Modules**: A course consists of multiple modules/lectures.

### Module Model
Each course will contain multiple modules or lectures.
```
public class Module
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string VideoUrl { get; set; }  // For storing the video link
    public string AdditionalResources { get; set; }  // Links to PDFs, other files
    public Guid CourseId { get; set; }  // Foreign key to Course
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
```
- **VideoUrl**: Could be a link to the video stored in a CDN (e.g., AWS S3, Azure Blob Storage).
- **AdditionalResources**: Optional material like PDFs, assignments.

### Enrollment Model
Tracks the courses that learners have enrolled in.
```
public class Enrollment
{
    public Guid Id { get; set; }
    public Guid LearnerId { get; set; }  // Foreign key to User (Learner role)
    public Guid CourseId { get; set; }  // Foreign key to Course
    public DateTime EnrollmentDate { get; set; }
    public decimal AmountPaid { get; set; }
    public bool IsCompleted { get; set; }
}
```
- **LearnerId**: Foreign key referencing the User table (Learner role).
- **IsCompleted**: Indicates whether the learner has completed the course.

  
### Progress Model
Tracks the progress of learners in a particular course.
```
public class Progress
{
    public Guid Id { get; set; }
    public Guid LearnerId { get; set; }  // Foreign key to User (Learner)
    public Guid CourseId { get; set; }  // Foreign key to Course
    public Guid ModuleId { get; set; }  // Foreign key to Module
    public bool IsCompleted { get; set; }
    public DateTime LastWatchedAt { get; set; }
}
```
- **ModuleId**: Tracks progress within individual modules.

---

## ER Diagram Outline

### User:
- One user can be a learner or trainer.
- A trainer can create many courses.
- A learner can enroll in many courses.

### Course:
- A course consists of many modules.
- A course can have many enrollments, reviews, and quizzes.

### Enrollment:
- Each enrollment links a learner to a course.
- Progress and completion are tracked for each enrollment.

### Module:
- Each course contains multiple modules.
- A learner’s progress through each module is tracked.

