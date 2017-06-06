namespace Tippspiel_Server.Sources.Validators.Helper
{
    public class ValidationError : IValidationMessage
    {
        public bool IsError { get; } = true;
        public string Message { get; set; } = "";

        public ValidationError(string message)
        {
            this.Message = message;
        }

    }
}