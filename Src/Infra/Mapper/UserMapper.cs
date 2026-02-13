using Src.Core.Domain.Model;
using Src.Core.Domain.Vo;
using Src.Infra.Persistence.Model;

namespace Src.Infra.Mapper;
public class UserMapper{
    
    public UserDomain ToDomain(UserPersist userPersist){
       return UserDomain.ReceivedEntityByDatabase(
        userPersist.Id,
        FullNameVo.ReceivedFullNameByDatabase(userPersist.FullName),
        EmailVo.ReceivedEmailByDatabase(userPersist.Email),
        PasswordPaymentVo.ReceivedPasswordByDatabase(userPersist.PasswordPayment),
        BankStatementVo.ReceivedBankStatementByDatabase(userPersist.BankStatement),
        userPersist.Role);
    }

    public UserPersist ToPersist(UserDomain userDomain){
        UserPersist userPersist=new UserPersist(){
           Id=userDomain.Id,
           FullName=userDomain.FullName.Value,
           Email=userDomain.Email.Address,
           BankStatement=userDomain.BankStatement.Statement,
           PasswordPayment=userDomain.PasswordPayment.Password,
           Role=userDomain.Role 
        };
        return userPersist;
    }
    
}