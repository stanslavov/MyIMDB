namespace MyIMDB.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using MyIMDB.Data.Common.Repositories;
    using MyIMDB.Data.Models;

    public class GenreService : IGenreService
    {
        private readonly IDeletableEntityRepository<Genre> genresRepository;

        public GenreService(IDeletableEntityRepository<Genre> genresRepository)
        {
            this.genresRepository = genresRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.genresRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Name,
                    x.Id,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
