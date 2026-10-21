using AutoMapper;
using Blog.Domain;
using Blog.Services.Categories;
using Blog.Services.DTOs.Command;
using Blog.Services.DTOs.Query;
using Common.Application;

namespace Blog.Services
{
    public interface IBlogService
    {
        Task<OperationResult> CreateCategory(CreateCategoryCommand command);
        Task<OperationResult> EditCategory(EditCategoryCommand command);
        Task<OperationResult> DeleteCategory(Guid CategoryId);
        Task<List<BlogCategoryDto>> GetAllCategoryDto();
        Task<BlogCategoryDto> GetCategoryByIdTask(Guid Id);
    }

    public class BlogService : IBlogService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public BlogService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
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

            _categoryRepository.Update(category); 
            await _categoryRepository.Save();

            return OperationResult.Success();
        }

        public async Task<List<BlogCategoryDto>> GetAllCategoryDto()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<BlogCategoryDto>>(categories);
        }

        public async Task<BlogCategoryDto> GetCategoryByIdTask(Guid Id)
        {
            var category = await _categoryRepository.GetAsync(Id);
            return _mapper.Map<BlogCategoryDto>(category);
        }
    }
}