namespace Src.Core.Application.UseCase.Implementation.Auth;
using Src.Core.Application.UseCase.Contract.Auth;
using Src.Core.Ports;

public class GenerateRefreshTokenImpl:IGenerateRefreshTokenUseCase{
    
    public readonly IAuthPort _authPort;

    public GenerateRefreshTokenImpl(IAuthPort authPort){
        this._authPort=authPort;
    }

    public string Execute(string nameFull, string email, long id)
    {
        return this._authPort.generateRefreshToken(nameFull,email,id);
    }
}