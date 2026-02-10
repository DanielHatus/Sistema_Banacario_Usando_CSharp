namespace Src.Core.Domain.Vo.EmailVo;
using Src.Core.Exceptions.DomainException;
using Src.Core.Port.ValidatorEmail.Port;

public class EmailVo{
    public string Address{get;}
    public EmailVo(ValidatorEmailPort validatorEmailPort,string? email){
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

}