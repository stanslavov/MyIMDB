namespace MyIMDB.Web.ViewModels.Movies
{
    using MyIMDB.Data.Models;
    using MyIMDB.Services.Mapping;

    public class MovieInfoActorViewModel : IMapFrom<MovieActor>
    {
        public string ActorFullName { get; set; }

        public int ActorStarRating { get; set; }
    }
}
