namespace MyIMDB.Web.ViewModels.Movies
{
    using AutoMapper;
    using MyIMDB.Data.Models;
    using MyIMDB.Services.Mapping;

    public class EditMovieInputModel : BaseMovieInputModel, IMapFrom<Movie>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, EditMovieInputModel>()
                .ForMember(x => x.Runtime, opt =>
                    opt.MapFrom(x => (int)x.Runtime.TotalMinutes));
        }

        // public string ImageUrl { get; set; }
    }
}
