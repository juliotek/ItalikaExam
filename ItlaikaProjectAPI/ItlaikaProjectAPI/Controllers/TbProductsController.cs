using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ItlaikaProjectAPI.Models;
using ItlaikaProjectAPI.Models.RequestModels;

namespace ItlaikaProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbProductsController : ControllerBase
    {
        private readonly test_italikaContext _context;

        public TbProductsController(test_italikaContext context)
        {
            _context = context;
        }

        // GET: api/TbProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetTbProducts()
        {
            return await _context.TbProducts.Select(x=> new Product{
            IdProduct = x.IdProduct,
            Sku = x.Sku,
            Fert = x.Fert,
            Type = x.IdTypeNavigation.Type,
            IdType =x.IdTypeNavigation.IdType,
            Model = x.Model,
            Serie = x.Serie,
            Date = x.Date
            }).ToListAsync();
        }

        // GET: api/TbProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbProduct>> GetTbProduct(int id)
        {
            var tbProduct = await _context.TbProducts.FindAsync(id);

            if (tbProduct == null)
            {
                return NotFound();
            }

            return tbProduct;
        }

        // PUT: api/TbProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbProduct(int id, TbProduct tbProduct)
        {
            if (id != tbProduct.IdProduct)
            {
                return BadRequest();
            }

            _context.Entry(tbProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TbProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostTbProduct(Product product)
        {

            TbProduct tbProduct = new TbProduct();
            tbProduct.IdType = product.IdType;
            tbProduct.Model = product.Model;
            tbProduct.Sku = product.Sku;
            tbProduct.Fert = product.Fert;
            tbProduct.Serie = product.Serie;
            tbProduct.Date = DateTime.UtcNow;
            tbProduct.Status = true;

            _context.TbProducts.Add(tbProduct);

            await _context.SaveChangesAsync();

            return Ok( new { id = tbProduct.IdProduct });
        }

        // DELETE: api/TbProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbProduct(int id)
        {

            var tbProduct = await _context.TbProducts.FindAsync(id);

            if (tbProduct == null)
            {
                return NotFound();
            }

            _context.TbProducts.Remove(tbProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbProductExists(int id)
        {
            return _context.TbProducts.Any(e => e.IdProduct == id);
        }
    }
}
