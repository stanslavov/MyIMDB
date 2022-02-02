namespace MyIMDB.Data.Models
{
    using System.Collections.Generic;

    using MyIMDB.Data.Common.Models;

    public class Director : BaseDeletableModel<int>
    {
        public Director()
        {
            this.Movies = new HashSet<Movie>();
        }

        public string FullName { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}
