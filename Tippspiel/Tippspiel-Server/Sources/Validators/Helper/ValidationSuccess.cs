namespace Tippspiel_Server.Sources.Validators.Helper
{
    public class ValidationSuccess : IValidationMessage
    {
        public bool IsError { get; } = false;
        public string Message { get; set; } = "";
    }
}