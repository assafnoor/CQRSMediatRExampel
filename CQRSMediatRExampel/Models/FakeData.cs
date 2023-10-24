namespace CQRSMediatRExampel.Models
{
    public class FakeData
    {
        private List<Product> _products;
        public FakeData()
        {
            _products = new List<Product>
            {
                new Product{Id=1,Name="test" },
                new Product{Id=2,Name="test" },
                new Product{Id=3,Name="test" },
               
            };
        }
        public async Task AddProduct(Product product)
        {
            _products.Add(product);
            await Task.CompletedTask;
        }
        public async Task<IEnumerable<Product>> GetProduct() => await Task.FromResult(_products);
        public async Task<Product> GetByIdProduct(int id) => await Task.FromResult(_products.Single(p=>p.Id==id));
        public async Task EventOccured(Product product, string evt)
        {
            _products.Single(p => p.Id == product.Id).Name = $"{product.Name} evt: {evt}";
            await Task.CompletedTask;
        }
    }
}
