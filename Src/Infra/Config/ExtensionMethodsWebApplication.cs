
using Src.Core.Application.UseCase.Auth.IGenerateAccessTokenUseCase;
using Src.Core.Application.UseCase.Auth.IGenerateRefreshTokenUseCase;
using Src.Core.Application.UseCase.GenerateAccessTokenImpl;
using Src.Core.Application.UseCase.GenerateRefreshTokenImpl;
using Src.Core.Port.AuthPort;
using Src.Core.Port.ValidatorEmail.Port;
using Src.Infra.Adapters.ValidatorEmailAdapter;

namespace Src.Infra.Config.ExtensionMethodsWebApplication;
public static  class ExtensionMethodsWebApplication{


public static void AddInstances(this WebApplicationBuilder builder){
     builder.Services.AddTransient<ValidatorEmailPort,ValidatorEmailAdapter>();

     builder.Services.AddTransient<IGenerateAccessTokenUseCase,GenerateAccessTokenImpl>();

     builder.Services.AddTransient<IGenerateRefreshTokenUseCase,GenerateRefreshTokenImpl>();

     builder.Services.AddTransient<AuthPort,AuthAdapter>();

        
    }
    
}