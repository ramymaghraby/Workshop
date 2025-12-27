using LMS.BLL.Model;
using LMS.BLL.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LMS.Portal.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService _categoryService;
        public CategoryController()
        {
            _categoryService = new CategoryService();
        }
        public async Task<IActionResult> Index()
        {
            var data = await _categoryService.GetAllCategoriesAsync(a => a.IsActive == true);
            return View(data);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var data = await _categoryService.GetCategoryByAsync(a => a.IsActive == true && a.Id == id );
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryDTO model)
        {
            if(ModelState.IsValid)
            {
                var result =  _categoryService.CreateCategory(model);
                if(result != null)
                    return RedirectToAction("Index");
            }
            TempData["msg"] = $"can't create category {model.Name} , please check log file";
            return View(model);
        }
        [HttpGet]
        public IActionResult Update(Guid id)
        {
            var data = _categoryService.GetCategoryByAsync(a=>a.Id == id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryDTO model)
        {
            if (ModelState.IsValid)
            { 
                var result = _categoryService.UpdateCategory(model);
                if (result != null)
                {
                    TempData["success"] = $"Category {model.Name} updates successfully";
                    return RedirectToAction("Index");
                }
            }
            TempData["msg"] = $"Couldn't update {model.Name}, please check log file";
            return View();
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var res = await _categoryService.DeleteCategory(a=>a.Id == id);

            return View();
        }
    }
}
