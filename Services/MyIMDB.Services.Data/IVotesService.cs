namespace MyIMDB.Services.Data
{
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task SetVoteAsync (int movieId, string userId, byte value);

        double GetAverageVote(int movieId);
    }
}
