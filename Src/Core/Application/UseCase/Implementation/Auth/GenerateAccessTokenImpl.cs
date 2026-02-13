namespace Src.Core.Application.UseCase.Implementation.Auth; 
using Src.Core.Application.UseCase.Contract.Auth;
using Src.Core.Ports;

public class GenerateAccessTokenImpl : IGenerateAccessTokenUseCase
{

    public readonly IAuthPort  _authPort;

    public GenerateAccessTokenImpl(IAuthPort authPort){
        this._authPort=authPort;
    }
    
    public string Execute(string nameFull, string email, long? id){
       return this._authPort.GenerateAccessToken(nameFull,email,id);
    }
}