using System;

namespace RESTful.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
