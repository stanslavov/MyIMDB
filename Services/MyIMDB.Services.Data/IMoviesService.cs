namespace MyIMDB.Services.Data
{
    using System.Threading.Tasks;

    using MyIMDB.Web.ViewModels.Movies;

    public interface IMoviesService
    {
        Task CreateAsync(CreateMovieInputModel input);
    }
}
