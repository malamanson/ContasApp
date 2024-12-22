public class Transacao
{
    public int Id { get; set; }
    public int ContaId { get; set; } // Identificador da Conta associada
    public virtual Conta? Conta { get; set; } // Propriedade virtual para carregamento preguiçoso
    public decimal Valor { get; set; }
    public bool IsEntrada { get; set; } // true para entrada, false para saída
    public string? Descricao { get; set; }
    public DateTime Data { get; set; }
}
