namespace MyIMDB.Web.ViewModels.Movies
{
    using System.ComponentModel.DataAnnotations;

    public class MovieDirectorInputModel
    {
        [Required]
        [MinLength(5)]
        public string FullName { get; set; }
    }
}
