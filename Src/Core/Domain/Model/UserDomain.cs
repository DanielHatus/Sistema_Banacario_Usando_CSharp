namespace Src.Core.Domain.Model.UserDomain;

using Src.Core.Domain.Enums.Role;
using Src.Core.Domain.Vo.BankStatementVo;
using Src.Core.Domain.Vo.EmailVo;
using Src.Core.Domain.Vo.FullNameVo;
using Src.Core.Domain.Vo.PasswordPaymentVo;

public class UserDomain{
    protected UserDomain(){}
    public long Id{get;}
    public FullNameVo FullName{get;}
    public EmailVo Email{get;}
    public BankStatementVo BankStatement{get;}

    public PasswordPaymentVo PasswordPaymentVo{get;}

    public Role role{get;}

    public UserDomain(FullNameVo fullNameVo,EmailVo emailVo,PasswordPaymentVo passwordPaymentVo){
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

    public static UserDomain ReceivedEntityByDatabase(long id,FullNameVo fullNameVo,EmailVo emailVo,PasswordPaymentVo passwordPaymentVo,BankStatementVo bankStatementVo,Role role){
       return new UserDomain(id,fullNameVo,emailVo,passwordPaymentVo,bankStatementVo,role); 
    }
}