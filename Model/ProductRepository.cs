namespace EcommerceApp.Model
{
    public class ProductRepository : IProductRepository
    {
        UserDatabaseContext _userDatabaseContext;

        public ProductRepository(UserDatabaseContext userDatabaseContext)
        {
            _userDatabaseContext = userDatabaseContext;
        }
        public IEnumerable<Products> GetAllProducts => _userDatabaseContext.Products.OrderBy(p => p.ProductName);

        
    }
}
