namespace MyIMDB.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using MyIMDB.Data.Common.Repositories;
    using MyIMDB.Data.Models;
    using MyIMDB.Services.Mapping;

    public class ActorsService : IActorsService
    {
        private readonly IDeletableEntityRepository<Actor> actorsRepository;

        public ActorsService(IDeletableEntityRepository<Actor> actorsRepository)
        {
            this.actorsRepository = actorsRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.actorsRepository.All().To<T>().ToList();
        }
    }
}
