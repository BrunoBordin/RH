namespace RH.Validators.Exceptions
{
    public class ValidationExceptions : ExceptionBase
    {
        public List<string> MensagensDeErro { get; set; }

        public ValidationExceptions(List<string> mensagensDeErro) : base(string.Empty)
        {
            MensagensDeErro = mensagensDeErro;
        }
    }
}
