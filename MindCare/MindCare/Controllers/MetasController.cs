
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MindCare.Models;
using MindCare.Data;

public class MetasController : Controller
{
    private readonly ApplicationDbContext _context;

    public MetasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: METASS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Metas.ToListAsync());
    }

    // GET: METASS/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var metas = await _context.Metas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (metas == null)
        {
            return NotFound();
        }

        return View(metas);
    }

    // GET: METASS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: METASS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,UsuarioId,Descricao,DataInicio,DataFim,Status,Usuario")] Metas metas)
    {
        if (ModelState.IsValid)
        {
            _context.Add(metas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(metas);
    }

    // GET: METASS/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var metas = await _context.Metas.FindAsync(id);
        if (metas == null)
        {
            return NotFound();
        }
        return View(metas);
    }

    // POST: METASS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long? id, [Bind("Id,UsuarioId,Descricao,DataInicio,DataFim,Status,Usuario")] Metas metas)
    {
        if (id != metas.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(metas);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetasExists(metas.Id))
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
        return View(metas);
    }

    // GET: METASS/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var metas = await _context.Metas
            .FirstOrDefaultAsync(m => m.Id == id);
        if (metas == null)
        {
            return NotFound();
        }

        return View(metas);
    }

    // POST: METASS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        var metas = await _context.Metas.FindAsync(id);
        if (metas != null)
        {
            _context.Metas.Remove(metas);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MetasExists(long? id)
    {
        return _context.Metas.Any(e => e.Id == id);
    }
}
