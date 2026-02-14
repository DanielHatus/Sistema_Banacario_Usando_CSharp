using Src.Core.Exceptions;

namespace Src.Core.Domain.Vo;
public class PasswordPaymentVo{
    public string Password{get;}
    private PasswordPaymentVo(string passwordHash){
        this.Password=passwordHash;
    }
    private static string ValidatePassword(string? password){
        if (string.IsNullOrWhiteSpace(password)){
            throw new DomainException("a senha não pode ser nula ou vazia.",400);
        }

        if (password.Length != 4){
            throw new DomainException("o password deve conter somente 4 carcateres.",400);
        }
        
        if (!int.TryParse(password,out _)){
            throw new DomainException("o password deve conter somente números.",400);
        }
        return password;
    }
   public static PasswordPaymentVo ReceivedPasswordByDatabase(string passwordHash){
        return new PasswordPaymentVo(passwordHash);
    } 
   public static PasswordPaymentVo CreatePasswordPaymentValid(IBCryptPort bCryptPort,string? password){
        string passwordValidated=ValidatePassword(password);
        string passwordHash=bCryptPort.HashPassword(passwordValidated);
        return new PasswordPaymentVo(passwordHash);
    } 
}