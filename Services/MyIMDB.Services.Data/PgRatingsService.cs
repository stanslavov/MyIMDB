namespace MyIMDB.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using MyIMDB.Data.Common.Repositories;
    using MyIMDB.Data.Models;

    public class PgRatingsService : IPgRatingsService
    {
        private readonly IDeletableEntityRepository<PgRating> pgratingsRepository;

        public PgRatingsService(IDeletableEntityRepository<PgRating> pgratingsRepository)
        {
            this.pgratingsRepository = pgratingsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.pgratingsRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Name,
                    x.Id,
                }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
