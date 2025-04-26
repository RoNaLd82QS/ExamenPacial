using Microsoft.AspNetCore.Mvc;
using EquiposPeruanos.Data;
using EquiposPeruanos.Models;
using Microsoft.EntityFrameworkCore;

namespace EquiposPeruanos.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var jugadores = _context.Players.ToList();

    var asignaciones = _context.Assignments
        .Include(a => a.Team) // <-- esto es CLAVE
        .ToList();

    ViewBag.Assignments = asignaciones;

    return View(jugadores);
        }


        // GET: /Player
    // GET: Player/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    if (id == null) return NotFound();

    var player = await _context.Players.FindAsync(id);
    if (player == null) return NotFound();

    return View(player);
}

// POST: Player/Edit/5
[HttpPost]
public async Task<IActionResult> Edit(Player player)
{
    if (ModelState.IsValid)
    {
        _context.Update(player);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(player);
}

// GET: Player/Delete/5
public async Task<IActionResult> Delete(int? id)
{
    if (id == null) return NotFound();

    var player = await _context.Players.FindAsync(id);
    if (player == null) return NotFound();

    return View(player);
}

// POST: Player/Delete/5
[HttpPost]
[HttpPost]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var player = await _context.Players.FindAsync(id);
    if (player == null)
    {
        return NotFound();
    }

    _context.Players.Remove(player);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}


}   
}
