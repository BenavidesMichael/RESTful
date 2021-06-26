using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RESTful.API.Responses;
using RESTful.Core.DTOs;
using RESTful.Core.Entities;
using RESTful.Core.Interfaces;
using RESTful.Core.QueryFilters;
using RESTful.Infrastructure.Interface;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RESTful.API.Controllers
{

    [Produces("application/json")] // Accept header que les json
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPostService _postService;
        private readonly IUrlService _urlService;

        public PostsController(IMapper mapper, IPostService postService, IUrlService urlService)
        {
            this._mapper = mapper;
            this._postService = postService;
            this._urlService = urlService;
        }


        /// <summary>
        /// Retrieve all posts
        /// </summary>
        /// <param name="model">filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetPosts))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<PostDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(ApiResponse<IEnumerable<PostDto>>))]
        public IActionResult GetPosts([FromQuery] PostFilter model)
        {
            var postsData = _postService.GetAllPosts(model);
            var postDto = _mapper.Map<IEnumerable<PostDto>>(postsData);

            var metadata = new MetadataDto
            {
                TotalItems = postsData.TotalItem,
                PageSize = postsData.PageSize,
                CurrentPage = postsData.CurrentPage,
                TotalPage = postsData.TotalPage,
                HasPreviousPage = postsData.HasPreviousPage,
                HasNextPage = postsData.HasNextPage,
                NextPageUrl = _urlService.GetPostPaginationUrl(model, Url.RouteUrl(nameof(GetPosts))).ToString(),
                PreviousPageUrl = _urlService.GetPostPaginationUrl(model, Url.RouteUrl(nameof(GetPosts))).ToString(),
            };

            var response = new ApiResponse<IEnumerable<PostDto>>(postDto)
            {
                Metadata = metadata,
            };

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

            model = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(model);

            return Ok(response);
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
