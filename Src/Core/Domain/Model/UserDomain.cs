namespace Src.Core.Domain.Model;

using Src.Core.Domain.Enums;
using Src.Core.Domain.Vo;

public class UserDomain{
    protected UserDomain(){}
    public long Id{get;}
    public FullNameVo FullName{get;}
    public EmailVo Email{get;}
    public BankStatementVo BankStatement{get;}

    public PasswordPaymentVo PasswordPaymentVo{get;}

    public Role role{get;}

    private UserDomain(FullNameVo fullNameVo,EmailVo emailVo,PasswordPaymentVo passwordPaymentVo){
        this.FullName=fullNameVo;
        this.Email=emailVo;
        this.PasswordPaymentVo=passwordPaymentVo;
        this.BankStatement=BankStatementVo.InitCreditsBonusFromCreateAccount();
        this.role=Role.USER;
    }

    private UserDomain(long id,FullNameVo fullNameVo,EmailVo emailVo,PasswordPaymentVo passwordPaymentVo,BankStatementVo bankStatementVo,Role role){
        this.Id=id;
        this.FullName=fullNameVo;
        this.Email=emailVo;
        this.PasswordPaymentVo=passwordPaymentVo;
        this.BankStatement=bankStatementVo;
        this.role=role;
    }


    public static UserDomain  CreateEntityUser(FullNameVo fullName,EmailVo email,PasswordPaymentVo passwordPayment) {
        return new UserDomain(fullName,email,passwordPayment);
    }
    public static UserDomain ReceivedEntityByDatabase(long id,FullNameVo fullNameVo,EmailVo emailVo,PasswordPaymentVo passwordPaymentVo,BankStatementVo bankStatementVo,Role role){
       return new UserDomain(id,fullNameVo,emailVo,passwordPaymentVo,bankStatementVo,role); 
    }
}