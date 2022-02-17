namespace MyIMDB.Data.Models
{
    using MyIMDB.Data.Common.Models;

    public class Review : BaseDeletableModel<int>
    {
        public string Content { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public int ReviewRating { get; set; }
    }
}
