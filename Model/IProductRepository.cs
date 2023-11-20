namespace EcommerceApp.Model
{
    public interface IProductRepository
    {
       public IEnumerable<Products> GetAllProducts { get; }
    }
}
