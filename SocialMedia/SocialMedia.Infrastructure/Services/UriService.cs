using SocialMedia.Infrastructure.Interfaces;
using SocialMedia_Core.QueryFilters.cs;
using System;

namespace SocialMedia.Infrastructure.Services
{
    //Este servicio se encarga de crear uri
    public class UriService: IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPostPaginationUri(PostQueryFilter filter, string actionUri)
        {
            string baseUri = $"{_baseUri}{actionUri}";
            return new Uri(baseUri);
        }
    }
}

