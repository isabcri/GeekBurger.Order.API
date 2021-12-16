using GeekBurger.Order.API.Contratos;
using GeekBurger.Order.API.Services.Context;
using GeekBurger.Order.API.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekBurger.Order.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _context;
        public OrderService(DataContext context)
        {
            _context = context;
        }

        public List<OrderModel> GetOrder()
        {
            var ordersList =  _context.Order.ToList();
            return ordersList;
        }

        public OrderModel GetOrderId(int id)
        {
            var order =  _context.Order.Find(id);
            return order;
        }


        public void Add(OrderModel order)
        {
          try
            {
                _context.Order.Add(order);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro ao salvar Order : {ex.Message}");
            }
        }


        public void Delete(int OrderId)
        {
          
            try
            {
              ///  OrderModel order = GetOrderStoreName(storeName);
                _context.Remove(OrderId);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception($"Ocorreu um erro em deletar Order : {ex.Message}");
            }

        }

        public Task UpdateOrder(OrderModel order)
        {
            _context.Update(order);
            _context.SaveChanges();

            return Task.CompletedTask;

        }


    }
}
