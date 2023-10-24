using CQRSMediatRExampel.Models;
using CQRSMediatRExampel.Queries;
using MediatR;

namespace CQRSMediatRExampel.Handlers
{
    public class GetByIdProductHandler : IRequestHandler<GetProductByIdQuerie, Product>
    {
        private readonly FakeData _fakeData;

        public GetByIdProductHandler(FakeData fakeData) => _fakeData = fakeData;

        public async Task<Product> Handle(GetProductByIdQuerie request, CancellationToken cancellationToken) =>
               await _fakeData.GetByIdProduct(request.id);
    }
}
