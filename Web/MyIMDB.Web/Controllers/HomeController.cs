namespace MyIMDB.Web.Controllers
{
    using System.Diagnostics;

    using Microsoft.AspNetCore.Mvc;
    using MyIMDB.Services.Data;
    using MyIMDB.Web.ViewModels;
    using MyIMDB.Web.ViewModels.Home;

    // 1. Using ApplicationDbContext
    // 2. Using Repositories(the Repository pattern)
    // 3. Using Services
    public class HomeController : BaseController
    {
        private readonly IGetCountsService countsService;
        private readonly IMoviesService moviesService;

        public HomeController(IGetCountsService countsService, IMoviesService moviesService)
        {
            this.countsService = countsService;
            this.moviesService = moviesService;
        }

        public IActionResult Index()
        {
            var countsDto = this.countsService.GetCounts();

            /* var viewModel = this.mapper.Map<IndexViewModel>(counts);
            OR */

            var viewModel = new IndexViewModel
            {
                MoviesCount = countsDto.MoviesCount,
                ActorsCount = countsDto.ActorsCount,
                GenresCount = countsDto.GenresCount,
                PgRatingsCount = countsDto.PgRatingsCount,
                RandomMovies = this.moviesService.GetRandom<IndexPageMovieViewModel>(2),
            };

            // var viewModel = this.countsService.GetCounts();
            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
