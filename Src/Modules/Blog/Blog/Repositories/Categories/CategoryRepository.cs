using Blog.Context;
using Blog.Domain;
using Common.Infrastructure.Repository;

namespace Blog.Services.Categories
{
    public class CategoryRepository : BaseRepository<Category, BlogConext>, ICategoryRepository
    {
        public CategoryRepository(BlogConext context) : base(context)
        {
        }

        public void Delete(Category category)
        {
            Context.Categories.Remove(category);
        }
    }
}
