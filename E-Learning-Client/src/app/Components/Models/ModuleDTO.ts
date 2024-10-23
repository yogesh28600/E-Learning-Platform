export interface ModuleDTO {
  id: string; // UUID format
  title: string; // Title of the module
  videoUrl: string; // URL to the video resource
  additionalResources: string; // Additional resources related to the module
  courseId: string; // UUID of the associated course
}
