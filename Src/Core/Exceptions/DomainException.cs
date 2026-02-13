namespace Src.Core.Exceptions;
using Src.Core.Exceptions.BaseException;

public class DomainException : DomainBaseException{
    public DomainException(string message,int statusCode):base(message,statusCode){}
}