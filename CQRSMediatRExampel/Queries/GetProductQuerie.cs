using CQRSMediatRExampel.Models;
using MediatR;

namespace CQRSMediatRExampel.Queries
{
   public record GetProductQuerie:IRequest<IEnumerable<Product>>;
}
