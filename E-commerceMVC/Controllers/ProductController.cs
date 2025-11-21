using E_commerce.DataAccess.Repository.IRepository;
using E_commerce.Models.Models;
using E_commerce.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ProductController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public ProductController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public IActionResult Index()
    {
        List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
        return View(objProductList);
    }

    public IActionResult Upsert(int? id)
    {
        //IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
        //{
        //    Text = u.Name,
        //    Value = u.Id.ToString()
        //});
        //ViewBag.CategoryList = CategoryList;

        ProductVM productVM = new ProductVM()
        {
            Product = new Product(),
            CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            })

        };
        if(id == null || id == 0)
        {
            return View(productVM);
        }
        else
        {
            productVM.Product = _unitOfWork.Product.Get(u => u.Id == id);
            return View(productVM);
        }
        
    }
    [HttpPost]
    public IActionResult Upsert(ProductVM productVM, IFormFile? file)
    {

        if (ModelState.IsValid)
        {
            _unitOfWork.Product.Add(productVM.Product);
            _unitOfWork.Save();
            TempData["success"] = "Product created successfully";
            return RedirectToAction("Index");
        }
        else
        {
            productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            return View(productVM);
        }

    }
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        Product? ProductFromDb = _unitOfWork.Product.Get(u => u.Id == id);

        if (ProductFromDb == null)
        {
            return NotFound();
        }
        return View(ProductFromDb);
    }
    [HttpPost, ActionName("Delete")]
    public IActionResult DeletePOST(int? id)
    {
        Product? obj = _unitOfWork.Product.Get(u => u.Id == id);
        if (obj == null)
        {
            return NotFound();
        }
        _unitOfWork.Product.Remove(obj);
        _unitOfWork.Save();
        TempData["success"] = "Product deleted successfully";
        return RedirectToAction("Index");
    }
}

