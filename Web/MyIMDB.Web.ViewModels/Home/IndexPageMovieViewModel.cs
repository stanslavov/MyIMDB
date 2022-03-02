namespace MyIMDB.Web.ViewModels.Home
{
    using System.Linq;

    using AutoMapper;
    using MyIMDB.Data.Models;
    using MyIMDB.Services.Mapping;

    public class IndexPageMovieViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string GenreName { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, IndexPageMovieViewModel>()
                            .ForMember(x => x.ImageUrl, opt =>
                            opt.MapFrom(x =>
                                x.Images.FirstOrDefault().RemoteImageUrl != null ?
                                x.Images.FirstOrDefault().RemoteImageUrl :
                                "/images/movies/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
