using Src.Infra.Persistence.Model;

namespace Src.Infra.Persistence.Repository.Contract;
public interface IRepositoryUser{
    Task<UserPersist> RegisterUser(UserPersist userPersist);
    Task<UserPersist> GetUserById(long id);

    Task<UserPersist> UpdateUser(UserPersist actEntity,UserUpdateRequestDto dto);
    Task DeleteUserById(long id);
}