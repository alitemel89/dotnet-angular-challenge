import { Component, EventEmitter, Output } from '@angular/core';
import { ApiService } from '../api.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-post-create',
  templateUrl: './post-create.component.html',
})
export class PostCreateComponent {
  @Output() postCreated: EventEmitter<void> = new EventEmitter<void>();
  caption: string = '';
  userId: string = '';

  constructor(private apiService: ApiService, private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.userId = params['userId'];
    });
  }

  onCreatePost(): void {
    if (!this.caption) {
      alert('Please provide a caption for the post!');
      return;
    }

    const post = {
      caption: this.caption,
      userId: this.userId
    };

    this.apiService.createPost(post).subscribe(() => {
      this.postCreated.emit();
      // Reset the form
      this.caption = '';
      this.router.navigate(['/feed']);
    });
  }
}
