namespace SwaggerDocExample.Util
{
    public class ErrorResponse
    {
        /// <summary>
        /// Tipo de erro que foi gerado
        /// </summary>
        /// <example>Erro de validação</example>
        public string? Type { get; }

        /// <summary>
        /// Status code http
        /// </summary>
        /// <example>400</example>
        public int Status { get; }

        /// <summary>
        /// Descrição dos erros
        /// </summary>
        /// <example>Um ou mais erros de validação foram encontrados</example>
        public string? Title { get; }

        /// <summary>
        /// Dicionário de erros encontrados
        /// </summary>
        public IDictionary<string, string[]> Errors { get; }

        public ErrorResponse(string type, int status, string title, IDictionary<string, string[]> errors)
        {
            Type = type;
            Status = status;
            Title = title;
            Errors = errors;
        }
    }
}
