namespace MyIMDB.Web.ViewModels.Movies
{
    using System.ComponentModel.DataAnnotations;

    public class MovieReviewInputModel
    {
        [Required]
        [MinLength(100)]
        public string ReviewContent { get; set; }
    }
}
