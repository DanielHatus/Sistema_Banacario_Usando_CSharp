namespace Src.Core.Application.UseCase.Auth.IGenerateAccessTokenUseCase;
using Src.Core.Port.AuthPort;

public interface IGenerateAccessTokenUseCase{
    public string Execute(string nameFull,string email,long id);
}