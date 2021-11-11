namespace MyIMDB.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using MyIMDB.Data.Models;

    public class PgRatingsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.PgRatings.Any())
            {
                return;
            }

            await dbContext.PgRatings.AddAsync(new PgRating { Name = "G" });
            await dbContext.PgRatings.AddAsync(new PgRating { Name = "PG" });
            await dbContext.PgRatings.AddAsync(new PgRating { Name = "PG-13" });
            await dbContext.PgRatings.AddAsync(new PgRating { Name = "R" });
            await dbContext.PgRatings.AddAsync(new PgRating { Name = "NC-17" });

            await dbContext.SaveChangesAsync();
        }
    }
}
