public static class VariablesAmbientValidateAndReturn{

    public static string Execute(IConfiguration config,string nameVariableAmbient){
        string? dataPossible=config[nameVariableAmbient];

        return string.IsNullOrWhiteSpace(dataPossible)
        ?throw new VariablesAmbientNotExists($"não foi encontrado uma variavél de ambiente com o nome passado: {nameVariableAmbient}",500)
        :dataPossible;
    }
    
}