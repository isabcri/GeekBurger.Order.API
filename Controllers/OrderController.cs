
using GeekBurger.Order.API.Contratos;
using GeekBurger.Order.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GeekBurger.Order.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger , IOrderService orderService)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpGet("order")]
        public IActionResult GetOrder()
        {
            var result = _orderService.GetOrder();

            _logger.LogTrace($"Controller: OrderController - Action: GetOrder  - Passo: data={result}");
            _logger.LogInformation(result.ToString());

            return Json(result);
        }


        [HttpGet("id")]
        public IActionResult GetOrderId(int id)
        {
            
            var result = _orderService.GetOrderId(id);

            _logger.LogTrace($"Controller: OrderController - Action: GetOrderParametro  - Passo: data={result}");
            _logger.LogInformation(result.ToString());

            return Json(result);
        }


        [HttpPost("pay")]
        public IActionResult AddOrder([FromBody]  OrderModel order)
        {
            try
            {
                 _orderService.Add(order);
                return Json(GetOrder());
            }

            catch (Exception e)
            {
                _logger.LogError(e, "Erro ao salvar Order");
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder( int OrderId)
        {          
            _orderService.Delete(OrderId);
            return Json(GetOrder());
        }


        [HttpPut("updateorder")]
        public IActionResult UpdateOrder(OrderModel order)
        {
            var res = _orderService.UpdateOrder(order);
            return Json(GetOrder());
        }

    }
}
