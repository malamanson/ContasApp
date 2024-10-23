using Microsoft.EntityFrameworkCore;

public class FinancasContext : DbContext
{
    public FinancasContext(DbContextOptions<FinancasContext> options) : base(options) { }

    public DbSet<Transacao> Transacoes { get; set; }
    public DbSet<Conta> Contas { get; set; }
}
