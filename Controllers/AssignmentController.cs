using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EquiposPeruanos.Data;
using EquiposPeruanos.Models;

namespace EquiposPeruanos.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssignmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Assignment
        public async Task<IActionResult> Index()
        {
            var assignments = await _context.Assignments
                .Include(a => a.Player)
                .Include(a => a.Team)
                .ToListAsync();
            return View(assignments);
        }

        // GET: Assignment/Create
        public IActionResult Create()
        {
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Nombre");
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Nombre");
            return View();
        }

        // POST: Assignment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlayerId"] = new SelectList(_context.Players, "Id", "Nombre", assignment.PlayerId);
            ViewData["TeamId"] = new SelectList(_context.Teams, "Id", "Nombre", assignment.TeamId);
            return View(assignment);
        }
    }
}
