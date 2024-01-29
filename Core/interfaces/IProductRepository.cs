
using Core.Entities;

namespace Core.interfaces
{

    public interface IProductRepository
    {

        Task<Product> getProductByIdAsync(int id);

        Task<IReadOnlyList<Product>> getALlProductAsync();

        Task<IReadOnlyList<ProductBrand>> getAllProductBrandsAsync();

        Task<IReadOnlyList<ProductType>> getAllProductTypesAsync();

    }
}