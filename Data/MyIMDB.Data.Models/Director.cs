namespace MyIMDB.Data.Models
{
    using System.Collections.Generic;

    using MyIMDB.Data.Common.Models;

    public class Director : BaseDeletableModel<int>
    {
        public string FullName { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}
