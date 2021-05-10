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
        public async Task<IActionResult> Get()
        {
            var postsDB = await _postService.GetAllPosts();
            var postDto = _mapper.Map<IEnumerable<PostDto>>(postsDB);
            var response = new ApiResponse<IEnumerable<PostDto>>(postDto);
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var postDB = await _postService.GetById(id);
            var postDto = _mapper.Map<PostDto>(postDB);

            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post(PostDto model)
        {
            var post = _mapper.Map<Post>(model);
            await _postService.Create(post);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Put(int Id, PostDto model)
        {
            var post = _mapper.Map<Post>(model);
            post.Id = Id;

            var result = await _postService.Update(post);
            var response = new ApiResponse<bool>(result);
            
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _postService.Delete(Id);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

    }
}
