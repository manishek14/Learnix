using Blog.Domain;
using Common.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Services.Categories
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        void Delete(Category category);
    }
}
