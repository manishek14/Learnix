using Blog.Context;
using Blog.Domain;
using Common.Infrastructure.Repository;

namespace Blog.Services.Posts
{
    public class PostRepository : BaseRepository<Domain.Post, BlogConext>, IPostRepository
    {
        public PostRepository(BlogConext context) : base(context)
        {

        }

        public void Delete(Post post)
        {
            Context.Posts.Remove(post);
        }
    }
}
