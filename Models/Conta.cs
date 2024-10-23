public class Conta
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public TipoConta Tipo { get; set; }

    public List<Transacao> Transacoes { get; set; }
}

public enum TipoConta
{
    Fixa,
    Variavel
}