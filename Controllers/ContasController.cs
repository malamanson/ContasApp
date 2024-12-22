using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ContasController : ControllerBase
{
    private readonly FinancasContext _context;

    public ContasController(FinancasContext context)
    {
        _context = context;
    }

    // GET: api/Contas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Conta>>> GetContas()
    {
        return await _context.Contas
            .Include(c => c.Transacoes) // Inclui transações relacionadas
            .ToListAsync();
    }

    // GET: api/Contas/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Conta>> GetConta(int id)
    {
        var conta = await _context.Contas
            .Include(c => c.Transacoes)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (conta == null)
        {
            return NotFound();
        }

        return conta;
    }

    // POST: api/Contas
    [HttpPost]
    public async Task<ActionResult<Conta>> CreateConta([FromBody] Conta conta)
    {
        if (conta == null)
        {
            return BadRequest("A conta não pode ser nula.");
        }

        _context.Contas.Add(conta);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetConta), new { id = conta.Id }, conta);
    }

    // PUT: api/Contas/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateConta(int id, [FromBody] Conta contaAtualizada)
    {
        if (id != contaAtualizada.Id)
        {
            return BadRequest("ID da conta não corresponde ao ID fornecido.");
        }

        var contaExistente = await _context.Contas.FindAsync(id);
        if (contaExistente == null)
        {
            return NotFound("Conta não encontrada.");
        }

        contaExistente.Nome = contaAtualizada.Nome;
        contaExistente.Tipo = contaAtualizada.Tipo;

        _context.Entry(contaExistente).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Contas/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConta(int id)
    {
        var conta = await _context.Contas
            .Include(c => c.Transacoes) // Inclui transações relacionadas para exclusão em cascata
            .FirstOrDefaultAsync(c => c.Id == id);

        if (conta == null)
        {
            return NotFound("Conta não encontrada.");
        }

        _context.Contas.Remove(conta);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
