using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Services.Posts
{
    interface IPostRepository : IBaseRepository<Domain.Post>
    {
    }
}
