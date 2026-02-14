namespace Src.Core.Ports;
public interface IValidatorEmailPort{
    bool EmailISyntaxIsValid(string email);
    bool ExistsUserWithEmailReceivedByRequest(string email);   
}