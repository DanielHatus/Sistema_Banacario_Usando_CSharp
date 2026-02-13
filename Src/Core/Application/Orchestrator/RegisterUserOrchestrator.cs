using Src.Core.Application.UseCase.Contract.Auth;
using Src.Core.Domain.Model;
using Src.Core.Application.UseCase.Contract.Crud;

namespace Src.Core.Application.Orchestrator.RegisterUserOrchestrator;
public class RegisterUserOrchestrator{
    
    private readonly IGenerateAccessTokenUseCase _generateAccessToken;
    private readonly IGenerateRefreshTokenUseCase _generateRefreshToken;

    private readonly ISaveUserUseCase _saveUser;

    public async Task<TokensResponseDto> Execute(UserRegisterRequestDto dto){
        UserDomain entitySaved=await this._saveUser.Execute(dto);

        string accessToken=this._generateAccessToken.Execute(
            entitySaved.FullName.Value,
            entitySaved.Email.Address,
            entitySaved.Id);

        string refreshToken=this._generateRefreshToken.Execute(
            entitySaved.FullName.Value,
            entitySaved.Email.Address,
            entitySaved.Id);

        return new TokensResponseDto(accessToken,refreshToken);              
    }
}