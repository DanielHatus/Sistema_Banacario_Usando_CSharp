
using Src.Core.Application.UseCase.Contract.Auth;
using Src.Core.Application.UseCase.Implementation.Auth;
using Src.Core.Ports;
using Src.Infra.Adapters;

namespace Src.Infra.Config.ExtensionMethodsWebApplication;
public static  class ExtensionMethodsWebApplication{


public static void AddInstances(this WebApplicationBuilder builder){
     builder.Services.AddTransient<IValidatorEmailPort,ValidatorEmailAdapter>();

     builder.Services.AddTransient<IGenerateAccessTokenUseCase,GenerateAccessTokenImpl>();

     builder.Services.AddTransient<IGenerateRefreshTokenUseCase,GenerateRefreshTokenImpl>();

     builder.Services.AddTransient<IAuthPort,AuthAdapter>();

        
    }
    
}