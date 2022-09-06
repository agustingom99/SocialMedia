using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using SocialMedia.Infrastructure.Repositories;
using SocialMedia_Core.DTOs;
using SocialMedia_Core.Entities;
using SocialMedia_Core.Interfaces;
using SocialMedia_Core.QueryFilters.cs;
using SocialMediaApi.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PostController : ControllerBase
    {
        private readonly IPostServices _postService;
        private readonly IMapper _maper;
        public PostController(IPostServices postServices, IMapper mapper)
        {
            _postService = postServices;
            _maper = mapper;
        }
        [HttpGet]
        public IActionResult GetPost([FromQuery] PostQueryFilter filters)
        {
            var posts =  _postService.GetPosts(filters);
            var postsDto = _maper.Map <IEnumerable<PostDto>>(posts);
            var response = new ApiResponse<IEnumerable<PostDto>>(postsDto);

            var metadata = new
            {
                posts.TotalCount,
                posts.PageSize,
                posts.CurrentPage,
                posts.TotalPages,
                posts.HasNextPage,
                posts.HasPreviousPage
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
