namespace MyIMDB.Web.ViewModels.SearchMovies
{
    using System.Collections.Generic;

    using MyIMDB.Web.ViewModels.Movies;

    public class ListViewModel
    {
        public IEnumerable<MovieInListViewModel> Movies { get; set; }
    }
}
