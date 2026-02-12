using Src.Core.Exceptions;

namespace Src.Core.Domain.Vo;
public class PasswordPaymentVo{
    
    public string Password{get;}

    private PasswordPaymentVo(string password){
        this.Password=ValidatePassword(password);
    }

    private string ValidatePassword(string password){
        if (string.IsNullOrWhiteSpace(password)){
            throw new DomainException("a senha não pode ser nula ou vazia.",400);
        }

        if (password.Length != 4){
            throw new DomainException("o password deve conter somente 4 carcateres.",400);
        }
        
        if (int.TryParse(password,out _)){
            throw new DomainException("o password deve conter somente números.",400);
        }
        return password;
    }

   private PasswordPaymentVo(string password,bool dataReceivedFromDatabase){
        if (!dataReceivedFromDatabase){
            throw new DomainException("não se pode passar dados que não venham banco neste método. afinal ele só recebe dados já validados anteriormente.",500);
        }
        this.Password=password;
    }
    
   public static PasswordPaymentVo ReceivedPasswordByDatabase(string password,bool dataReceivedFromDatabase){
        return new PasswordPaymentVo(password,dataReceivedFromDatabase);
    } 
    
   public static PasswordPaymentVo CreatePasswordPaymentValid(string email){
        return new PasswordPaymentVo(email);
    } 
}