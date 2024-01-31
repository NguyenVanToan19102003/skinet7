
using Core.Entities;

namespace API.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string name { get; set; }

        public string description { get; set; }

        public decimal price { get; set; }

        public string pictureUrl { get; set; }

        public string producttype { get; set; }

        public int producttypeId { get; set; }

        public string productbrand { get; set; }

         public int productbrandId { get; set; }
    }
}