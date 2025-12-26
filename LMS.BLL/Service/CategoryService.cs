using LMS.BLL.Model;
using LMS.BLL.Repository;
using LMS.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LMS.BLL.Service
{
    public class CategoryService : ICategoryService
    {
        GenericRepository<Category> _categoryRepository;

        public CategoryService()
        {
            _categoryRepository = new GenericRepository<Category>();
        }

        public async Task<CategoryDTO> CreateCategory(CategoryDTO categoryDTO)
        {
            var category = new Category
            {
                Name = categoryDTO.Name,
                Description = categoryDTO.Description
            };
            var createdCategory = await _categoryRepository.CreateAsync(category);
            categoryDTO.Id = createdCategory.Id;
            return categoryDTO;
        }
        public async Task<bool> DeleteCategory(Expression<Func<Category, bool>> filter)
        {
            var category = await _categoryRepository.GetByAsync(filter);
            if (category == null)
                return false;
            category.IsActive = false;
            await _categoryRepository.UpdateAsync(category);
            return true;
        }
        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync(Expression<Func<Category, bool>> filter)
        {
            var categories = await _categoryRepository.GetAllAsync(filter);
            var categoryDTOs = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                categoryDTOs.Add(new CategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                });
            }
            return categoryDTOs;
        }
        public async Task<CategoryDTO> GetCategoryByAsync(Expression<Func<Category, bool>> filter)
        {
            var category = await _categoryRepository.GetByAsync(filter);
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }
        public async Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDTO)
        {
            var category = new Category
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name,
                Description = categoryDTO.Description
            };
            var updatedCategory = await _categoryRepository.UpdateAsync(category);
            return new CategoryDTO
            {
                Id = updatedCategory.Id,
                Name = updatedCategory.Name,
                Description = updatedCategory.Description
            };
        }

    }

    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync(Expression<Func<Category, bool>> filter);
        public Task<CategoryDTO> GetCategoryByAsync(Expression<Func<Category, bool>> filter);
        public Task<CategoryDTO> CreateCategory(CategoryDTO categoryDTO);
        public Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDTO);
        public Task<bool> DeleteCategory(Expression<Func<Category, bool>> filter);

    }
}
