namespace MyIMDB.Data.Models
{
    using System.Collections.Generic;

    using MyIMDB.Data.Common.Models;

    public class Actor : BaseDeletableModel<int>
    {
        public Actor()
        {
            this.Cast = new HashSet<MovieActor>();
        }

        public string FullName { get; set; }

        public int StarRating { get; set; }

        public virtual ICollection<MovieActor> Cast { get; set; }
    }
}
