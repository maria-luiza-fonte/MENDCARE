
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MindCare.Models;
using MindCare.Data;

public class CheckinHumorsController : Controller
{
    private readonly ApplicationDbContext _context;

    public CheckinHumorsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: CHECKINHUMORS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.CheckinHumor.ToListAsync());
    }

    // GET: CHECKINHUMORS/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var checkinhumor = await _context.CheckinHumor
            .FirstOrDefaultAsync(m => m.Id == id);
        if (checkinhumor == null)
        {
            return NotFound();
        }

        return View(checkinhumor);
    }

    // GET: CHECKINHUMORS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CHECKINHUMORS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,UsuarioId,Data,Humor,Comentario,Usuario")] CheckinHumor checkinhumor)
    {
        if (ModelState.IsValid)
        {
            _context.Add(checkinhumor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(checkinhumor);
    }

    // GET: CHECKINHUMORS/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var checkinhumor = await _context.CheckinHumor.FindAsync(id);
        if (checkinhumor == null)
        {
            return NotFound();
        }
        return View(checkinhumor);
    }

    // POST: CHECKINHUMORS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long? id, [Bind("Id,UsuarioId,Data,Humor,Comentario,Usuario")] CheckinHumor checkinhumor)
    {
        if (id != checkinhumor.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(checkinhumor);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheckinHumorExists(checkinhumor.Id))
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
        return View(checkinhumor);
    }

    // GET: CHECKINHUMORS/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var checkinhumor = await _context.CheckinHumor
            .FirstOrDefaultAsync(m => m.Id == id);
        if (checkinhumor == null)
        {
            return NotFound();
        }

        return View(checkinhumor);
    }

    // POST: CHECKINHUMORS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        var checkinhumor = await _context.CheckinHumor.FindAsync(id);
        if (checkinhumor != null)
        {
            _context.CheckinHumor.Remove(checkinhumor);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CheckinHumorExists(long? id)
    {
        return _context.CheckinHumor.Any(e => e.Id == id);
    }
}
