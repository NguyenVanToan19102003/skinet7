
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecifications<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
            : base(x => 
                (string.IsNullOrEmpty(productParams.Search) || x.name.ToLower().Contains(productParams.Search)) &&
                (!productParams.BrandId.HasValue || x.productbrandId == productParams.BrandId) &&   
                (!productParams.TypeId.HasValue || x.producttypeId == productParams.TypeId)
            )
        {
            AddInclude(x => x.producttype);
            AddInclude(x => x.productbrand);
            AddOrderBy(x => x.name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1) , productParams.PageSize);

            if(!string.IsNullOrEmpty(productParams.Sort)){

                switch(productParams.Sort){
                    case "priceAsc" : 
                        AddOrderBy(p => p.price);   
                        break;
                    case "priceDesc" :
                        AddOrderByDescending(p => p.price);
                        break;
                    default : 
                        AddOrderBy(n => n.name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.producttype);
            AddInclude(x => x.productbrand);
        }
    }
}