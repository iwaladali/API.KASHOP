using KASHOP.BLL.Service;
using KASHOP.DAL.Data;
using KASHOP.DAL.DTO.Request;
using KASHOP.DAL.DTO.Response;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repository;
using KASHOP.PL.Resources;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace KASHOP.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
       private readonly ICategoryService _CategoryService;
        private readonly IStringLocalizer<SharedResources> _localizer;
    public CategoriesController (ICategoryService CategoryService, IStringLocalizer<SharedResources> localizer)
        {
            _CategoryService = CategoryService;
            _localizer = localizer;
        }

        [HttpPost("")]
        public IActionResult Create(CategoryRequest request){

            _CategoryService.CreateCategoryAsync(request);
            return Ok(new
            {
               message= _localizer["Success"].Value
            });
        }

        [HttpGet("")]
        public IActionResult Index() {

            var response = _CategoryService.GetAllCategoriesAsync();

            //var response = cat.Adapt<List<CategoryResponse>>();

            return Ok(new
            {
                data=response,
               message= _localizer["Success"].Value
            });          
        }
        

    }
}
