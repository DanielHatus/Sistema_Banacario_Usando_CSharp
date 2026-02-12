namespace Src.Infra.Adapters;
using System.ComponentModel.DataAnnotations;
using Src.Core.Ports;

public class ValidatorEmailAdapter :  IValidatorEmailPort
{
    public bool EmailIsValid(string email){
        EmailAddressAttribute emailAddress=new EmailAddressAttribute();
        return emailAddress.IsValid(email);
    }
}