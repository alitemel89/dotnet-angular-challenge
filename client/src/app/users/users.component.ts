import { Component } from '@angular/core';
import { User } from '../models/user.model';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
})
export class UsersComponent {
  users: User[] | undefined;
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
}
