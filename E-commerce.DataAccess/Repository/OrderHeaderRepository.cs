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
public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
{
    private DataContext _data;
    public OrderHeaderRepository(DataContext data) : base(data)
    {
        _data = data;
    }

    public void Update(OrderHeader obj)
    {
        _data.OrderHeaders.Update(obj);
    }
}
}