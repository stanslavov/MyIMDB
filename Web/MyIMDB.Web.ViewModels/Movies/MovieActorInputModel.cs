namespace MyIMDB.Web.ViewModels.Movies
{
    using System.ComponentModel.DataAnnotations;

    public class MovieActorInputModel
    {
        [Required]
        [MinLength(5)]
        public string FullName { get; set; }

        [Required]
        [Range(1, 5)]
        public int StarRating { get; set; }
    }
}
