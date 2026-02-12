namespace Src.Core.Ports;
using Src.Core.Domain.Model;
public interface UserDbPort{
    Task<UserDomain> SaveUser(UserDomain userDomain);
    Task<UserDomain> GetUserById(long id);
    Task<UserDomain> UpdateUser(UserDomain actEntity,UserRegisterRequestDto dto);
    Task DeleteUserById(long id); 
}