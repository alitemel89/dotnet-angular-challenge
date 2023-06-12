import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
})
export class AddUserComponent {
  userName: string = '';
  userId: string = '';
  constructor(private apiService: ApiService) {}


  onSubmit(): void {
    if (!this.userName) {
      alert('Please provide a user name!');
      return;
    }
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
      }),
    };


    this.apiService.createUser(this.userName, httpOptions).subscribe({
      next: (response) => {
        console.log('User created:', response);
        // Reset the form
        this.userName = '';
        window.location.reload();
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
}
