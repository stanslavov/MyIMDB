namespace MyIMDB.Web.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using MyIMDB.Data.Models;
    using MyIMDB.Services.Mapping;

    public class MovieInfoViewModel : IMapFrom<Movie>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string GenreName { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UserUserName { get; set; }

        public string ImageUrl { get; set; }

        public string DirectorFullName { get; set; }

        public TimeSpan Runtime { get; set; }

        public string PgRatingName { get; set; }

        public int GenreMoviesCount { get; set; }

        public string Synopsis { get; set; }

        public double AverageVote { get; set; }

        public IEnumerable<MovieInfoActorViewModel> Cast { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Movie, MovieInfoViewModel>()
                .ForMember(x => x.AverageVote, opt =>
                opt.MapFrom(x => x.Votes.Count() == 0 ? 0 : x.Votes.Average(v => v.Value)))
                .ForMember(x => x.ImageUrl, opt =>
                opt.MapFrom(x =>
                    x.Images.FirstOrDefault().RemoteImageUrl != null ?
                    x.Images.FirstOrDefault().RemoteImageUrl :
                    "/images/movies/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
