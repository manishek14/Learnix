using Blog.Context;
using Common.Infrastructure.Repository;

namespace Blog.Services.Posts
{
    public class PostRepository : BaseRepository<Domain.Post, BlogConext>, IPostRepository
    {
        public PostRepository(BlogConext context) : base(context)
        {
        }
    }
}
