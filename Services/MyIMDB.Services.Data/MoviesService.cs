namespace MyIMDB.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MyIMDB.Data.Common.Repositories;
    using MyIMDB.Data.Models;
    using MyIMDB.Services.Mapping;
    using MyIMDB.Web.ViewModels.Movies;

    public class MoviesService : IMoviesService
    {
        private readonly IDeletableEntityRepository<Movie> moviesRepository;
        private readonly IDeletableEntityRepository<Actor> actorsRepository;
        private readonly IDeletableEntityRepository<Director> directorsRepository;

        public MoviesService(IDeletableEntityRepository<Movie> moviesRepository, IDeletableEntityRepository<Actor> actorsRepository, IDeletableEntityRepository<Director> directorsRepository)
        {
            this.moviesRepository = moviesRepository;
            this.actorsRepository = actorsRepository;
            this.directorsRepository = directorsRepository;
        }

        public async Task CreateAsync(CreateMovieInputModel input, string userId)
        {
            var director = this.directorsRepository.All().FirstOrDefault(x => x.FullName == input.Director.FullName);

            if (director == null)
            {
                director = new Director
                {
                    FullName = input.Director.FullName,
                };
            }

            var movie = new Movie
            {
                Title = input.Title,
                Synopsis = input.Synopsis,
                Director = director,
                PgRatingId = input.PgRating,
                GenreId = input.Genre,
                Duration = TimeSpan.FromMinutes(input.Duration),
                UserId = userId,
            };

            foreach (var inputActor in input.Cast)
            {
                var actor = this.actorsRepository.All().FirstOrDefault(x => x.FullName == inputActor.FullName);

                if (actor == null)
                {
                    actor = new Actor
                    {
                        FullName = inputActor.FullName,
                        StarRating = inputActor.StarRating,
                    };
                }

                movie.Cast.Add(new MovieActor
                {
                    Actor = actor,
                });
            }

            await this.moviesRepository.AddAsync(movie);
            await this.moviesRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var movies = this.moviesRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>().ToList();

            return movies;
        }

        public int GetCount()
        {
            return this.moviesRepository.All().Count();
        }
    }
}
