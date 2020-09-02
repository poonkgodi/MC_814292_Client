using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace ClientService.Filter
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment env;
        public HttpGlobalExceptionFilter(IHostEnvironment env)
        {
            this.env = env;
        }
        public void OnException(ExceptionContext context)
        {
            if (this.env.IsDevelopment())
            {
            }
        }
    }
}
