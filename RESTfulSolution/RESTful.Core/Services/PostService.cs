using RESTful.Core.Entities;
using RESTful.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTful.Core.Services
{
    // externaliser dans une autre couche Application
    // Cqrs, services, etc...
    // ici y aurra Que 3 clsses donc pas trop besoin
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public PostService(IPostRepository postRepository, IUserRepository userRepository)
        {
            this._postRepository = postRepository;
            this._userRepository = userRepository;
        }


        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            return await _postRepository.GetAllPosts();
        }


        public async Task<Post> GetById(int id)
        {
            return await _postRepository.GetById(id);
        }


        public async Task Create(Post model)
        {
            var user = await _userRepository.GetById(model.UserId);

            if (user == null)
            {
                throw new Exception("user dosen't exist");
            }

            await _postRepository.Create(model);
        }


        public async Task<bool> Update(Post model)
        {
            return await _postRepository.Update(model);
        }


        public async Task<bool> Delete(int Id)
        {
            return await _postRepository.Delete(Id);
        }

    }
}
