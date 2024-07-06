namespace SwaggerDocExample.Dtos.InputModel
{
    public class AlunoInputModel
    {
        /// <summary>
        /// Número do RA
        /// </summary>
        /// <example>A4138679</example>
        public string? Ra { get; set; }

        /// <summary>
        /// Primeiro nome do aluno
        /// </summary>
        /// <example>Bianca</example>
        public string PrimeiroNome { get; set; } = string.Empty;

        /// <summary>
        /// Sobrenome do aluno
        /// </summary>
        /// <example>Silva</example>
        public string Sobrenome { get; set; } = string.Empty;

        /// <summary>
        /// Número do CPF do aluno
        /// </summary>
        /// <example>31568198086</example>
        public string Cpf { get; set; } = string.Empty;

        /// <summary>
        /// Idade do aluno
        /// </summary>
        /// <example>18</example>
        public int Idade { get; set; }

        /// <summary>
        /// Data de nascimento
        /// </summary>
        /// <example>1/1/0001 12:00:00 AM</example>
        public DateTime DataNascimento { get; set; }
    }
}
