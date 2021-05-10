using System;
using System.Collections.Generic;

namespace RESTful.Core.Entities
{
    public class Post : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
