
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MindCare.Models;
using MindCare.Data;

public class DiariosPessoaisController : Controller
{
    private readonly ApplicationDbContext _context;

    public DiariosPessoaisController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: DIARIOPESSOALS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.DiarioPessoal.ToListAsync());
    }

    // GET: DIARIOPESSOALS/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var diariopessoal = await _context.DiarioPessoal
            .FirstOrDefaultAsync(m => m.Id == id);
        if (diariopessoal == null)
        {
            return NotFound();
        }

        return View(diariopessoal);
    }

    // GET: DIARIOPESSOALS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DIARIOPESSOALS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,UsuarioId,Data,Entrada,Usuario")] DiarioPessoal diariopessoal)
    {
        if (ModelState.IsValid)
        {
            _context.Add(diariopessoal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(diariopessoal);
    }

    // GET: DIARIOPESSOALS/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var diariopessoal = await _context.DiarioPessoal.FindAsync(id);
        if (diariopessoal == null)
        {
            return NotFound();
        }
        return View(diariopessoal);
    }

    // POST: DIARIOPESSOALS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long? id, [Bind("Id,UsuarioId,Data,Entrada,Usuario")] DiarioPessoal diariopessoal)
    {
        if (id != diariopessoal.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(diariopessoal);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiarioPessoalExists(diariopessoal.Id))
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
        return View(diariopessoal);
    }

    // GET: DIARIOPESSOALS/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var diariopessoal = await _context.DiarioPessoal
            .FirstOrDefaultAsync(m => m.Id == id);
        if (diariopessoal == null)
        {
            return NotFound();
        }

        return View(diariopessoal);
    }

    // POST: DIARIOPESSOALS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        var diariopessoal = await _context.DiarioPessoal.FindAsync(id);
        if (diariopessoal != null)
        {
            _context.DiarioPessoal.Remove(diariopessoal);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DiarioPessoalExists(long? id)
    {
        return _context.DiarioPessoal.Any(e => e.Id == id);
    }
}
