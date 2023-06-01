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

                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();
            }

        }
    }
}