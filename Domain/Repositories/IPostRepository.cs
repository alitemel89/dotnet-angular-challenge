using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IPostRepository
    {
        Post GetPostById(Guid id);
        List<Post> GetPostsByUserId(Guid userId);
        List<Post> GetAllPosts();
        void AddPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Guid id);
    }
}