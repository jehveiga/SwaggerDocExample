namespace SwaggerDocExample.Models
{
    public class Aluno
    {
        public Aluno(string? ra, string primeiroNome, string sobrenome, string cpf, int idade, DateTime dataNascimento)
        {
            Id = Guid.NewGuid();
            Ra = ra;
            PrimeiroNome = primeiroNome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            Idade = idade;
            DataNascimento = dataNascimento;
        }

        public Guid Id { get; }

        public string? Ra { get; private set; }

        public string PrimeiroNome { get; private set; }

        public string Sobrenome { get; set; }

        public string Cpf { get; set; }

        public int Idade { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
