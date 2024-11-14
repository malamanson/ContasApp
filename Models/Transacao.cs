public class Transacao
{
    public int Id { get; set; }
    public decimal Valor { get; set; }
    public DateTime Data { get; set; }
    public string Descricao { get; set; }
    public bool IsEntrada { get; set; }

    public int ContaId { get; set; }
    public Conta? Conta { get; set; }
}
