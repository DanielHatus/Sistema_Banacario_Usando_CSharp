namespace Src.Core.Application.UseCase.Contract.Auth;


public interface IGenerateAccessTokenUseCase{
    public string Execute(string nameFull,string email,long? id);
}