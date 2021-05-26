using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RESTful.API.Responses;
using RESTful.Core.DTOs;
using RESTful.Core.Entities;
using RESTful.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTful.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPostService _postService;

        public PostsController(IMapper mapper, IPostService postService)
        {
            this._mapper = mapper;
            this._postService = postService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var postsDB = _postService.GetAllPosts();
            var postDto = _mapper.Map<IEnumerable<PostDto>>(postsDB);
            var response = new ApiResponse<IEnumerable<PostDto>>(postDto);
            return Ok(response);
        }


        /// <summary>
        /// get post By Id 
        /// </summary>
        /// <param name="id"> post Id</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(GetPost))]
        public async Task<IActionResult> GetPost(int id)
        {
            var postDB = await _postService.GetByIdAsync(id);
            var postDto = _mapper.Map<PostDto>(postDB);

            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post(PostDto model)
        {
            var post = _mapper.Map<Post>(model);
            await _postService.CreateAsync(post);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Put(int Id, PostDto model)
        {
            var post = _mapper.Map<Post>(model);
            post.Id = Id;

            await _postService.UpdateAsync(post);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            await _postService.DeleteAsync(Id);
            var response = new ApiResponse<bool>(true);

            return Ok(response);
        }

    }
}
