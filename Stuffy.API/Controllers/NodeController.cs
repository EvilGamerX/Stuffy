using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stuffy.API.Data;
using Stuffy.API.Entities;
using Stuffy.Entity;

namespace Stuffy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private readonly StuffyAPIContext _context;

        public NodeController(StuffyAPIContext context)
        {
            _context = context;
        }

        // GET: api/Node
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Node>>> GetNode()
        {
            return await _context.Nodes.ToListAsync();
        }

        // GET: api/Node/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Node>> GetNode(Guid id)
        {
            var node = await _context.Nodes.FindAsync(id);

            if (node == null)
            {
                return NotFound();
            }

            return node;
        }

        // PUT: api/Node/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNode(Guid id, Node node)
        {
            if (id != node.Id)
            {
                return BadRequest();
            }

            _context.Entry(node).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NodeExists(id))
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

        // POST: api/Node
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Node>> PostNode(Node node)
        {
            _context.Nodes.Add(node);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNode", new { id = node.Id }, node);
        }

        // DELETE: api/Node/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Node>> DeleteNode(Guid id)
        {
            var node = await _context.Nodes.FindAsync(id);
            if (node == null)
            {
                return NotFound();
            }

            _context.Nodes.Remove(node);
            await _context.SaveChangesAsync();

            return node;
        }

        private bool NodeExists(Guid id)
        {
            return _context.Nodes.Any(e => e.Id == id);
        }
    }
}
