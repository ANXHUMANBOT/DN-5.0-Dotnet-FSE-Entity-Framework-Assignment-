using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstWebAPI.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string path = "errorlog.txt";

            File.AppendAllText(path,
                DateTime.Now + Environment.NewLine +
                context.Exception.ToString() +
                Environment.NewLine +
                "-----------------------------------" +
                Environment.NewLine);

            context.Result = new ObjectResult("Internal Server Error")
            {
                StatusCode = 500
            };

            context.ExceptionHandled = true;
        }
    }
}