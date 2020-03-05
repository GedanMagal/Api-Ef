using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Controllers
{
    [Route("products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Product>>> Get(
            [FromServices] DataContext context)
        {
            var products = await context
                .Products
                    .Include(x => x.Category)
                        .AsNoTracking().ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("id:int")]
        [AllowAnonymous]
        public async Task<ActionResult<Product>> GetById(
            int id,
            [FromServices]DataContext context)
        {
            var product = await context
            .Products
                .Include(x => x.Category)
                    .AsNoTracking()
                        .FirstOrDefaultAsync(x => x.Id == id);
            return product;
        }

        [HttpGet]
        [Route("categories/{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<List<Product>>> GetByCategory(
            [FromServices]DataContext context, int id)
        {
            var products = await context
            .Products
            .Include(i => i.Category)
                .AsNoTracking()
                    .Where(x => x.CategoryId == id)
                        .ToListAsync();
            return products;

        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "employee")]

        public async Task<ActionResult<Product>> Post(
            [FromServices]DataContext context,
            [FromBody]Product model
        )
        {

            if (ModelState.IsValid)
            {
                context.Products.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}