namespace MyIMDB.Data.Models
{
    using System.Collections.Generic;

    using MyIMDB.Data.Common.Models;

    public class Genre : BaseDeletableModel<int>
    {
        public Genre()
        {
            this.Genres = new HashSet<MovieGenre>();
        }

        public string Name { get; set; }

        public virtual ICollection<MovieGenre> Genres { get; set; }
    }
}
