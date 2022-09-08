using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using SocialMedia.Infrastructure.Interfaces;
using SocialMedia.Infrastructure.Repositories;
using SocialMedia_Core.CustomEntities;
using SocialMedia_Core.DTOs;
using SocialMedia_Core.Entities;
using SocialMedia_Core.Interfaces;
using SocialMedia_Core.QueryFilters.cs;
using SocialMediaApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SocialMediaApi.Controllers
{
    [Authorize]
    [Produces("application/json")]  
    [Route("api/[controller]")]
    [ApiController]
    
    public class PostController : ControllerBase
    {
        private readonly IPostServices _postService;
        private readonly IMapper _maper;
        private readonly IUriService _uriService;
        public PostController(IPostServices postServices, IMapper mapper, IUriService uriService)
        {
            _postService = postServices;
            _maper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retorna todo los post del sistema
        /// </summary>
        /// <param name="filters">Filtros para la aplicación </param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetPost))]
        [ProducesResponseType((int)HttpStatusCode.OK,Type = typeof(ApiResponse<IEnumerable<PostDto>>))]
        public IActionResult GetPost([FromQuery] PostQueryFilter filters)
        {
            var posts =  _postService.GetPosts(filters);
            var postsDto = _maper.Map <IEnumerable<PostDto>>(posts);

            var metadata = new Metadata
            {
                TotalCount = posts.TotalCount,
                PageSize = posts.PageSize,
                CurrentPage = posts.CurrentPage,
                TotalPage = posts.TotalPages,
                HasNextPage = posts.HasNextPage,
                HasPreviousPage = posts.HasPreviousPage,
                NextPageUrl = _uriService.GetPostPaginationUri(filters, Url.RouteUrl(nameof(GetPost))).ToString(),
                PreviousPageUrl = _uriService.GetPostPaginationUri(filters, Url.RouteUrl(nameof(GetPost))).ToString()
            };

            var response = new ApiResponse<IEnumerable<PostDto>>(postsDto)
            {
                Meta = metadata
            };
            Response.Headers.Add("x-pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);        
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetPost(id);
            var postDto = _maper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post(PostDto  postDto)
        {
            var post = _maper.Map<Post>(postDto);
            await _postService.InsertPost(post);

            postDto = _maper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(post);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, PostDto postDto)
        {
            var post = _maper.Map<Post>(postDto);
            post.Id = id;

            var result = await _postService.UpdatePost(post);
            var response = new ApiResponse<bool>(result);
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postService.DeletePost(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);


        }

    }
}
