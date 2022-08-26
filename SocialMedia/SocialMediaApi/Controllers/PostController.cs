using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SocialMedia.Infrastructure.Repositories;
using SocialMedia_Core.DTOs;
using SocialMedia_Core.Entities;
using SocialMedia_Core.Interfaces;
using SocialMediaApi.Responses;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _maper;
        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _maper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetPost()
        {
            var posts = await _postRepository.GetPosts();
            var postsDto = _maper.Map <IEnumerable<PostDto>>(posts);
            var response = new ApiResponse<IEnumerable<PostDto>>(postsDto);
            return Ok(postsDto);        
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id);
            var postDto = _maper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post(PostDto  postDto)
        {
            var post = _maper.Map<Post>(postDto);
            await _postRepository.InsertPost(post);

            postDto = _maper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(post);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, PostDto postDto)
        {
            var post = _maper.Map<Post>(postDto);
            post.PostId = id;

            var result = await _postRepository.UpdatePost(post);
            var response = new ApiResponse<bool>(result);
            return Ok(response);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _postRepository.DeletePost(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);


        }

    }
}
