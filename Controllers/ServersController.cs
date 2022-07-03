using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using panel.Data;
using panel.Models;
using Microsoft.AspNetCore.Identity;
namespace panel.Controllers
{
    public class ServersController : Controller
    {
        private readonly ServerContext _context;
        private readonly UserManager<IdentityUser> _identity;
        public ServersController(ServerContext context, UserManager<IdentityUser> identity)
        {
            _identity = identity;
            _context = context;
        }

        // GET: Servers
        public async Task<IActionResult> Index()
        {
              return _context.Server != null ? 
                          View(await _context.Server.ToListAsync()) :
                          Problem("Entity set 'ServerContext.Server'  is null.");
        }

        // GET: Servers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Server == null)
            {
                return NotFound();
            }

            var server = await _context.Server
                .FirstOrDefaultAsync(m => m.Id == id);
            if (server == null)
            {
                return NotFound();
            }

            return View(server);
        }

        // GET: Servers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Servers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,email,ip,ContainerId,Port,Setup,Image,cpu,memory,Disk")] Server server)
        {
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                int ftppass = rnd.Next(12);
                var user = await _identity.GetUserAsync(User);
                var users = user.UserName;
                server.ftpuser = users;
                server.ftppassword = ftppass;
                _context.Add(server);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(server);
        }

        // GET: Servers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Server == null)
            {
                return NotFound();
            }

            var server = await _context.Server.FindAsync(id);
            if (server == null)
            {
                return NotFound();
            }
            return View(server);
        }

        // POST: Servers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,email,ip,ContainerId,Port,Setup,Image,cpu,memory,Disk")] Server server)
        {
            if (id != server.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(server);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServerExists(server.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(server);
        }

        // GET: Servers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Server == null)
            {
                return NotFound();
            }

            var server = await _context.Server
                .FirstOrDefaultAsync(m => m.Id == id);
            if (server == null)
            {
                return NotFound();
            }

            return View(server);
        }

        // POST: Servers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Server == null)
            {
                return Problem("Entity set 'ServerContext.Server'  is null.");
            }
            var server = await _context.Server.FindAsync(id);
            if (server != null)
            {
                _context.Server.Remove(server);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServerExists(int id)
        {
          return (_context.Server?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> ftpuser(int? id)
        {
            if (id == null || _context.Server == null)
            {
                NotFound();
            }
            var server = await _context.Server.FirstOrDefaultAsync(m => m.Id == id);
            return View();
        }
    }
}
