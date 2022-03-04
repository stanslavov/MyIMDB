namespace MyIMDB.Web.Controllers
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyIMDB.Common;
    using MyIMDB.Data.Models;
    using MyIMDB.Services.Data;
    using MyIMDB.Web.ViewModels.Movies;

    public class MoviesController : Controller
    {
        private readonly IPgRatingsService pgratingsService;
        private readonly IMoviesService moviesService;
        private readonly IGenreService genreService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment environment;

        public MoviesController(
            IPgRatingsService pgratingsService,
            IMoviesService moviesService,
            IGenreService genreService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            this.pgratingsService = pgratingsService;
            this.moviesService = moviesService;
            this.genreService = genreService;
            this.userManager = userManager;
            this.environment = environment;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var input = this.moviesService.GetById<EditMovieInputModel>(id);
            input.GenreItems = this.genreService.GetAllAsKeyValuePairs();
            return this.View(input);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(int id, EditMovieInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.GenreItems = this.genreService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            await this.moviesService.UpdateAsync(id, input);

            return this.RedirectToAction(nameof(this.ById), new { id });
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new CreateMovieInputModel();
            viewModel.PgRatingsItems = this.pgratingsService.GetAllAsKeyValuePairs();
            viewModel.GenreItems = this.genreService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateMovieInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.PgRatingsItems = this.pgratingsService.GetAllAsKeyValuePairs();
                input.GenreItems = this.genreService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await this.userManager.GetUserAsync(this.User);

            try
            {
                await this.moviesService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.PgRatingsItems = this.pgratingsService.GetAllAsKeyValuePairs();
                input.GenreItems = this.genreService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            // return this.Json(input);

            // Create movie using a service
            // TODO: Redirect to Movie created page
            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 12;

            var viewModel = new MoviesListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                MoviesCount = this.moviesService.GetCount(),
                Movies = this.moviesService.GetAll<MovieInListViewModel>(id, ItemsPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            var movie = this.moviesService.GetById<MovieInfoViewModel>(id);
            return this.View(movie);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.moviesService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.All));
        }
    }
}
