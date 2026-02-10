namespace Src.Core.Application.UseCase.Auth.IGenerateRefreshTokenUseCase;
public interface IGenerateRefreshTokenUseCase{
    string Execute(string nameFull,string email,long id);
}