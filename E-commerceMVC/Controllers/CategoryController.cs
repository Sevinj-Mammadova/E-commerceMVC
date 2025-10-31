using E_commerceMVC.Data;
using E_commerceMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerceMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly DataContext _data;

        public CategoryController(DataContext data)
        {
            _data = data;
        }
        public IActionResult Index()
        {
            List<Category> categories = _data.Categories.ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        //public async Task<IActionResult> GetCategoriesNonPaging()
        //{
        //    List<Category> categories = _data.Categories.ToList();
        //    return View(categories);
        //}
    }
}
