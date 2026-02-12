namespace Src.Core.Application.UseCase.Contract.Crud;
using Src.Core.Domain.Model;

public interface ISaveUserUseCase
{
     Task<UserDomain> Execute(UserRegisterRequestDto dto);
}