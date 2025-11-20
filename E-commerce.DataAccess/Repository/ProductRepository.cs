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
            _data.Products.Update(obj);
        }
    }
}
