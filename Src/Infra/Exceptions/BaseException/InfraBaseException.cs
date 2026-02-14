using Src.Core.Exceptions.BaseException;

public class InfraBaseException:Exception{
    
    public  int StatusCode{get;}
    public InfraBaseException(string message,int statusCode):base(message)=> StatusCode=statusCode;
}