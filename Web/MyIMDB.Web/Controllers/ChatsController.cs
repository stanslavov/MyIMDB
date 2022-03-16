namespace MyIMDB.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyIMDB.Services.Data;
    using MyIMDB.Web.ViewModels.Chats;
    using MyIMDB.Web.ViewModels.Movies;

    public class ChatsController : Controller
    {
        private readonly IMoviesService moviesService;

        public ChatsController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        [Authorize]
        public IActionResult Chat(int id)
        {
            var viewModel = new ChatViewModel();
            var movie = this.moviesService.GetById<MovieInfoViewModel>(id);
            viewModel.Title = movie.Title;
            return this.View(viewModel);
        }
    }
}
