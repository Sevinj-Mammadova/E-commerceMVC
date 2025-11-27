using System.Diagnostics;
using E_commerce.DataAccess.Repository;
using E_commerce.DataAccess.Repository.IRepository;
using E_commerce.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_commerceMVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(products);
        }
        public IActionResult Details(int productId)
        {
            Product product = _unitOfWork.Product.Get(u=>u.Id==productId, includeProperties: "Category");
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
