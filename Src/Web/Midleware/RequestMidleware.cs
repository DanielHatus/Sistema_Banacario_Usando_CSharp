using System.Text.Json;
using Src.Core.Exceptions;
using Src.Core.Exceptions.BaseException;

namespace Src.Web.Midleware;
public class RequestMidleware{
    public readonly RequestDelegate _next;

    public RequestMidleware(RequestDelegate next)=> _next=next;

    public async Task InvokeAsync(HttpContext context){

        try{
         await _next(context);   
        }
        catch(Exception e){
            await HandlerExceptionAsync(e,context);
        }
    }

    private static Task HandlerExceptionAsync(Exception exception,HttpContext context){
        var (message,statusCode)= exception switch{
          DomainBaseException e => (e.Message,e.StatusCode),
          InfraBaseException e=> (e.Message,e.StatusCode),
          _ => ($"ocorreu um erro não previsto. {exception.Message}",500)
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        
        var response=new{
            StatusCode=statusCode,
            Message=message
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}