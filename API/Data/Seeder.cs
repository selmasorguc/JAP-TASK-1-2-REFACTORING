namespace API.Data
{
    using API.Entity;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class Seeder
    {
        public static async Task SeedData(DataContext context)
        {
            if (await context.Media.AnyAsync()) return;

            var mediaData = await System.IO.File.ReadAllTextAsync("Data/MovieSeedData.json");
            var media = JsonSerializer.Deserialize<List<Media>>(mediaData);

            foreach (var item in media)
            {
                context.Add(item);
            }

            using var hmac = new HMACSHA512();
            var user = new User
            {
                Username = "selma",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("selma1")),
                PasswordSalt = hmac.Key
            };

            context.Users.Add(user);

            context.Tickets.Add(new Ticket
            {
                Price = 10.00,
                MediaId = 32,
                UserId = user.Id,
                User = user,
                ScreeningId = 3
            });

            context.Tickets.Add(new Ticket
            {
                Price = 10.00,
                MediaId = 32,
                UserId = user.Id,
                User = user,
                ScreeningId = 3
            });

            context.Tickets.Add(new Ticket
            {
                Price = 70.00,
                MediaId = 25,
                UserId = user.Id,
                User = user,
                ScreeningId = 59
            });

            context.Tickets.Add(new Ticket
            {
                Price = 13.00,
                MediaId = 100,
                UserId = user.Id,
                User = user,
                ScreeningId = 36
            });

            context.Tickets.Add(new Ticket
            {
                Price = 13.00,
                MediaId = 99,
                UserId = user.Id,
                User = user,
                ScreeningId = 42
            });

            context.Tickets.Add(new Ticket
            {
                Price = 13.00,
                MediaId = 107,
                UserId = user.Id,
                User = user,
                ScreeningId = 49
            });

            await context.SaveChangesAsync();
        }
    }
}
