namespace Src.Core.Exceptions.BaseException;
public class BaseException : Exception{
    public int StatusCode{get;}
    
    public BaseException(string message,int statusCode) : base(message){
        this.StatusCode=statusCode;
    }
}