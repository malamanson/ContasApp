using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("api/[controller]")]
public class TransacoesController : ControllerBase
{
    private readonly FinancasContext _context;

    public TransacoesController(FinancasContext context)
    {
        _context = context;
    }

    // 1. Listar todas as transações
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Transacao>>> GetTransacoes()
    {
        return await _context.Transacoes
            .Include(t => t.Conta) // Inclui os dados da Conta associada
            .ToListAsync();
    }

    // 2. Criar uma nova transação
    [HttpPost]
    public async Task<ActionResult<Transacao>> PostTransacao(Transacao transacao)
    {
        // Verifica se o ContaId é válido
        var conta = await _context.Contas.FindAsync(transacao.ContaId);
        if (conta == null)
        {
            return BadRequest(new { Error = "ContaId inválido." });
        }

        _context.Transacoes.Add(transacao);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTransacoes), new { id = transacao.Id }, transacao);
    }

    // 3. Obter transação por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Transacao>> GetTransacao(int id)
    {
        var transacao = await _context.Transacoes
            .Include(t => t.Conta) // Inclui os dados da Conta associada
            .FirstOrDefaultAsync(t => t.Id == id);

        if (transacao == null)
        {
            return NotFound();
        }

        return transacao;
    }

    // 4. Atualizar uma transação existente
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTransacao(int id, Transacao transacao)
    {
        if (id != transacao.Id)
        {
            return BadRequest();
        }

        // Verifica se o ContaId é válido
        var conta = await _context.Contas.FindAsync(transacao.ContaId);
        if (conta == null)
        {
            return BadRequest(new { Error = "ContaId inválido." });
        }

        _context.Entry(transacao).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TransacaoExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    // 5. Deletar uma transação
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransacao(int id)
    {
        var transacao = await _context.Transacoes.FindAsync(id);
        if (transacao == null)
        {
            return NotFound();
        }

        _context.Transacoes.Remove(transacao);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TransacaoExists(int id)
    {
        return _context.Transacoes.Any(t => t.Id == id);
    }
}
