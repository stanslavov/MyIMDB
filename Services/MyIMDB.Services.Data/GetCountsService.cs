namespace MyIMDB.Services.Data
{
    using System.Linq;

    using MyIMDB.Data.Common.Repositories;
    using MyIMDB.Data.Models;
    using MyIMDB.Services.Data.Models;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Movie> moviesRepository;
        private readonly IRepository<Actor> actorsRepository;
        private readonly IDeletableEntityRepository<Genre> genresRepository;
        private readonly IDeletableEntityRepository<PgRating> pgratingsRepository;

        public GetCountsService(IDeletableEntityRepository<Movie> moviesRepository, IRepository<Actor> actorsRepository, IDeletableEntityRepository<Genre> genresRepository, IDeletableEntityRepository<PgRating> pgratingsRepository)
        {
            this.moviesRepository = moviesRepository;
            this.actorsRepository = actorsRepository;
            this.genresRepository = genresRepository;
            this.pgratingsRepository = pgratingsRepository;
        }

        public CountsDto GetCounts()
        {
            var data = new CountsDto
            {
                MoviesCount = this.moviesRepository.All().Count(),
                ActorsCount = this.actorsRepository.All().Count(),
                GenresCount = this.genresRepository.All().Count(),
                PgRatingsCount = this.pgratingsRepository.All().Count(),
            };

            return data;
        }
    }
}
