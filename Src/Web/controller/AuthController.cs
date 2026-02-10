using Microsoft.AspNetCore.Mvc;
using Src.Core.Application.Orchestrator.RegisterUserOrchestrator;
namespace Src.Web.Controller.AuthController;
[ApiController]
[Route("api/auth")]
public class AuthController:ControllerBase{

    private readonly RegisterUserOrchestrator _registerUserOrchestrator;

    public AuthController(RegisterUserOrchestrator registerUserOrchestrator)
    {
        this._registerUserOrchestrator=registerUserOrchestrator;
    }

    [HttpPost]
    public Task<TokensResponseDto> RegisterUser([FromBody] UserRegisterRequestDto dto){
        return this._registerUserOrchestrator.Execute(dto);
    }
    
}