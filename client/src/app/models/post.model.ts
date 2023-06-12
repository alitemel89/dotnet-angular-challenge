export interface Post {
  postId: string;
  caption: string;
  user: {
    userId: string;
    userName: string;
  };
}
