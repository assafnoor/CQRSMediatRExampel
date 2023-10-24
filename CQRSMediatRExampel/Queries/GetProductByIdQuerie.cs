using CQRSMediatRExampel.Models;
using MediatR;

namespace CQRSMediatRExampel.Queries
{
   public record GetProductByIdQuerie(int id):IRequest<Product>;
}
