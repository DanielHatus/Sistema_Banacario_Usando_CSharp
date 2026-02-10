namespace Src.Core.Application.UseCase.GenerateAccessTokenImpl;
using Src.Core.Port.AuthPort;
using Src.Core.Application.UseCase.Auth.IGenerateAccessTokenUseCase;

public class GenerateAccessTokenImpl : IGenerateAccessTokenUseCase{
    
    public readonly AuthPort _authPort;

    public GenerateAccessTokenImpl(AuthPort authPort){
        this._authPort=authPort;
    }
    public string Execute(string nameFull, string email, long id){
        return this._authPort.generateAccessToken(nameFull,email,id);
    }
}