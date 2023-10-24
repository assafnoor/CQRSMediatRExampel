using CQRSMediatRExampel.Models;
using MediatR;

namespace CQRSMediatRExampel.Commands
{
    public record AddProductCommand(Product Product):IRequest<Product>;
    
}
