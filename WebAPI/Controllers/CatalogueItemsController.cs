using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/CatalogueItems")]
    [ApiController]
    public class CatalogueItemsController : ControllerBase
    {
        private readonly CatalogueContext _context;

        public CatalogueItemsController(CatalogueContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Return all items in catalogue
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatalogueItem>>> GetCatalogueItems()
        {
            return await _context.CatalogueItems.ToListAsync();
        }

        /// <summary>
        /// Return item from catalogue with specified 'Id'
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CatalogueItem>> GetCatalogueItem(long id)
        {
            var catalogueItem = await _context.CatalogueItems.FindAsync(id);

            if (catalogueItem == null)
            {
                return NotFound();
            }

            return catalogueItem;
        }

        /// <summary>
        /// Updates 'Description' in catalogue for item with specified 'Id'
        /// </summary>
        /// <returns></returns>
        [HttpPost("{id}, {description}")]
        public async Task<ActionResult<CatalogueItem>> UpdateCatalogueItemDescription(long id, string description)
        {
            var catalogueItem = await _context.CatalogueItems.FindAsync(id);
            if (catalogueItem == null)
            {
                return NotFound();
            }

            catalogueItem.Description = description;
            _context.CatalogueItems.Update(catalogueItem);
            await _context.SaveChangesAsync();

            return AcceptedAtAction("UpdateCatalogueItem");
        }
    }
}
