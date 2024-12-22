using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class GanhoController : ControllerBase
{
    private readonly FinancasContext _context;

    public GanhoController(FinancasContext context)
    {
        _context = context;
    }

    // 1. Listar todos os ganhos
    [HttpGet]
    public async Task<IActionResult> GetGanhos()
    {
        var ganhos = await _context.Ganhos.ToListAsync();
        return Ok(ganhos);
    }

    // 2. Obter um ganho por ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetGanho(int id)
    {
        var ganho = await _context.Ganhos.FindAsync(id);
        if (ganho == null) return NotFound();

        return Ok(ganho);
    }

    // 3. Adicionar um novo ganho
    [HttpPost]
    public async Task<IActionResult> AddGanho([FromBody] Ganho ganho)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        _context.Ganhos.Add(ganho);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetGanho), new { id = ganho.Id }, ganho);
    }

    // 4. Editar um ganho existente
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGanho(int id, [FromBody] Ganho ganho)
    {
        if (id != ganho.Id) return BadRequest();
        if (!ModelState.IsValid) return BadRequest(ModelState);

        // Marca o objeto como modificado
        _context.Entry(ganho).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!GanhoExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    // 5. Deletar um ganho
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGanho(int id)
    {
        var ganho = await _context.Ganhos.FindAsync(id);
        if (ganho == null) return NotFound();

        _context.Ganhos.Remove(ganho);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // Verificar se um ganho existe
    private bool GanhoExists(int id)
    {
        return _context.Ganhos.Any(e => e.Id == id);
    }
}
