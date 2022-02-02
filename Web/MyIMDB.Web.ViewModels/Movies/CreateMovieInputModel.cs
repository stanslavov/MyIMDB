namespace MyIMDB.Web.ViewModels.Movies
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CreateMovieInputModel
    {
        [Required]
        [MinLength(1)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        public string Synopsis { get; set; }

        public MovieDirectorInputModel Director { get; set; }

        [Range(15, 5 * 60)]
        [Display(Name = "Duration (in minutes)")]
        public int Duration { get; set; }

        public int PgRating { get; set; }

        public IEnumerable<KeyValuePair<string, string>> PgRatingsItems { get; set; }

        public int Genre { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GenreItems { get; set; }

        public IEnumerable<MovieActorInputModel> Cast { get; set; }

        // public IEnumerable<MovieReviewInputModel> Review { get; set; }

        // public IEnumerable<MovieImageInputModel> Images { get; set; }

        // public IEnumerable<MovieGenreInputModel> Genre { get; set; }
    }
}
