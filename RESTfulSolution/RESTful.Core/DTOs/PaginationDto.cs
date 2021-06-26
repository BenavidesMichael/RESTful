namespace RESTful.Core.DTOs
{
    public abstract class PaginationDto
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
