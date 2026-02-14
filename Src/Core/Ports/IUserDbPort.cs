namespace Src.Core.Ports;
using Src.Core.Domain.Model;
public interface IUserDbPort{
    Task<UserDomain> RegisterUser(UserDomain userDomain);
    Task<UserDomain> GetUserById(long id);
    Task<UserDomain> UpdateUser(UserDomain actEntity,UserUpdateRequestDto dto);
    Task DeleteUserById(long id);

    UserDomain GetUserByEmailIfExists(string email);
}