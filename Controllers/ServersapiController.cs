using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using panel.Data;
using panel.Models;

namespace panel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersapiController : ControllerBase
    {
        private readonly ServerContext _context;

        public ServersapiController(ServerContext context)
        {
            _context = context;
        }

        // GET: api/Serversapi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Server>>> GetServer()
        {
          if (_context.Server == null)
          {
              return NotFound();
          }
            return await _context.Server.ToListAsync();
        }

        // GET: api/Serversapi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Server>> GetServer(int id)
        {
          if (_context.Server == null)
          {
              return NotFound();
          }
            var server = await _context.Server.FindAsync(id);

            if (server == null)
            {
                return NotFound();
            }

            return server;
        }

        // PUT: api/Serversapi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServer(int id, Server server)
        {
            if (id != server.Id)
            {
                return BadRequest();
            }

            _context.Entry(server).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServerExists(id))
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

        // POST: api/Serversapi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Server>> PostServer(Server server)
        {
          if (_context.Server == null)
          {
              return Problem("Entity set 'ServerContext.Server'  is null.");
          }
            _context.Server.Add(server);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServer", new { id = server.Id }, server);
        }

        // DELETE: api/Serversapi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServer(int id)
        {
            if (_context.Server == null)
            {
                return NotFound();
            }
            var server = await _context.Server.FindAsync(id);
            if (server == null)
            {
                return NotFound();
            }

            _context.Server.Remove(server);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServerExists(int id)
        {
            return (_context.Server?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
