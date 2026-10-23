using Blog.Domain;
using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Services.Posts
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        void Delete(Post post);
    }
}
