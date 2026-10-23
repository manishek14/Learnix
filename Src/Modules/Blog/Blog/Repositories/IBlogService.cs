using AutoMapper;
using Blog.Domain;
using Blog.Services.Categories;
using Blog.Services.DTOs.Command;
using Blog.Services.DTOs.Query;
using Blog.Services.Posts;
using Common.Application;

namespace Blog.Services
{
    public interface IBlogService
    {
        Task<OperationResult> CreateCategory(CreateCategoryCommand command);
        Task<OperationResult> EditCategory(EditCategoryCommand command);
        Task<OperationResult> DeleteCategory(Guid CategoryId);
        Task<List<BlogCategoryDto>> GetAllCategoryDto();
        Task<BlogCategoryDto> GetCategoryById(Guid Id);

        Task<OperationResult> CreatePost(CreatePostCommand command);
        Task<OperationResult> EditPost(EditPostCommand command);
        Task<OperationResult> DeletePost(Guid postId);
        Task<BlogPostDto> GetPostById(Guid Id);
        Task<List<BlogPostDto>> GetAllPostDto();
    }

    public class BlogService : IBlogService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public BlogService(ICategoryRepository categoryRepository,
                           IPostRepository postRepository,
                           IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult> CreateCategory(CreateCategoryCommand command)
        {
            if (await _categoryRepository.ExistsAsync(c => c.Slug == command.Slug))
                return OperationResult.Error("این Slug قبلاً استفاده شده است.");

            var category = _mapper.Map<Category>(command);
            category.Id = Guid.NewGuid();

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.Save();

            return OperationResult.Success();
        }

        public async Task<OperationResult> EditCategory(EditCategoryCommand command)
        {
            var category = await _categoryRepository.GetTracking(command.Id);
            if (category == null)
                return OperationResult.Error("دسته‌بندی یافت نشد.");

            if (await _categoryRepository.ExistsAsync(c => c.Slug == command.Slug && c.Id != command.Id))
                return OperationResult.Error("این Slug قبلاً استفاده شده است.");

            _mapper.Map(command, category);
            _categoryRepository.Update(category);
            await _categoryRepository.Save();

            return OperationResult.Success();
        }

        public async Task<OperationResult> DeleteCategory(Guid CategoryId)
        {
            var category = await _categoryRepository.GetTracking(CategoryId);
            if (category == null)
                return OperationResult.Error("دسته‌بندی یافت نشد.");

            if (await _postRepository.ExistsAsync(p => p.CategoryId == CategoryId))
                return OperationResult.Error("این دسته‌بندی دارای پست است و قابل حذف نیست.");

            _categoryRepository.Delete(category);
            await _categoryRepository.Save();

            return OperationResult.Success();
        }

        public async Task<List<BlogCategoryDto>> GetAllCategoryDto()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<BlogCategoryDto>>(categories);
        }

        public async Task<BlogCategoryDto> GetCategoryById(Guid Id)
        {
            var category = await _categoryRepository.GetAsync(Id);
            return _mapper.Map<BlogCategoryDto>(category);
        }

        public async Task<OperationResult> CreatePost(CreatePostCommand command)
        {
            if (await _postRepository.ExistsAsync(p => p.Slug == command.Slug))
                return OperationResult.Error("این Slug قبلاً استفاده شده است.");

            if (!await _categoryRepository.ExistsAsync(c => c.Id == command.CategoryId))
                return OperationResult.Error("دسته‌بندی انتخاب‌شده یافت نشد.");

            var post = _mapper.Map<Post>(command);
            post.Id = Guid.NewGuid();
            post.CreationDate = DateTime.Now;
            post.Visit = 0;

            await _postRepository.AddAsync(post);
            await _postRepository.Save();

            return OperationResult.Success();
        }

        public async Task<OperationResult> EditPost(EditPostCommand command)
        {
            var post = await _postRepository.GetTracking(command.Id);
            if (post == null)
                return OperationResult.Error("پست یافت نشد.");

            if (await _postRepository.ExistsAsync(p => p.Slug == command.Slug && p.Id != command.Id))
                return OperationResult.Error("این Slug قبلاً استفاده شده است.");

            if (!await _categoryRepository.ExistsAsync(c => c.Id == command.CategoryId))
                return OperationResult.Error("دسته‌بندی انتخاب‌شده یافت نشد.");

            _mapper.Map(command, post);
            _postRepository.Update(post);
            await _postRepository.Save();

            return OperationResult.Success();
        }

        public async Task<OperationResult> DeletePost(Guid postId)
        {
            var post = await _postRepository.GetTracking(postId);
            if (post == null)
                return OperationResult.Error("پست یافت نشد.");

            _postRepository.Delete(post);
            await _postRepository.Save();

            return OperationResult.Success();
        }

        public async Task<BlogPostDto> GetPostById(Guid Id)
        {
            var post = await _postRepository.GetAsync(Id);
            return _mapper.Map<BlogPostDto>(post);
        }

        public async Task<List<BlogPostDto>> GetAllPostDto()
        {
            var posts = await _postRepository.GetAllAsync();
            return _mapper.Map<List<BlogPostDto>>(posts);
        }
    }
}