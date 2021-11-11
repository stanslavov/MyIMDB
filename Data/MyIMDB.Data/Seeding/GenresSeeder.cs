namespace MyIMDB.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MyIMDB.Data.Models;

    public class GenresSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Genres.Any())
            {
                return;
            }

            await dbContext.Genres.AddAsync(new Genre { Name = "Thriller" });
            await dbContext.Genres.AddAsync(new Genre { Name = "Horror" });
            await dbContext.Genres.AddAsync(new Genre { Name = "Drama" });
            await dbContext.Genres.AddAsync(new Genre { Name = "Action" });
            await dbContext.Genres.AddAsync(new Genre { Name = "Comedy" });
            await dbContext.Genres.AddAsync(new Genre { Name = "Western" });
            await dbContext.Genres.AddAsync(new Genre { Name = "Fantasy" });
            await dbContext.Genres.AddAsync(new Genre { Name = "Sci-Fi" });
            await dbContext.Genres.AddAsync(new Genre { Name = "Romance" });
            await dbContext.Genres.AddAsync(new Genre { Name = "Mystery" });

            await dbContext.SaveChangesAsync();
        }
    }
}
