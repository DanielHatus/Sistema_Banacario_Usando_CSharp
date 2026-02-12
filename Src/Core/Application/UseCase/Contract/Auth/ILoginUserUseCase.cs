namespace Src.Core.Application.UseCase.Contract.Auth;
using Src.Core.Domain.Model;

public interface ILoginUserUseCase{
    UserDomain Execute(UserLoginRequestDto dto);
}