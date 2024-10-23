import { Component } from '@angular/core';
import { User } from '../../Types/User';
import { UserStorageService } from '../../Services/user-storage.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrl: './header.component.css',
})
export class HeaderComponent {
  user: User | null = null;

  constructor(private userStorageService: UserStorageService) {}

  ngOnInit() {
    // Subscribe to user changes
    this.userStorageService.getUser().subscribe((user) => {
      this.user = user; // Update user when it changes
    });
  }

  logout() {
    // Call the clearUser method from the service
    this.userStorageService.clearUser().subscribe(() => {
      // Optionally perform any other actions after user is cleared
    });
  }
}
