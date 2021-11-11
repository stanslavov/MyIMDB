namespace MyIMDB.Data.Models
{
    using System.Collections.Generic;

    using MyIMDB.Data.Common.Models;

    public class PgRating : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
