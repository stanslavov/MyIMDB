namespace MyIMDB.Data.Models
{
    using System;
    using System.Collections.Generic;

    using MyIMDB.Data.Common.Models;

    public class Movie : BaseDeletableModel<int>
    {
        public Movie()
        {
            this.Genres = new HashSet<MovieGenre>();
            this.Cast = new HashSet<MovieActor>();
            this.Reviews = new HashSet<Review>();
            this.Images = new HashSet<Image>();
        }

        public string Title { get; set; }

        public string Synopsis { get; set; }

        public TimeSpan Duration { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int DirectorId { get; set; }

        public virtual Director Director { get; set; }

        public int PgRatingId { get; set; }

        public virtual PgRating PgRating { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<MovieGenre> Genres { get; set; }

        public virtual ICollection<MovieActor> Cast { get; set; }
    }
}
