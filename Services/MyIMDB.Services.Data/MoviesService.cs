namespace MyIMDB.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using MyIMDB.Data.Common.Repositories;
    using MyIMDB.Data.Models;
    using MyIMDB.Services.Mapping;
    using MyIMDB.Web.ViewModels.Movies;

    public class MoviesService : IMoviesService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Movie> moviesRepository;
        private readonly IDeletableEntityRepository<Actor> actorsRepository;
        private readonly IDeletableEntityRepository<Director> directorsRepository;

        public MoviesService(
            IDeletableEntityRepository<Movie> moviesRepository,
            IDeletableEntityRepository<Actor> actorsRepository,
            IDeletableEntityRepository<Director> directorsRepository)
        {
            this.moviesRepository = moviesRepository;
            this.actorsRepository = actorsRepository;
            this.directorsRepository = directorsRepository;
        }

        public async Task CreateAsync(CreateMovieInputModel input, string userId, string imagePath)
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
                GenreId = input.GenreId,
                Runtime = TimeSpan.FromMinutes(input.Runtime),
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

            // /wwwroot/images/movies/sdadas-213sdasda22-g232.jpg
            // /wwwroot/images/movies/{id}.{ext}
            Directory.CreateDirectory($"{imagePath}/movies/");

            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    UserId = userId,
                    Movie = movie,
                    Extension = extension,
                };
                movie.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/movies/{dbImage.Id}.{extension}";
                using (Stream fileStream = new FileStream(physicalPath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }

            await this.moviesRepository.AddAsync(movie);
            await this.moviesRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movie = this.moviesRepository.All().FirstOrDefault(x => x.Id == id);
            this.moviesRepository.Delete(movie);
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

        public IEnumerable<T> GetByCast<T>(IEnumerable<int> actorIds)
        {
            var query = this.moviesRepository.All().AsQueryable();

            foreach (var actorId in actorIds)
            {
                query = query.Where(x => x.Cast.Any(i => i.ActorId == actorId));
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var movie = this.moviesRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return movie;
        }

        public int GetCount()
        {
            return this.moviesRepository.All().Count();
        }

        public IEnumerable<T> GetRandom<T>(int count)
        {
            return this.moviesRepository.All()
                .OrderBy(x => Guid.NewGuid()).To<T>()
                .Take(count)
                .ToList();
        }

        public async Task UpdateAsync(int id, EditMovieInputModel input)
        {
            var movie = this.moviesRepository.All().FirstOrDefault(x => x.Id == id);
            movie.Title = input.Title;
            movie.Synopsis = input.Synopsis;
            movie.Runtime = TimeSpan.FromMinutes(input.Runtime);
            movie.GenreId = input.GenreId;

            await this.moviesRepository.SaveChangesAsync();
        }
    }
}
