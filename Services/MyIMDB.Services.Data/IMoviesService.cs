namespace MyIMDB.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using MyIMDB.Web.ViewModels.Movies;

    public interface IMoviesService
    {
        Task CreateAsync(CreateMovieInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        int GetCount();

        T GetById<T>(int id);
    }
}
