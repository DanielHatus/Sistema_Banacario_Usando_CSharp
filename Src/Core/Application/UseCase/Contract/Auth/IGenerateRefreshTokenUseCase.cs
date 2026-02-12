namespace Src.Core.Application.UseCase.Contract.Auth;
public interface IGenerateRefreshTokenUseCase{
    string Execute(string nameFull,string email,long id);
}