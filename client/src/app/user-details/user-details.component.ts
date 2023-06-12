import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../api.service';
import { User } from '../models/user.model';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
})
export class UserDetailsComponent implements OnInit {
  userId: string = '';
  user: User | undefined;

  constructor(private route: ActivatedRoute, private apiService: ApiService) {}

  ngOnInit(): void {
    this.getUserDetails();
  }

  getUserDetails(): void {
    const userId = this.route.snapshot.paramMap.get('userId');
    if (userId) {
      this.apiService.getSingleUser(userId).subscribe((user) => {
        this.user = user;
      });
    }
  }


}
