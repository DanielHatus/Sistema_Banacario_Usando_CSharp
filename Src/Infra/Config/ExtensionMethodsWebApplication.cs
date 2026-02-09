
using Src.Core.Port.ValidatorEmail.Port;
using Src.Infra.Adapters.ValidatorEmailAdapter;

namespace Src.Infra.Config.ExtensionMethodsWebApplication;
public static  class ExtensionMethodsWebApplication{


public static void AddInstances(this WebApplicationBuilder builder){
     builder.Services.AddTransient<ValidatorEmailPort,ValidatorEmailAdapter>();
        
    }
    
}