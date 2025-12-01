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
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly DataContext _data;

        public CompanyRepository(DataContext data) : base(data)
        {
            _data = data;
        }
        public void Update(Company obj)
        {
            _data.Companies.Update(obj);
        }
    }
}

