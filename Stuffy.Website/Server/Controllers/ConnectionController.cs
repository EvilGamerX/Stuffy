using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stuffy.Website.Server.Data;
using Stuffy.Website.Shared.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stuffy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConnectionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ConnectionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Connection
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConnectionViewModel>>> GetConnection()
        {
            var connections = await _context.Connections.ToListAsync();
            var nodes = await _context.Nodes.ToListAsync();
            
            return connections?.Select(connection => {
                connection.OtherNode = nodes.SingleOrDefault(x => x.Id == connection.OtherNodeId);
                connection.OtherNode.Connections = new List<Stuffy.Website.Shared.Entities.Connection>();
                var parentNode = nodes.SingleOrDefault(x => x.Id == connection.ParentId);
                parentNode.Connections = new List<Stuffy.Website.Shared.Entities.Connection>();
                var parentVM = new NodeViewModel(parentNode);
                return new ConnectionViewModel(connection)
                {
                    Parent = parentVM
                };
            }).ToList();
        }

        // GET: api/Connection/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ConnectionViewModel>> GetConnection(Guid id)
        {
            var connection = await _context.Connections.FindAsync(id);

            if (connection == null)
            {
                return NotFound();
            }

            return new ConnectionViewModel(connection);
        }

        // PUT: api/Connection/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConnection(Guid id, ConnectionViewModel connection)
        {
            var cts = connection?.ToEntity();
            if (cts == null || id != connection.Id)
            {
                return BadRequest();
            }

            _context.Entry(cts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConnectionExists(id))
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
        // POST: api/Connection
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ConnectionViewModel>> PostConnection(ConnectionViewModel connection)
        {
            if (connection == null || connection.Id != Guid.Empty)
            {
                return BadRequest();
            }
            var cts = connection?.ToEntity();
            cts.Id = Guid.NewGuid();
            var otno = await _context.Nodes.FindAsync(cts.OtherNode.Id);
            cts.OtherNode = otno;
            _context.Connections.Add(cts);

            //var bandit = await _context.Nodes.FindAsync(cts.ParentId);
            //bandit.Connections.Add(cts);
            //_context.Entry(bandit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetConnection", new { id = cts.Id }, cts);
            }
            catch (Exception ex)
            {
                return StatusCode(403);
            }

            
        }

        // DELETE: api/Connection/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ConnectionViewModel>> DeleteConnection(Guid id)
        {
            var connection = await _context.Connections.FindAsync(id);
            if (connection == null)
            {
                return NotFound();
            }

            _context.Connections.Remove(connection);
            await _context.SaveChangesAsync();

            return new ConnectionViewModel(connection);
        }

        private bool ConnectionExists(Guid id)
        {
            return _context.Connections.Any(e => e.Id == id);
        }
    }
}
