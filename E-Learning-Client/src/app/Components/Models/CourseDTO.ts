import { ModuleDTO } from './ModuleDTO';

export interface CourseDTO {
  id: string; // UUID format
  title: string; // Title of the course
  description: string; // Detailed description of the course
  thumbnail: string; // URL or base64-encoded thumbnail image
  trainerId: string; // UUID format for the trainer
  category: string; // Course category
  price: number; // Price of the course
  createdAt: Date;
  updatedAt: Date;
  modules: ModuleDTO[];
}
