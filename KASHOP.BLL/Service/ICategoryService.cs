using KASHOP.DAL.DTO.Request;
using KASHOP.DAL.DTO.Response;
using KASHOP.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Service
{
    public interface ICategoryService
    {
       public Task<List<CategoryResponse>> GetAllCategoriesAsync();
       public Task<CategoryResponse> CreateCategoryAsync(CategoryRequest category);
        public Task<CategoryResponse> GetCategoryAsync(Expression<Func<Category, bool>> filter);
    }
}
