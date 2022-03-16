namespace MyIMDB.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using MyIMDB.Services.Data;
    using MyIMDB.Web.ViewModels.Chats;

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
            var viewModel = this.moviesService.GetById<ChatViewModel>(id);
            return this.View(viewModel);
        }
    }
}