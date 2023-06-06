import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
})
export class UserDetailsComponent implements OnInit {
  userId: string = '';

  constructor(private route: ActivatedRoute, private apiService: ApiService) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.userId = params['userId'];
      this.apiService.getSingleUser(this.userId)
    });
  }
}
