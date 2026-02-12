namespace Src.Core.Domain.Vo;
using Src.Core.Exceptions;
using Src.Core.Port;

public class EmailVo{
    public string Address{get;}
    private EmailVo(ValidatorEmailPort validatorEmailPort,string? email){
         this.Address=ValidateEmail(validatorEmailPort,email);
    }
    private EmailVo(string email){
        this.Address=email;
    }
    private string ValidateEmail(ValidatorEmailPort validatorEmail,string email){

        if (string.IsNullOrWhiteSpace(email)){
            throw new DomainException("o email não pode ser nulo,vazio ou somente com espaços  em branco.",400);
        }

        if (!validatorEmail.EmailIsValid(email)){
            throw new DomainException("a sintaxe do email é inválida.",400);
        }
        
        return email;
    }
    public static EmailVo ReceivedEmailByDatabase(string email){
        return new EmailVo(email);
    }

    public static EmailVo CreateEmailValid(ValidatorEmailPort validatorEmailPort,string email){
        return new EmailVo(validatorEmailPort,email);
    }
}