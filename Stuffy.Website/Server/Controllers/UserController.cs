//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Stuffy.Website.Server.Data;
//using System.Security.Cryptography;
//using System.Text;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Stuffy.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UserController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;

//        public UserController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Users
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers()
//        {
//            var users = await _context.Users.ToListAsync();
//            return users?.Select(user => new UserViewModel(user)).ToList();
//        }

//        // GET: api/Users/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<UserViewModel>> GetUser(int id)
//        {
//            var users = await _context.Users.FindAsync(id);

//            if (users == null)
//            {
//                return NotFound();
//            }

//            return new UserViewModel(users);
//        }

//        // GET: api/Users/5/Nodes
//        [HttpGet("{id}/Nodes")]
//        public async Task<ActionResult<IEnumerable<NodeViewModel>>> GetNodesForUser(int id)
//        {
//            var nodes = _context.Nodes.Where(n => n.UserId == id).ToList();
//            return nodes.Select(n => new NodeViewModel(n)).ToList();
//        }

//        // PUT: api/Users/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutConnection(int id, UserUpdateModel user)
//        {
//            //VALIDATION AND ENCRYPTION
//            if (user == null || id != user.Id)
//            {
//                return BadRequest();
//            }

//            var sysUser = _context.Users.FindAsync(id);
//            var encryPass = "";
//            using(SHA256 a256 = SHA256.Create())
//            {
//                var bytes = Encoding.Default.GetBytes(user.CurrentPassword);
//                encryPass = Encoding.Default.GetString(a256.ComputeHash(bytes));
//            }

//            var dbPass = sysUser.Result.Password;

//            if(dbPass != encryPass) { return BadRequest(); }

//            var uts = user.ToEntity();
//            _context.Entry(uts).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!UserExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }
//        // POST: api/user
//        // To protect from overposting attacks, enable the specific properties you want to bind to, for
//        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
//        [HttpPost]
//        public async Task<ActionResult<UserViewModel>> PostConnection(UserUpdateModel user)
//        {
//            //VALIDATIONA AND ENCRYPTION
//            if (user == null || 0 != user.Id)
//            {
//                return BadRequest();
//            }
//            var uts = user?.ToEntity();

//            using (SHA256 a256 = SHA256.Create())
//            {
//                var bytes = Encoding.Default.GetBytes(uts.Password);
//                uts.Password = Encoding.Default.GetString(a256.ComputeHash(bytes));
//            }
//            _context.Users.Add(uts);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetUser", new { id = uts.Id });
//        }

//        // DELETE: api/Connection/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<ConnectionViewModel>> DeleteConnection(int id)
//        {
//            //VALIDATION AND ENCRPYITON
//            var connection = await _context.Connections.FindAsync(id);
//            if (connection == null)
//            {
//                return NotFound();
//            }

//            _context.Connections.Remove(connection);
//            await _context.SaveChangesAsync();

//            return new ConnectionViewModel(connection);
//        }

//        private bool UserExists(int id)
//        {
//            return _context.Users.Any(e => e.Id == id);
//        }
//    }
//}
