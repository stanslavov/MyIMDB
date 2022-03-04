namespace MyIMDB.Web.ViewModels.SearchMovies
{
    using System.Collections.Generic;

    public class SearchIndexViewModel
    {
        public IEnumerable<ActorNameIdViewModel> Actors { get; set; }
    }
}
