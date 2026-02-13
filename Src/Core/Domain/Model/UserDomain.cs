namespace Src.Core.Domain.Model;

using Src.Core.Domain.Enums;
using Src.Core.Domain.Vo;

public class UserDomain{
    protected UserDomain(){}
    public long? Id{get;}
    public FullNameVo FullName{get;}
    public EmailVo Email{get;}
    public BankStatementVo BankStatement{get;}

    public PasswordPaymentVo PasswordPayment{get;}
    public Role Role{get;}

    private UserDomain(long? id,FullNameVo fullNameVo,EmailVo emailVo,PasswordPaymentVo passwordPaymentVo,BankStatementVo bankStatementVo,Role role){
        this.Id=id;
        this.FullName=fullNameVo;
        this.Email=emailVo;
        this.PasswordPayment=passwordPaymentVo;
        this.BankStatement=bankStatementVo;
        this.Role=role;
    }


    public static UserDomain  CreateEntityUser(FullNameVo fullName,EmailVo email,PasswordPaymentVo passwordPayment) {
        return new UserDomain(
            null,
            fullName,
            email,
            passwordPayment,
            BankStatementVo.InitCreditsBonusFromCreateAccount(),
            Role.USER);
    }
    public static UserDomain ReceivedEntityByDatabase(long? id,FullNameVo fullNameVo,EmailVo emailVo,PasswordPaymentVo passwordPaymentVo,BankStatementVo bankStatementVo,Role role){
       return new UserDomain(id,fullNameVo,emailVo,passwordPaymentVo,bankStatementVo,role); 
    }
}