using System.Threading.Tasks;
using MassTransit;
using masstransit_rabbitmq.Api.Models;
using masstransit_rabbitmq.Shared;
using Microsoft.AspNetCore.Mvc;

namespace masstransit_rabbitmq.Api.Controllers
{
    [ApiController]
    [Route("api/item")]
    public class ItemController : Controller
    {
        private readonly IPublishEndpoint _publishEndpoint;
        
        public ItemController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateItem(CreateItemViewModel model)
        {
            await _publishEndpoint.Publish<ICreateItem>(new
            {
                Id = 1,
                model.Name,
                model.Description
            });
            
            return Ok();
        }
    }
}