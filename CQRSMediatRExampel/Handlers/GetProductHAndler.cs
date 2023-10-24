using CQRSMediatRExampel.Models;
using CQRSMediatRExampel.Queries;
using MediatR;

namespace CQRSMediatRExampel.Handlers
{
    public class GetProductHAndler : IRequestHandler<GetProductQuerie, IEnumerable<Product>>
    {
        private readonly FakeData _fakedata;

        public GetProductHAndler(FakeData fakedata)
        => _fakedata = fakedata;

        public async Task<IEnumerable<Product>> Handle(GetProductQuerie request, CancellationToken cancellationToken)
            => await  _fakedata.GetProduct();
        
    }
}
