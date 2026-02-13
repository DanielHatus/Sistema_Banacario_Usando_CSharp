using Src.Core.Domain.Model;
using Src.Core.Ports;
using Src.Infra.Db_Context;
using Src.Infra.Mapper;
using Src.Infra.Persistence.Model;
using Src.Infra.Persistence.Repository.Contract;

namespace Src.Infra.Adapters;

public class UserDbAdapter : IUserDbPort{
    public readonly IRepositoryUser _iRepositoryUser;
    public readonly UserMapper _userMapper;

    public UserDbAdapter(IRepositoryUser iRepositoryUser,UserMapper userMapper){
        this._iRepositoryUser=iRepositoryUser;
        this._userMapper=userMapper;
    }
    public Task DeleteUserById(long id){
        return this._iRepositoryUser.DeleteUserById(id);
    }

    public async Task<UserDomain> GetUserById(long id){
        UserDomain entityConverted=this._userMapper.ToDomain(
            await this._iRepositoryUser.GetUserById(id));
        return entityConverted;    
    }

    public async Task<UserDomain> RegisterUser(UserDomain userDomain)
    {
       UserPersist entityConvertedFromPersist=this._userMapper.ToPersist(userDomain);
       UserDomain entitySavedConvertedFromDomain=this._userMapper.ToDomain(
        await this._iRepositoryUser.RegisterUser(entityConvertedFromPersist)
       );
       return entitySavedConvertedFromDomain;
    }

    public async Task<UserDomain> UpdateUser(UserDomain actEntity, UserUpdateRequestDto dto){
        UserPersist entityConvertedFromPersist=this._userMapper.ToPersist(actEntity);
        UserDomain entityUpdatedConvertedFromDomain=this._userMapper.ToDomain(
            await this._iRepositoryUser.UpdateUser(entityConvertedFromPersist,dto));
        return entityUpdatedConvertedFromDomain;    
    }
}