using Src.Core.Domain.Model.UserDomain;

namespace Src.Core.Application.UseCase.Auth.ILoginUserUseCase;
public interface ILoginUserUseCase{
    UserDomain Execute(UserLoginRequestDto dto);
}