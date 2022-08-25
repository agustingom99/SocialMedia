using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SocialMedia_Core.DTOs;
using SocialMedia_Core.Entities;

namespace SocialMedia.Infrastructure.Mappings
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
        }
    }
}
