using Src.Core.Domain.Model;
using Src.Infra.Persistence.Model;

namespace Src.Infra.Persistence.Repository.Contract;
public interface IRepositoryUser{
    Task<UserPersist> RegisterUser(UserPersist userPersist);
    Task<UserPersist> GetUserById(long id);

    Task<UserPersist> UpdateUser(UserPersist actEntity,UserUpdateRequestDto dto);
    Task DeleteUserById(long id);

    bool ExistsUserWithEmail(string email);
    UserPersist GetUserByEmailIfExists(string email);
}