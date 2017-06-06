namespace Tippspiel_Server.Sources.Validators.Helper
{
    public interface IValidationMessage
    {
        bool IsError { get; }
        string Message { get; set; }
    }
}