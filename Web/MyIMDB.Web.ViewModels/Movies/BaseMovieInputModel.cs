namespace MyIMDB.Web.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseMovieInputModel
    {
        [Required]
        [MinLength(1)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        public string Synopsis { get; set; }

        [Range(15, 5 * 60)]
        [Display(Name = "Runtime (in minutes)")]
        public int Runtime { get; set; }

        public int GenreId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> GenreItems { get; set; }
    }
}
