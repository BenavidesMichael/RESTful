using Microsoft.Extensions.Options;
using RESTful.Core.DTOs;
using RESTful.Core.Entities;
using RESTful.Core.Execptions;
using RESTful.Core.Helper;
using RESTful.Core.Interfaces;
using RESTful.Core.QueryFilters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RESTful.Core.Services
{
    // externaliser dans une autre couche Application
    // Cqrs, services, etc...
    // ici y aurra Que 3 clsses donc pas trop besoin
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationSetting _paginationSetting;

        public PostService(IUnitOfWork unitOfWork, IOptions<PaginationSetting> paginationSetting)
        {
            this._unitOfWork = unitOfWork;
            _paginationSetting = paginationSetting.Value;
        }


        public PagedListHelper<Post> GetAllPosts(PostFilter model)
        {
            model.PageNumber = model.PageNumber == 0 ? _paginationSetting.DefaultPageNumber : model.PageNumber;
            model.PageSize = model.PageSize == 0 ? _paginationSetting.DefaultPageSize : model.PageSize;

            var postList = _unitOfWork.PostRepository.GetAll();

            if (model.UserId != null)
            {
                postList = postList.Where(x => x.UserId == model.UserId);
            }

            if (model.Date != null)
            {
                postList = postList.Where(x => x.Date.ToShortDateString() == model.Date?.ToShortDateString());
            }

            if (model.Description != null)
            {
                postList = postList.Where(x => x.Description.ToLower().Contains(model.Description.ToLower()));
            }

            var result = PagedListHelper<Post>.Create(postList, model.PageNumber, model.PageSize);

            return result;
        }


        public async Task<Post> GetByIdAsync(int id)
        {
            return await _unitOfWork.PostRepository.GetByIdAsync(id);
        }


        public async Task CreateAsync(Post model)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(model.UserId);
            var userPosts = await _unitOfWork.PostRepository.GetAllPostsByUser(model.UserId);

            if (user == null)
            {
                throw new BusinessException("user dosen't exist");
            }


            if (userPosts?.Count() < 10)
            {
                var lastPost = userPosts.TakeLast(10).OrderByDescending(x => x.Date).FirstOrDefault();
                if ((DateTime.Now - lastPost.Date).TotalDays < 7)
                {
                    throw new BusinessException("You are no able to publish the post");
                }
            }

            if (model.Description.Contains("sex".ToLower()))
            {
                throw new BusinessException("content not allowed");
            }

            await _unitOfWork.PostRepository.CreateAsync(model);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task UpdateAsync(Post model)
        {
            _unitOfWork.PostRepository.Update(model);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task DeleteAsync(int Id)
        {
            await _unitOfWork.PostRepository.DeleteAsync(Id);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
