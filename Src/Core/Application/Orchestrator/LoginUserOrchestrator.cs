using Src.Core.Application.UseCase.Contract.Auth;
using Src.Core.Domain.Model;

namespace Src.Core.Application.Orchestrator;
public class LoginUserOrchestrator{
    public readonly ILoginUserUseCase _loginUser;
    public readonly IGenerateAccessTokenUseCase _generateAccessToken;
    public readonly IGenerateRefreshTokenUseCase _generateRefreshToken;


     public LoginUserOrchestrator(
        IGenerateAccessTokenUseCase generateAccessToken,
        IGenerateRefreshTokenUseCase generateRefreshToken,
        ILoginUserUseCase loginUser){
        _generateAccessToken=generateAccessToken;
        _generateRefreshToken=generateRefreshToken;
        _loginUser=loginUser;
    }
    public TokensResponseDto Execute(UserLoginRequestDto dto){
        UserDomain dataEntityAfterLogin=_loginUser.Execute(dto);
        
        string accessTokenGenerated=_generateAccessToken.Execute(
            dataEntityAfterLogin.FullName.Value,
            dataEntityAfterLogin.Email.Address,
            dataEntityAfterLogin.Id
        );

        string refreshTokenGenerated=_generateRefreshToken.Execute(
            dataEntityAfterLogin.FullName.Value,
            dataEntityAfterLogin.Email.Address,
            dataEntityAfterLogin.Id
        );

        return new TokensResponseDto(accessTokenGenerated,refreshTokenGenerated);
    }
}