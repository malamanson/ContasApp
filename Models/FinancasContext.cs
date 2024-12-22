using Microsoft.EntityFrameworkCore;

public class FinancasContext : DbContext
{
    public FinancasContext(DbContextOptions<FinancasContext> options) : base(options) { }

    public DbSet<Transacao> Transacoes { get; set; }
    public DbSet<Conta> Contas { get; set; }
    public DbSet<Ganho> Ganhos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuração de Conta
        modelBuilder.Entity<Conta>(entity =>
        {
            entity.HasKey(c => c.Id); // Define a chave primária
            entity.Property(c => c.Nome)
                  .IsRequired() // Campo obrigatório
                  .HasMaxLength(100); // Limite de caracteres
            entity.Property(c => c.Tipo)
                  .IsRequired(); // Enum obrigatório

            // Relacionamento: Conta possui muitas Transacoes
            entity.HasMany(c => c.Transacoes)
                  .WithOne()
                  .HasForeignKey(t => t.ContaId)
                  .OnDelete(DeleteBehavior.Cascade); // Exclui transações ao deletar uma conta
        });

        // Configuração de Transacao
        modelBuilder.Entity<Transacao>(entity =>
        {
            entity.HasKey(t => t.Id); // Define a chave primária
            entity.Property(t => t.Descricao)
                  .IsRequired() // Campo obrigatório
                  .HasMaxLength(200); // Limite de caracteres
            entity.Property(t => t.Valor)
                  .IsRequired(); // Campo obrigatório
            entity.Property(t => t.Data)
                  .IsRequired(); // Campo obrigatório
        });

        modelBuilder.Entity<Ganho>(entity =>
        {
            entity.HasKey(g => g.Id); // Define a chave primária
            entity.Property(g => g.Nome)
                  .IsRequired() // Campo obrigatório
                  .HasMaxLength(100); // Limite de caracteres
            entity.Property(g => g.Valor)
                  .IsRequired(); // Campo obrigatório
            entity.Property(g => g.Data)
                  .IsRequired(); // Campo obrigatório
        });

    }
}

