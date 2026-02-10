namespace Src.Core.Application.UseCase.GenerateRefreshTokenImpl;
using Src.Core.Application.UseCase.Auth.IGenerateRefreshTokenUseCase;
using Src.Core.Port.AuthPort;

public class GenerateRefreshTokenImpl:IGenerateRefreshTokenUseCase{
    
    public readonly AuthPort _authPort;

    public GenerateRefreshTokenImpl(AuthPort authPort){
        this._authPort=authPort;
    }

    public string Execute(string nameFull, string email, long id)
    {
        return this._authPort.generateRefreshToken(nameFull,email,id);
    }
}