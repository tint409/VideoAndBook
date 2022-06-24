using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using VideoAndBook.Models;

namespace VideoAndBook.Controllers
{
    /// NOTE: this is an example of APIs (get/post/put/patch/delete/getitems) for 1 resource (PurchaseOrder)
    /// We can identify which resources to publish (customer, product) and which resources not publish.
    /// Then can build similar APIs for those published resources
    
    /// CATCHING: we need to consider caching strategy
    ///     1. What to cacth
    ///     2. How long cacth should last, how long to refresh
    ///     3. What type? In-memory or Cache service (redis) or Response caching (response cache based on Http header)

    [ApiController]
    [Route("[controller]")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly POProcessorFactory _poProcessorFactory;

        public PurchaseOrderController(POProcessorFactory poProcessorFactory)
        {
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
        [Route("{id}")]
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

        [HttpGet]
        [Route("{id}/items")]
        public IEnumerable<PurchaseOrderItemModel> GetItems(int id)
        {
            return new List<PurchaseOrderItemModel>()
            { 
                new PurchaseOrderItemModel
                {
                    Id = 100 + id,
                    ProductName = $"Product{id}",
                    Price = 100 * id,
                    Quantity = id
                }
            };
        }

        [HttpPost]
        public int Post([FromBody] PurchaseOrderModel po)
        {
            return _poProcessorFactory.CreateProcessor().Process(new BusinessLayer.Models.PurchaseOrderDTO
            {
                // Data mapped from API model. Can use AutoMapper
            });
        }

        [HttpPut]
        [Route("{id}")]
        public bool Put(int id, [FromBody] PurchaseOrderModel po)
        {
            // Update PO
            return true;
        }

        [HttpPatch]
        [Route("{id}")]
        public bool Patch(int id, [FromBody] PurchaseOrderModel po)
        {
            // Update PO
            return true;
        }

        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {
            // Delete PO
            return true;
        }
    }
}