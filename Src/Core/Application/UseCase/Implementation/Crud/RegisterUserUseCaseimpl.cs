using Src.Core.Application.UseCase.Contract.Crud;
using Src.Core.Domain.Model;
using Src.Core.Domain.Vo;
using Src.Core.Ports;

public class RegisterUserUseCaseImpl : IRegisterUserUseCase{

    public readonly IValidatorEmailPort _validatorEmailPort;
    public readonly IBCryptPort _bCryptPort;

    public readonly IUserDbPort _userDbPort;

    public RegisterUserUseCaseImpl(
        IValidatorEmailPort validatorEmailPort, 
        IBCryptPort bCryptPort, 
        IUserDbPort userDbPort){
            
        _validatorEmailPort = validatorEmailPort;
        _bCryptPort = bCryptPort;
        _userDbPort = userDbPort;
    } 
    public async Task<UserDomain> Execute(UserRegisterRequestDto dto){
        UserDomain entityCreated=UserDomain.CreateEntityUser(
            FullNameVo.CreateFullName(dto.FirstName,dto.LastName),
            EmailVo.CreateEmailValid(_validatorEmailPort,dto.Email),
            PasswordPaymentVo.CreatePasswordPaymentValid(_bCryptPort,dto.Password)
        );
        return await this._userDbPort.RegisterUser(entityCreated);
    }
}