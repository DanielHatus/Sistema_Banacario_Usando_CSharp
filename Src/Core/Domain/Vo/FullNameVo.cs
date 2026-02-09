using System.Reflection.Metadata;
using System.Text;
using Src.Core.Exceptions.DomainException;

namespace Src.Core.Vo.FullNameVo;
public class FullNameVo{
    public string FullName{get;}

    public FullNameVo(string? firstName,string? lastName){
      ValidateName(firstName);
      ValidateName(lastName);
      this.FullName=BuildFullName(firstName,lastName);
    }

    public FullNameVo(string fullName){
        this.FullName=fullName;
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
            string[] namesWithSpaced=name.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            foreach(string namespaced in namesWithSpaced){
                char firstLetterNameUppercase=char.ToUpper(namespaced[0]);
                objectStringBuilder.Append(firstLetterNameUppercase).
                Append(namespaced[1..].ToLower())
                .Append(" "); 
            }
        }
        string fullNameCompleted=objectStringBuilder.ToString();
         objectStringBuilder.Clear();
         return fullNameCompleted.Trim();  
    }

}