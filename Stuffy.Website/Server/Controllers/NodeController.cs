using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stuffy.Website.Server.Data;
using Stuffy.Website.Shared.Entities;
using Stuffy.Website.Shared.Models;

namespace Stuffy.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NodeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<NodeController> logger;

        public NodeController(ApplicationDbContext context, ILogger<NodeController> logger)
        {
            _context = context;
            this.logger = logger;
        }

        // GET: api/Node
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NodeViewModel>>> GetNode(bool populate = false)
        {
            var nodes = await _context.Nodes.ToListAsync();
            if(populate)
            {
                nodes = PopulateNodes(nodes).ToList();
            }
            return nodes?.Select(node => new NodeViewModel(node)).ToList();
        }        

        // GET: api/Node/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NodeViewModel>> GetNode(Guid id, bool populate = false)
        {
            var node = await _context.Nodes.FindAsync(id);

            if (node == null)
            {
                return NotFound();
            }

            if (populate) PopulateNode(node);

            return new NodeViewModel(node);
        }

        //GET: api/Node/5/Connections
        [HttpGet("{id}/Connections")]
        public async Task<ActionResult<IEnumerable<ConnectionViewModel>>> GetConnectionsForNode(Guid id)
        {
            var connections = await _context.Connections.Where(c => c.ParentId == id).ToListAsync();
            return connections.Select(c => new ConnectionViewModel(c)).ToList();
        }

        // PUT: api/Node/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNode(Guid id, NodeViewModel node)
        {
            var nts = node?.ToEntity();
            if (nts == null || id != node.Id)
            {
                return BadRequest();
            }

            _context.Entry(nts).State = EntityState.Modified;

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
        public async Task<ActionResult<Node>> PostNode(NodeViewModel node)
        {
            var nts = node?.ToEntity();
            _context.Nodes.Add(nts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNode", new { id = nts.Id }, nts);
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
        private IEnumerable<Node> PopulateNodes(List<Node> nodes)
        {
            return nodes.Select(n => PopulateNode(n)).ToList();
        }

        private Node PopulateNode(Node node)
        {
            if (node == null) return null;
            var connections = _context.Connections.ToList();
            return new Node()
            {
                Id = node.Id,
                UserId = node.UserId,
                Name = node.Name,
                ColourCode = node.ColourCode,
                Type = node.Type,
                Connections = connections.Where(c => c.ParentId.Equals(node.Id)).ToList()
            };
        }
    }
}
