using CQRSMediatRExampel.Commands;
using CQRSMediatRExampel.Models;
using MediatR;

namespace CQRSMediatRExampel.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand,Product>
    {
        private readonly FakeData _fakeData;

        public AddProductHandler(FakeData fakeData) => _fakeData = fakeData;



        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeData.AddProduct(request.Product);

            return request.Product;
        }

    }
}
