using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using VideoAndBook.Models;

namespace VideoAndBook.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly ILogger<PurchaseOrderController> _logger;
        private readonly POProcessorFactory _poProcessorFactory;

        public PurchaseOrderController(ILogger<PurchaseOrderController> logger, POProcessorFactory poProcessorFactory)
        {
            _logger = logger;
            _poProcessorFactory = poProcessorFactory;
        }

        [HttpGet]
        public IEnumerable<PurchaseOrderModel> Get([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 20)
        {
            return Enumerable.Range(1, 100).Select(index => new PurchaseOrderModel
            {
                Id = index,
                OrderNumber = $"ORDER{index}",
                Customer = new CustomerModel
                {
                    Id = index * 10,
                }
            })
            .Skip(pageSize * pageIndex) // Should be paging in DataAccess layer
            .Take(pageSize);
        }

        [HttpGet]
        [Route("id")]
        public PurchaseOrderModel Get(int id)
        {
            return new PurchaseOrderModel
            {
                Id = id,
                OrderNumber = $"ORDER{id}",
                Customer = new CustomerModel
                {
                    Id = id * 10,
                }
            };
        }

        [HttpPut]
        [Route("id")]
        public int Put(PurchaseOrderModel po)
        {
            return _poProcessorFactory.CreateProcessor().Process(new BusinessLayer.Models.PurchaseOrderModel
            {
                // Data mapped from API model. Can use AutoMapper
            });
        }
    }
}