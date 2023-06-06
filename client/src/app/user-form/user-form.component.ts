import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { User } from '../models/user.model';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
})
export class UserFormComponent {
  userName: string = "";

  constructor(private apiService: ApiService) {}

  onSubmit(): void {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    this.apiService.createUser(this.userName, httpOptions).subscribe(
      (response) => {
        console.log('User created:', response);
        // Reset the form
        this.userName = '';
      },
      (error) => {
        console.error('Error creating user:', error);
      }
    );
  }
}
