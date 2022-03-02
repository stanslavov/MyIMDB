namespace MyIMDB.Web.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    public class CreateMovieInputModel : BaseMovieInputModel
    {
        public MovieDirectorInputModel Director { get; set; }

        public int PgRating { get; set; }

        public IEnumerable<KeyValuePair<string, string>> PgRatingsItems { get; set; }

        public IEnumerable<MovieActorInputModel> Cast { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }

        // [Required]
        // [MinLength(1)]
        // public string Title { get; set; }

        // [Required]
        // [MinLength(20)]
        // public string Synopsis { get; set; }

        // [Range(15, 5 * 60)]
        // [Display(Name = "Runtime (in minutes)")]
        // public int Runtime { get; set; }

        // public int Genre { get; set; }

        // public IEnumerable<KeyValuePair<string, string>> GenreItems { get; set; }

        // public IEnumerable<MovieReviewInputModel> Review { get; set; }

        // public IEnumerable<MovieImageInputModel> Images { get; set; }

        // public IEnumerable<MovieGenreInputModel> Genre { get; set; }
    }
}
