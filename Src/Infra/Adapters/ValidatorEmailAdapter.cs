namespace Src.Infra.Adapters;
using System.ComponentModel.DataAnnotations;
using Src.Core.Ports;
using Src.Infra.Persistence.Repository.Contract;

public class ValidatorEmailAdapter :  IValidatorEmailPort{

    public readonly IRepositoryUser _repositoryUser;

    public ValidatorEmailAdapter(IRepositoryUser repositoryUser){
        this._repositoryUser=repositoryUser;
    }
    public bool EmailISyntaxIsValid(string email){
         EmailAddressAttribute emailAddress=new EmailAddressAttribute();
        return emailAddress.IsValid(email);
    }

    public bool ExistsUserWithEmailReceivedByRequest(string email){
        return this._repositoryUser.ExistsUserWithEmail(email);
    }
}