export interface UserDTO {
  id: string; // UUID format for user ID
  firstName: string; // User's first name
  lastName: string; // User's last name
  email: string; // User's email address
  passwordHash: string; // Hashed password (not typically exposed in responses)
  role: string; // User role (e.g., Learner, Trainer, Admin)
}
