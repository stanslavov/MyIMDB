namespace MyIMDB.Web.ViewModels.SearchMovies
{
    using MyIMDB.Data.Models;
    using MyIMDB.Services.Mapping;

    public class ActorNameIdViewModel : IMapFrom<Actor>
    {
        public int Id { get; set; }

        public string FullName { get; set; }
    }
}
