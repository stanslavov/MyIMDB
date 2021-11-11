namespace MyIMDB.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyIMDB.Services.Data;
    using MyIMDB.Web.ViewModels.Movies;
    using System.Threading.Tasks;

    public class MoviesController : Controller
    {
        private readonly IPgRatingsService pgratingsService;
        private readonly IMoviesService moviesService;

        public MoviesController(IPgRatingsService pgratingsService, IMoviesService moviesService)
        {
            this.pgratingsService = pgratingsService;
            this.moviesService = moviesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateMovieInputModel();
            viewModel.PgRatingsItems = this.pgratingsService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.PgRatingsItems = this.pgratingsService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            await this.moviesService.CreateAsync(input);

            // return this.Json(input);

            // Create movie using a service
            // TODO: Redirect to Movie created page
            return this.Redirect("/");
        }
    }
}
