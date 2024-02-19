
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiletersForCountSpecification : BaseSpecifications<Product>
    {
        public ProductWithFiletersForCountSpecification(ProductSpecParams productParams)
        : base(x => 
                (string.IsNullOrEmpty(productParams.Search) || x.name.ToLower().Contains(productParams.Search)) &&
                (!productParams.BrandId.HasValue || x.productbrandId == productParams.BrandId) &&   
                (!productParams.TypeId.HasValue || x.producttypeId == productParams.TypeId)
            )
        {
            
        }
    }
}