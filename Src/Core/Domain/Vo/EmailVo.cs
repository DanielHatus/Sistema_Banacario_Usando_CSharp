using Src.Core.Exceptions.DomainException;
using Src.Core.Port.ValidatorEmail.Port;

namespace Src.Core.Vo.EmailVo;
public class EmailVo{
    
    public string Email{get;}
    private readonly ValidatorEmailPort _validatorEmail;
    public EmailVo(ValidatorEmailPort validatorEmailPort,string? email,bool emailIsAfterValidate){
        this._validatorEmail=validatorEmailPort;

        if (!emailIsAfterValidate){
            this.Email=ValidateEmail(email);
            return ;
        }
       
        this.Email=email;
    }
    private string ValidateEmail(string email){

        if (string.IsNullOrWhiteSpace(email)){
            throw new DomainException("o email não pode ser nulo,vazio ou somente com espaços  em branco.",400);
        }

        if (!this._validatorEmail.EmailIsValid(email)){
            throw new DomainException("a sintaxe do email é inválida.",400);
        }
    
        return email;
    }
}