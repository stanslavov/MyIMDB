namespace MyIMDB.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyIMDB.Services.Data;
    using MyIMDB.Web.ViewModels.Movies;
    using MyIMDB.Web.ViewModels.SearchMovies;

    public class SearchMoviesController : BaseController
    {
        private readonly IMoviesService moviesService;
        private readonly IActorsService actorsService;

        public SearchMoviesController(
            IMoviesService moviesService, 
            IActorsService actorsService)
        {
            this.moviesService = moviesService;
            this.actorsService = actorsService;
        }

        public IActionResult Index()
        {
            var viewModel = new SearchIndexViewModel
            {
                Actors = this.actorsService.GetAll<ActorNameIdViewModel>(),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult List(SearchListInputModel input)
        {
            var viewModel = new ListViewModel
            {
                Movies = this.moviesService.GetByCast<MovieInListViewModel>(input.Actors),
            };

            return this.View(viewModel);
        }
    }
}
