using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using panel.Data;
using panel.Models;
using Microsoft.AspNetCore.SignalR.Client; 
namespace panel.Controllers
{
    public class NodesController : Controller
    {
        HubConnection server;
        private readonly NodeContext _context;

        public NodesController(NodeContext context)
        {
            _context = context;
        }

        // GET: Nodes
        public async Task<IActionResult> Index()
        {

              return _context.Node != null ? 
                          View(await _context.Node.ToListAsync()) :
                          Problem("Entity set 'NodeContext.Node'  is null.");
        }

        // GET: Nodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            server = new HubConnectionBuilder()
            .WithUrl("localhost:7062/Nodes/" + id)
            .Build();
            if (id == null || _context.Node == null)
            {
                return NotFound();
            }

            var node = await _context.Node
                .FirstOrDefaultAsync(m => m.Id == id);
            if (node == null)
            {
                return NotFound();
            }

            return View(node);
        }

        // GET: Nodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ip,memory")] Node node)
        {
            if (ModelState.IsValid)
            {
                Random ran2 = new Random();
                int ran1 = ran2.Next(16);
                node.key = ran1;
                _context.Add(node);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(node);
        }

        // GET: Nodes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Node == null)
            {
                return NotFound();
            }

            var node = await _context.Node.FindAsync(id);
            if (node == null)
            {
                return NotFound();
            }
            return View(node);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ip,memory")] Node node)
        {
            if (id != node.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(node);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NodeExists(node.Id))
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
            return View(node);
        }

        // GET: Nodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Node == null)
            {
                return NotFound();
            }

            var node = await _context.Node
                .FirstOrDefaultAsync(m => m.Id == id);
            if (node == null)
            {
                return NotFound();
            }

            return View(node);
        }

        // POST: Nodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Node == null)
            {
                return Problem("Entity set 'NodeContext.Node'  is null.");
            }
            var node = await _context.Node.FindAsync(id);
            if (node != null)
            {
                _context.Node.Remove(node);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NodeExists(int id)
        {
          return (_context.Node?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
