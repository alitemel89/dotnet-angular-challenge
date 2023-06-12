import { Component, OnInit } from '@angular/core';
import { ApiService } from '../api.service';
import { Post } from '../models/post.model';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
})
export class FeedComponent implements OnInit {
  posts: Post[] = [];

  constructor(private apiService: ApiService) {}

  ngOnInit(): void {
    this.getPosts();
  }
  
  getPosts(): void {
    this.apiService.getAllPosts().subscribe((posts) => {
      this.posts = posts;
    });
  }
}
