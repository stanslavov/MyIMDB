namespace MyIMDB.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using MyIMDB.Data.Common.Repositories;
    using MyIMDB.Data.Models;

    public class VotesService : IVotesService
    {
        private readonly IRepository<Vote> votesRepository;

        public VotesService(IRepository<Vote> votesRepository)
        {
            this.votesRepository = votesRepository;
        }

        public double GetAverageVote(int movieId)
        {
            return this.votesRepository.All().Where(x => x.MovieId == movieId).Average(x => x.Value);
        }

        public async Task SetVoteAsync(int movieId, string userId, byte value)
        {
            var vote = this.votesRepository.All().FirstOrDefault(x => x.MovieId == movieId && x.UserId == userId);

            if (vote == null)
            {
                vote = new Vote
                {
                    MovieId = movieId,
                    UserId = userId,
                };

                await this.votesRepository.AddAsync(vote);
            }

            vote.Value = value;
            await this.votesRepository.SaveChangesAsync();
        }
    }
}
