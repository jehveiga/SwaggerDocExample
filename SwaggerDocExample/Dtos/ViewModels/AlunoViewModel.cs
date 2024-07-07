namespace SwaggerDocExample.Dtos.ViewModels
{
    public class AlunoViewModel
    {
        public int Id { get; set; }
        public string? Ra { get; set; }

        public string PrimeiroNome { get; set; } = string.Empty;

        public string Sobrenome { get; set; } = string.Empty;

        public string Cpf { get; set; } = string.Empty;

        public int Idade { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
