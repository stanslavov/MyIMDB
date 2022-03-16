namespace MyIMDB.Web.ViewModels.Chats
{
    using MyIMDB.Data.Models;
    using MyIMDB.Services.Mapping;

    public class ChatViewModel : IMapFrom<Movie>
    {
        public string Title { get; set; }
    }
}
