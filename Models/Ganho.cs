public class Ganho
{
    public int Id { get; set; }

    // Nome descritivo do ganho (ex.: Salário, Freelancer, Bônus)
    public string Nome { get; set; }

    // Valor do ganho
    public decimal Valor { get; set; }

    // Data de recebimento do ganho
    public DateTime Data { get; set; }

    // Relacionamento opcional (se ganhos pertencerem a uma conta específica)
    public int? ContaId { get; set; }
    public Conta? Conta { get; set; } // Propriedade de navegação
}

