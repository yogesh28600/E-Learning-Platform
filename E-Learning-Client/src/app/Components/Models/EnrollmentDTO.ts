export interface EnrollmentDTO {
  id: string | null; // UUID format
  learnerId: string; // UUID format for the trainer
  courseId: string;
  category: string; // Course category
  enrollmentDate: string;
  amountPaid: number;
  isCompleted: boolean;
}
