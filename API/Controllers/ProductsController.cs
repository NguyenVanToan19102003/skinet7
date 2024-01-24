
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        
        public ProductsController(StoreContext context)
        {  
            _context = context;
            
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> getAllProducts(){
            var listProducts =await _context.products.ToListAsync();
            return listProducts;
        }


        [HttpGet("{id}")] 
        public async Task<ActionResult<Product>> getProduct(int id){
           return await _context.products.FindAsync(id);
        }

    }
}