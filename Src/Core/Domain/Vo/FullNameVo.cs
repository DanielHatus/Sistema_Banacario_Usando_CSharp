namespace Src.Core.Domain.Vo;
using System.Reflection.Metadata;
using System.Text;
using Src.Core.Exceptions;

public class FullNameVo{
    public string Value{get;}

    private FullNameVo(string? firstName,string? lastName){
      ValidateName(firstName);
      ValidateName(lastName);
      this.Value=BuildFullName(firstName,lastName);
    }
    
    private FullNameVo(string fullName){
        this.Value=fullName;
    }

    public static FullNameVo ReceivedFullNameByDatabase(string fullName){
        return new FullNameVo(fullName);
    }

    public static FullNameVo CreateFullName(string? firstName,string? lastName){
        return new FullNameVo(firstName,lastName);
    }
    private void ValidateName(string? name){

       if (string.IsNullOrWhiteSpace(name)){
            throw new DomainException("nome nulo,vazio ou somente com espaços em branco.",400);
        }

       if(name.Length<=3|| name.Length > 30){
            throw new DomainException(" o número de caracteres do nome deve estar entre 3 e 30 carcateres.",400);
        }  
    }

    private string BuildFullName(string firstName,string lastName)=> CapitalizeNames(firstName,lastName);

    private string CapitalizeNames(params string[] names){
       StringBuilder objectStringBuilder=new StringBuilder(); 
       foreach(string name in names){
            string[] partsName=name.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            foreach(string nameFetch in partsName){
                char firstLetterName=char.ToUpper(nameFetch[0]);
                objectStringBuilder.Append(firstLetterName).
                Append(nameFetch[1..].ToLower())
                .Append(" "); 
            }
        }
        string fullNameCompleted=objectStringBuilder.ToString();
         return fullNameCompleted.Trim();  
    }
}