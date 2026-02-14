namespace Src.Core.Application.UseCase.Contract.Crud;
using Src.Core.Domain.Model;

public interface IRegisterUserUseCase
{
     Task<UserDomain> Execute(UserRegisterRequestDto dto);
}