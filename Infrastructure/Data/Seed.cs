using Domain.Models;

namespace Infrastructure.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Users.Any())
            {
                var users = new List<User>
                {
                    new User
                    {
                        UserName = "Bob",
                    },
                    new User
                    {
                        UserName = "Jane",
                    },
                    new User
                    {
                        UserName = "Tom",
                    },
                };
            }


            if (!context.Posts.Any())
            {
                var users = context.Users.ToList();
                var posts = new List<Post>
                {
                   new Post { PostId = Guid.NewGuid(), Caption = "Hello this is a post from Jane", User = users[0] },
                };

                await context.Posts.AddRangeAsync(posts);
                await context.SaveChangesAsync();
            }
        }
    }
}