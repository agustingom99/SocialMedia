using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Infrastructure.Repositories;
using SocialMedia_Core.Entities;
using SocialMedia_Core.Interfaces;
using System.Threading.Tasks;

namespace SocialMediaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetPost()
        {
            var posts = await _postRepository.GetPosts();
            return Ok(posts);        
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id);
            return Ok(post);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Post post)
        {

             await _postRepository.InsertPost(post);
            return Ok(post);
        }



    }
}
