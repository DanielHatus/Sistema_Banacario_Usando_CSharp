namespace Src.Core.Domain.Model.User;
using Src.Core.Domain.Vo.BankStatementVo;
using Src.Core.Domain.Vo.EmailVo;
using Src.Core.Domain.Vo.FullNameVo;
public class User{
    protected User(){}
    public long Id{get;}
    public FullNameVo FullName{get;}
    public EmailVo Email{get;}
    public BankStatementVo BankStatement{get;}

    public User(FullNameVo fullNameVo,EmailVo emailVo,BankStatementVo bankStatementVo){
        this.FullName=fullNameVo;
        this.Email=emailVo;
        this.BankStatement=bankStatementVo;
    }

    public User(long id,FullNameVo fullNameVo,EmailVo emailVo,BankStatementVo bankStatementVo){
        this.Id=id;
        this.FullName=fullNameVo;
        this.Email=emailVo;
        this.BankStatement=bankStatementVo;
    }
}