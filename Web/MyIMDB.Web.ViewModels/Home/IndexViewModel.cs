namespace MyIMDB.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IndexPageMovieViewModel> RandomMovies { get; set; }

        public int MoviesCount { get; set; }

        public int ActorsCount { get; set; }

        public int GenresCount { get; set; }

        public int PgRatingsCount { get; set; }
    }
}
