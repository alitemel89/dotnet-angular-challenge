import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { User } from './models/user.model';
import { Post } from './models/post.model';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private apiUrl = 'http://localhost:5000/api';
  constructor(private http: HttpClient) {}

  getAllUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiUrl}/users`);
  }

  createUser(userName: string, httpOptions: any): Observable<User> {
    const body = { userName }; // Create an object with the user name

    return this.http.post<User>(`${this.apiUrl}/users`, body, httpOptions)
      .pipe(map((response: any) => response as User));
  }

  deleteUser(userId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/users/${userId}`);
  }

  getSingleUser(userId: string): Observable<User> {
    return this.http.get<User>(`${this.apiUrl}/users/${userId}`);
  }

  getAllPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(`${this.apiUrl}/posts`);
  }

  createPost(post: Partial<Post>): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/posts`, post);
  }
}
