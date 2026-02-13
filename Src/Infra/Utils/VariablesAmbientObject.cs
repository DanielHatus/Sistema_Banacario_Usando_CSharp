namespace Src.Infra.Utils;
public class VariablesAmbientObject{

    public VariablesAmbientObject(){}
    public string? KeyAssignatureSecret{get;set;}
    public string? DatabaseUsername{get;set;}
    public string? DatabasePassword{get;set;} 

    public string GetConnectionString() {
        return $"Host=localhost;Port=5432;Database={DatabaseUsername};Username={DatabaseUsername};Password={DatabasePassword};Include Error Detail=true";
    }
}