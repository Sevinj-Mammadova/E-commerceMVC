using E_commerce.DataAccess.Data;
using E_commerce.DataAccess.Repository.IRepository;
using E_commerce.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly DataContext _data;
        public ProductRepository(DataContext data) : base(data)
        {
            _data = data;
        }

        public void Update(Product obj)
        {
            var product = _data.Products.FirstOrDefault(u => u.Id == obj.Id);
            if (product != null)
            {
                product.Title = obj.Title;
                product.Description = obj.Description;
                product.CategoryId = obj.CategoryId;
                product.Price = obj.Price;
                product.ISBN = obj.ISBN;
                product.Author = obj.Author;
                product.Price100 = obj.Price100;
                product.Price50 = obj.Price50;
                product.ListPrice = obj.ListPrice;
                if (obj.ImageUrl != null)
                {
                    product.ImageUrl = obj.ImageUrl;
                }
            }
        }
    }
}