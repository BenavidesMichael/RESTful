using RESTful.Core.QueryFilters;
using System;

namespace RESTful.Infrastructure.Interface
{
    public interface IUrlService
    {
        Uri GetPostPaginationUrl(PostFilter filter, string actionUrl);
    }
}
