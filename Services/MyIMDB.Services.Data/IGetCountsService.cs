namespace MyIMDB.Services.Data
{
    using MyIMDB.Services.Data.Models;

    // 1. Using the view models
    // 2. Using DTOs => view models
    // 3. Tuples(,,,)
    public interface IGetCountsService
    {
        // IndexViewModel GetCounts();
        CountsDto GetCounts();

        // (int MoviesCount, int ActorsCount, int GenresCount, int PgRatingsCount) GetCounts();
    }
}
