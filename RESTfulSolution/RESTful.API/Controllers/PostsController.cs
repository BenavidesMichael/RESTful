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
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostsController(IPostRepository postRepository, IMapper mapper)
        {
            this._postRepository = postRepository;
            this._mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var postsDB = await _postRepository.GetAllPosts();
            var postDto = _mapper.Map<IEnumerable<PostDto>>(postsDB);
            var response = new ApiResponse<IEnumerable<PostDto>>(postDto);
            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var postDB = await _postRepository.GetById(id);
            var postDto = _mapper.Map<PostDto>(postDB);

            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post(PostDto model)
        {
            var post = _mapper.Map<Post>(model);
            await _postRepository.Create(post);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Put(int Id, PostDto model)
        {
            var post = _mapper.Map<Post>(model);
            post.Id = Id;

            var result = await _postRepository.Update(post);
            var response = new ApiResponse<bool>(result);
            
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _postRepository.Delete(Id);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

    }
}
