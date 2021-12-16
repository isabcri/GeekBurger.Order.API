using GeekBurger.Order.API.Contratos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeekBurger.Order.API.Services.Interface
{
    public interface IOrderService
    {
        OrderModel GetOrderId(int id);
        void Add(OrderModel OrderId);
        void Delete(int OrderId);       
        List<OrderModel> GetOrder();
        Task UpdateOrder(OrderModel order);
    }
}
