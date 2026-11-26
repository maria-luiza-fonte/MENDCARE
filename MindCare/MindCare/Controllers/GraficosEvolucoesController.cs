
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MindCare.Models;
using MindCare.Data;

public class GraficosEvolucoesController : Controller
{
    private readonly ApplicationDbContext _context;

    public GraficosEvolucoesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: GRAFICOSEVOLUCAOS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.GraficosEvolucao.ToListAsync());
    }

    // GET: GRAFICOSEVOLUCAOS/Details/5
    public async Task<IActionResult> Details(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var graficosevolucao = await _context.GraficosEvolucao
            .FirstOrDefaultAsync(m => m.Id == id);
        if (graficosevolucao == null)
        {
            return NotFound();
        }

        return View(graficosevolucao);
    }

    // GET: GRAFICOSEVOLUCAOS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: GRAFICOSEVOLUCAOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,UsuarioId,TipoGrafico,Dados,Usuario")] GraficosEvolucao graficosevolucao)
    {
        if (ModelState.IsValid)
        {
            _context.Add(graficosevolucao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(graficosevolucao);
    }

    // GET: GRAFICOSEVOLUCAOS/Edit/5
    public async Task<IActionResult> Edit(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var graficosevolucao = await _context.GraficosEvolucao.FindAsync(id);
        if (graficosevolucao == null)
        {
            return NotFound();
        }
        return View(graficosevolucao);
    }

    // POST: GRAFICOSEVOLUCAOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long? id, [Bind("Id,UsuarioId,TipoGrafico,Dados,Usuario")] GraficosEvolucao graficosevolucao)
    {
        if (id != graficosevolucao.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(graficosevolucao);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GraficosEvolucaoExists(graficosevolucao.Id))
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
        return View(graficosevolucao);
    }

    // GET: GRAFICOSEVOLUCAOS/Delete/5
    public async Task<IActionResult> Delete(long? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var graficosevolucao = await _context.GraficosEvolucao
            .FirstOrDefaultAsync(m => m.Id == id);
        if (graficosevolucao == null)
        {
            return NotFound();
        }

        return View(graficosevolucao);
    }

    // POST: GRAFICOSEVOLUCAOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(long? id)
    {
        var graficosevolucao = await _context.GraficosEvolucao.FindAsync(id);
        if (graficosevolucao != null)
        {
            _context.GraficosEvolucao.Remove(graficosevolucao);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool GraficosEvolucaoExists(long? id)
    {
        return _context.GraficosEvolucao.Any(e => e.Id == id);
    }
}
