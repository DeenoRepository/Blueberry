using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blueberry.API.Data;
using Blueberry.API.Models;

namespace Blueberry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockItemsController : ControllerBase
    {
        private readonly BlueberryAPIContext _context;

        public StockItemsController(BlueberryAPIContext context)
        {
            _context = context;
        }

        // GET: api/StockItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockItem>>> GetStockItem()
        {
          if (_context.StockItem == null)
          {
              return NotFound();
          }
            return await _context.StockItem.ToListAsync();
        }

        // GET: api/StockItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockItem>> GetStockItem(int id)
        {
          if (_context.StockItem == null)
          {
              return NotFound();
          }
            var stockItem = await _context.StockItem.FindAsync(id);

            if (stockItem == null)
            {
                return NotFound();
            }

            return stockItem;
        }

        // PUT: api/StockItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockItem(int id, StockItem stockItem)
        {
            if (id != stockItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(stockItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockItemExists(id))
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

        // POST: api/StockItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StockItem>> PostStockItem(StockItem stockItem)
        {
          if (_context.StockItem == null)
          {
              return Problem("Entity set 'BlueberryAPIContext.StockItem'  is null.");
          }
            _context.StockItem.Add(stockItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockItem", new { id = stockItem.Id }, stockItem);
        }

        // DELETE: api/StockItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStockItem(int id)
        {
            if (_context.StockItem == null)
            {
                return NotFound();
            }
            var stockItem = await _context.StockItem.FindAsync(id);
            if (stockItem == null)
            {
                return NotFound();
            }

            _context.StockItem.Remove(stockItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StockItemExists(int id)
        {
            return (_context.StockItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
