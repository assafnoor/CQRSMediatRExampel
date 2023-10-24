using CQRSMediatRExampel.Commands;
using CQRSMediatRExampel.Models;
using CQRSMediatRExampel.Notification;
using CQRSMediatRExampel.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatRExampel.Controllers
{
    [Route("Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IPublisher _publisher;

     
        public ProductsController(ISender sender, IPublisher publisher)
        {
            _sender = sender;
              _publisher = publisher;
        }

        [HttpGet("Get")]
        public async Task<ActionResult> Getproduct()
        {
           var product= await _sender.Send(new GetProductQuerie());
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            var productToReturn = await _sender.Send(new AddProductCommand(product));
            await _publisher.Publish(new ProductAddedNotification(productToReturn));
            return CreatedAtRoute("GetByIdproduct", new { id = productToReturn.Id }, productToReturn);
        }
        [HttpGet("GetById{id}",Name = "GetByIdproduct")]
        public async Task<ActionResult> GetByIdproduct(int id)
        {
          var product= await _sender.Send(new GetProductByIdQuerie(id));
            return Ok(product);
        }
    }
}
