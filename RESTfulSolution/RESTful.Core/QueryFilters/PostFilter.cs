using System;

namespace RESTful.Core.QueryFilters
{
    public class PostFilter
    {
        public int? UserId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
    }
}
