
namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string name { get; set; }

        public string description { get; set; }

        public decimal price { get; set; }

        public string pictureUrl { get; set; }

        public ProductType producttype { get; set; }

        public int producttypeId { get; set; }

        public ProductBrand productbrand { get; set; }

         public int productbrandId { get; set; }
    }
}