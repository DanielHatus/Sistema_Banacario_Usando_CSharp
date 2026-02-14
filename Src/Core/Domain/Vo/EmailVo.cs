namespace Src.Core.Domain.Vo;
using Src.Core.Exceptions;
using Src.Core.Ports;

public class EmailVo{
    public string Address{get;}
    private EmailVo(string email){
         this.Address=email;
    }
   
    private static string ValidateEmail(IValidatorEmailPort validatorEmail,string email){

        if (string.IsNullOrWhiteSpace(email)){
            throw new DomainException("o email não pode ser nulo,vazio ou somente com espaços  em branco.",400);
        }

        if (!validatorEmail.EmailISyntaxIsValid(email)){
            throw new DomainException("a sintaxe do email é inválida.",400);
        }

        if (validatorEmail.ExistsUserWithEmailReceivedByRequest(email)){
            throw new DomainException("não se pode utilizar este email para cadastrar-se,pois ele já é cadastrado no servidor.",400);
        }

        return email;
    }
    public static EmailVo ReceivedEmailByDatabase(string email){
        return new EmailVo(email);
    }

    public static EmailVo CreateEmailValid(IValidatorEmailPort validatorEmailPort,string? email){
        string emailValidated=ValidateEmail(validatorEmailPort,email);
        return new EmailVo(emailValidated);
    }
}