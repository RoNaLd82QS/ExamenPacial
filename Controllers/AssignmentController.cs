using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var asignaciones = _context.Assignments
                .Include(a => a.Player)
                .Include(a => a.Team)
                .ToList();
            return View(asignaciones);
        }

        public IActionResult Create()
        {
            ViewBag.Players = _context.Players.ToList();
            ViewBag.Teams = _context.Teams.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                _context.Assignments.Add(assignment);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Players = _context.Players.ToList();
            ViewBag.Teams = _context.Teams.ToList();
            return View(assignment);
        }
    }
}

