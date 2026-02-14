using Src.Core.Application.UseCase.Contract.Auth;
using Src.Core.Domain.Model;
using Src.Core.Exceptions;
using Src.Core.Ports;

public class LoginUserUseCaseImpl : ILoginUserUseCase{
    
    public readonly IBCryptPort _bCryptPort;
    public readonly IUserDbPort _userDbPort;

    public LoginUserUseCaseImpl(IBCryptPort bCryptPort,IUserDbPort userDbPort){
        this._bCryptPort=bCryptPort;
        this._userDbPort=userDbPort;
    }
    
    public UserDomain Execute(UserLoginRequestDto dto){
        UserDomain possibleEntity=_userDbPort.GetUserByEmailIfExists(dto.Email);
        
        if(!_bCryptPort.PasswordsIsMatch(dto.Password, possibleEntity.PasswordPayment.Password)){
            throw new DomainException("credenciais inválidas.",400);
        }

        return possibleEntity;
    }
}