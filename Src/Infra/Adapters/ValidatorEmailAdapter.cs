namespace Src.Infra.Adapters.ValidatorEmailAdapter;
using System.ComponentModel.DataAnnotations;
using Src.Core.Port.ValidatorEmail.Port;

public class ValidatorEmailAdapter : ValidatorEmailPort
{
    public bool EmailIsValid(string email){
        EmailAddressAttribute emailAddress=new EmailAddressAttribute();
        return emailAddress.IsValid(email);
    }
}