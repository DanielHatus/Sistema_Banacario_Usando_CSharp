
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Src.Core.Application.Orchestrator;
using Src.Core.Application.UseCase.Contract.Auth;
using Src.Core.Application.UseCase.Contract.Crud;
using Src.Core.Application.UseCase.Implementation.Auth;
using Src.Core.Ports;
using Src.Infra.Adapters;
using Src.Infra.Db_Context;
using Src.Infra.Mapper;
using Src.Infra.Persistence.Repository.Contract;
using Src.Infra.Persistence.Repository.Implementation;
using Src.Infra.Utils;

namespace Src.Infra.Extensions;
public static class ExtensionMethodsWebApplication{
public static void AddSecurityConfiguration(this WebApplicationBuilder builder,string keySecret){
        var key=Encoding.ASCII.GetBytes(keySecret);

        builder.Services.AddAuthentication(x =>{
           x.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
           x.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme; 
        })
        .AddJwtBearer(x =>
        {
          x.RequireHttpsMetadata=false;
          x.SaveToken=true;
          x.TokenValidationParameters=new TokenValidationParameters(){
           ValidateIssuerSigningKey=true,
           IssuerSigningKey= new SymmetricSecurityKey(key),
           ValidateIssuer=false,
           ValidateAudience=false,
           ValidateLifetime=true,
           ClockSkew=TimeSpan.Zero
          };
        });
    }
public static void AddInstances(this WebApplicationBuilder builder){
             //Instancias relaciondas ao banco de dados.
     builder.Services.AddScoped<AppDbContext>();
     builder.Services.AddScoped<IRepositoryUser,RepositoryUserImpl>();

            //Instancia relacionadas aos ports/adapters
     builder.Services.AddSingleton<IAuthPort,AuthAdapter>();
     builder.Services.AddSingleton<IBCryptPort,BCryptAdapter>();
     builder.Services.AddScoped<IUserDbPort,UserDbAdapter>();
     builder.Services.AddScoped<IValidatorEmailPort,ValidatorEmailAdapter>();

            //Instancias sobre outros objetos no geral
     builder.Services.AddSingleton<UserMapper>();
     builder.Services.AddScoped<VariablesAmbientObject>();

            //Instancias para os orquestradores
     builder.Services.AddScoped<RegisterUserOrchestrator>();
     builder.Services.AddScoped<LoginUserOrchestrator>();

            //Instancias para os use cases
     builder.Services.AddSingleton<IGenerateAccessTokenUseCase,GenerateAccessTokenUseCaseImpl>();
     builder.Services.AddSingleton<IGenerateRefreshTokenUseCase,GenerateRefreshTokenUseCaseImpl>();
     builder.Services.AddScoped<IRegisterUserUseCase,RegisterUserUseCaseImpl>();
     builder.Services.AddScoped<ILoginUserUseCase,LoginUserUseCaseImpl>();           
    }
public static VariablesAmbientObject AddVariablesAmbient(this IServiceCollection service,IConfiguration config){
  var settings=new VariablesAmbientObject(){

      KeyAssignatureSecret=VariablesAmbientValidateAndReturn.Execute(config,"SECRET_KEY_IN_BASE_64"),

      DatabaseUsername=VariablesAmbientValidateAndReturn.Execute(config,"DATABASE_USERNAME"),

      DatabasePassword=VariablesAmbientValidateAndReturn.Execute(config,"DATABASE_PASSWORD"),
    };

    service.Configure<VariablesAmbientObject>(options=>{
      options.KeyAssignatureSecret= settings.KeyAssignatureSecret;
      options.DatabaseUsername= settings.DatabaseUsername;
      options.DatabasePassword= settings.DatabasePassword;     
    });

    return settings;
  }    
}