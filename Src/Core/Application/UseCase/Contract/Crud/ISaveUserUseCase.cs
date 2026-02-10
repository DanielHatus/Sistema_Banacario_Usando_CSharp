namespace Src.Core.Application.UseCase.Crud.ISaveUserUseCase;
using Src.Core.Domain.Model.UserDomain;

public interface ISaveUserUseCase
{
     Task<UserDomain> Execute(UserRegisterRequestDto dto);
}