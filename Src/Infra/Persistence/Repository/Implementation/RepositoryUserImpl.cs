namespace Src.Infra.Persistence.Repository.Implementation;

using Microsoft.EntityFrameworkCore;
using Src.Core.Domain.Model;
using Src.Infra.Db_Context;
using Src.Infra.Persistence.Model;
using Src.Infra.Persistence.Repository.Contract;

public class RepositoryUserImpl : IRepositoryUser
{

    public readonly AppDbContext _appDbContext;
    public RepositoryUserImpl(AppDbContext appDbContext){
        this._appDbContext=appDbContext;
    }

    public async Task DeleteUserById(long id){
         UserPersist? possibleEntity=await GetUserById(id);
         this._appDbContext.Users.Remove(possibleEntity);
         await this._appDbContext.SaveChangesAsync();   
    }

    public  bool ExistsUserWithEmail(string email){
       return this._appDbContext.Users.Any(u=>u.Email==email);
    }

    public UserPersist GetUserByEmailIfExists(string email){
        UserPersist? possibleEntity=_appDbContext.Users.FirstOrDefault(u=>u.Email==email);

        if (possibleEntity == null){
            throw new UserByEmailNotFound($"usuário não encontrado com o email {email} .",404);
        }
        
        return possibleEntity;
    }

    public async Task<UserPersist> GetUserById(long id){
        UserPersist? possibleEntity=await this._appDbContext.Users.FindAsync(id);
        if(possibleEntity==null){throw new UserByIdNotFound($"usuário não encontrado com o id {id} .",404);}
        return possibleEntity;
    }

    public async Task<UserPersist> RegisterUser(UserPersist userPersist)
    {
       await this._appDbContext.Users.AddAsync(userPersist);
       await this._appDbContext.SaveChangesAsync();
       return userPersist; 
    }

    public async Task<UserPersist> UpdateUser(UserPersist actEntity, UserUpdateRequestDto dto){
        this._appDbContext.Entry(actEntity).CurrentValues.SetValues(dto);
        await this._appDbContext.SaveChangesAsync(); 
        return actEntity;
    }


    
}