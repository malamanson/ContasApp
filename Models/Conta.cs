public class Conta
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public TipoConta Tipo { get; set; }
    public decimal SaldoInicial { get; set; } // Saldo inicial da conta

    public List<Transacao>? Transacoes { get; set; }
    public decimal SaldoAtual
    {
        get
        {
            return SaldoInicial + Transacoes.Where(t => t.IsEntrada).Sum(t => t.Valor) -
                   Transacoes.Where(t => !t.IsEntrada).Sum(t => t.Valor);
        }
    }
}

public enum TipoConta
{
    Fixa,
    Variavel
}
