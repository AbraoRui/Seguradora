namespace Seguradora.Dados.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string CPF { get; set; }
        public string? Email { get; set; }

    }
}
