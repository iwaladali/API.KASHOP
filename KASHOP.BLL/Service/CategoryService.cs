using KASHOP.DAL.DTO.Request;
using KASHOP.DAL.DTO.Response;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repository;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Service
{
    public class CategoryService : ICategoryService
    {
    private readonly ICategoryRepository _CategoryRepo;
        public CategoryService(ICategoryRepository CategoryRepo) {
            _CategoryRepo = CategoryRepo;
        }
        public async Task<CategoryResponse> CreateCategoryAsync(CategoryRequest category)
        {

            var cat = category.Adapt<Category>();
         await   _CategoryRepo.CreateAsync(cat);
            return category.Adapt<CategoryResponse>();

        }

        public async Task<List<CategoryResponse>> GetAllCategoriesAsync()
        {
          var categories = await _CategoryRepo.GetAllAsync(new string[] { nameof(Category.Translatione)});
            var cat = categories.Adapt<List<CategoryResponse>>();
            return cat;
        }
        public async Task<CategoryResponse> GetCategoryAsync(Expression<Func<Category,bool>>filter)
        {
            var car=await _CategoryRepo.GetOneAsync(filter,new string[] { nameof(Category.Translatione) });
            return car.Adapt<CategoryResponse>();
        }

    }
}
