namespace Src.Core.Exceptions.DomainException;
using Src.Core.Exceptions.BaseException;

public class DomainException : BaseException{
    public DomainException(string message,int statusCode):base(message,statusCode){}
}