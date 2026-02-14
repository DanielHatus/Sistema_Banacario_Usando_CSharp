using Microsoft.AspNetCore.Mvc;
using Src.Core.Application.Orchestrator;
namespace Src.Web.Controller.AuthController;
[ApiController]
[Route("api/auth")]
public class AuthController:ControllerBase{

    private readonly RegisterUserOrchestrator _registerUserOrchestrator;

    private readonly LoginUserOrchestrator _loginUserOrcestrator;

    public AuthController(
        RegisterUserOrchestrator registerUserOrchestrator,
        LoginUserOrchestrator loginUserOrchestrator){
        
        _registerUserOrchestrator=registerUserOrchestrator;
        _loginUserOrcestrator=loginUserOrchestrator;
    }

    [HttpPost("register")]
    public async Task<TokensResponseDto> RegisterUser([FromBody] UserRegisterRequestDto dto){
        var sla= await _registerUserOrchestrator.Execute(dto);
        System.Console.WriteLine(sla.AccessToken);
        return sla;
    }

    [HttpPost("login")]
    public TokensResponseDto LoginUser([FromBody] UserLoginRequestDto dto){
       return _loginUserOrcestrator.Execute(dto); 
    }     
}