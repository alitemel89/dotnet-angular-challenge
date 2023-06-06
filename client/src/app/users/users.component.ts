import { Component, OnInit } from '@angular/core';
import { User } from '../models/user.model';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
})
export class UsersComponent implements OnInit {
  users: User[] = [];
  loading: boolean = false;

  constructor(private apiService: ApiService) {}

  ngOnInit() {
    this.fetchUsers();
  }

  fetchUsers() {
    this.loading = true;
    this.apiService.getAllUsers().subscribe((data: any[]) => {
      this.users = data;
      if (this.users.length > 0) this.loading = false;
    });
  }

  onDelete(userId: string): void {
    this.apiService.deleteUser(userId).subscribe(() => {
      this.fetchUsers(); // Fetch the updated list of users after deletion
    });
  }
}
