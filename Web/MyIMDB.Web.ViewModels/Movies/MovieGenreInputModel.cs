namespace MyIMDB.Web.ViewModels.Movies
{
    using System.ComponentModel.DataAnnotations;

    public class MovieGenreInputModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
    }
}
