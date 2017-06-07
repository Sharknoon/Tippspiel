using System.Runtime.Serialization;
using System.ServiceModel;

namespace Tippspiel_Server.Sources.Validators.Helper
{
    [ServiceContract]
    public interface IValidationMessage
    {
        [DataMember]
        bool IsError { get; }
        [DataMember]
        string Message { get; set; }
    }
}