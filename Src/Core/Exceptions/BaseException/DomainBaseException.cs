namespace Src.Core.Exceptions;
public class DomainBaseException : Exception{
    public int StatusCode{get;}
    
    public DomainBaseException(string message,int statusCode) : base(message){
        this.StatusCode=statusCode;
    }
}