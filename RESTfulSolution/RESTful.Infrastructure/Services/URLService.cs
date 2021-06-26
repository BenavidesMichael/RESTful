using RESTful.Core.QueryFilters;
using RESTful.Infrastructure.Interface;
using System;

namespace RESTful.Infrastructure.Services
{
    public class URLService : IUrlService
    {
        private readonly string _baseUrl;
        public URLService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }


        public Uri GetPostPaginationUrl(PostFilter filter, string actionUrl)
        {
            string baseUrl = $"{this._baseUrl}{actionUrl}";
            return new Uri(baseUrl);
        }


    }
}
