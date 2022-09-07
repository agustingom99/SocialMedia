using System;
using SocialMedia_Core.QueryFilters.cs;
using System.Collections.Generic;
using System.Text;

namespace SocialMedia.Infrastructure.Interfaces
{
    public interface IUriService
    {
        public Uri GetPostPaginationUri(PostQueryFilter filter, string actionUri);
    }
}
