namespace Src.Core.Exceptions;
using Src.Core.Exceptions;

public class DomainException : BaseException{
    public DomainException(string message,int statusCode):base(message,statusCode){}
}