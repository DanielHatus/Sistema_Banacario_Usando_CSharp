
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Src.Core.Application.UseCase.Contract.Auth;
using Src.Core.Application.UseCase.Implementation.Auth;
using Src.Core.Ports;
using Src.Infra.Adapters;
using Src.Infra.Utils;

namespace Src.Infra.Extensions;
public static class ExtensionMethodsWebApplication{
public static void AddSecurityConfiguration(this WebApplicationBuilder builder){
        var key=Encoding.ASCII.GetBytes("X2U3askdYMxjL1wRc8Ai8GAXJL901G0TQPSltdCnJqO");

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
           ValidateLifetime=false,
           ClockSkew=TimeSpan.Zero
          };
        });
    }
public static void AddInstances(this WebApplicationBuilder builder){
     builder.Services.AddTransient<IValidatorEmailPort,ValidatorEmailAdapter>();

     builder.Services.AddTransient<IGenerateAccessTokenUseCase,GenerateAccessTokenImpl>();

     builder.Services.AddTransient<IGenerateRefreshTokenUseCase,GenerateRefreshTokenImpl>();

     builder.Services.AddTransient<IAuthPort,AuthAdapter>();
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