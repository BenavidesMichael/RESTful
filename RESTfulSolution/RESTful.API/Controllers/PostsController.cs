using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(postDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var postDB = await _postRepository.GetById(id);
            var postDto = _mapper.Map<PostDto>(postDB);
            return Ok(postDto);
        }


        [HttpPost]
        public async Task<IActionResult> Post(PostDto model)
        {
            var result = _mapper.Map<Post>(model);
            await _postRepository.Create(result);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Put(int Id, PostDto model)
        {
            var result = _mapper.Map<Post>(model);
            result.Id = Id;
            return Ok(await _postRepository.Update(result));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            return Ok(await _postRepository.Delete(Id));
        }

    }
}
