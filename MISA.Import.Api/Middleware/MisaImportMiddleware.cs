using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MISA.Import.Api.Middleware
{
    public class MisaImportMiddleware
    {
        private RequestDelegate _next;

        public MisaImportMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleError(context, ex);
            }
        }

        private Task HandleError(HttpContext context, Exception ex)
        {
            var msg = new
            {
                devMsg = ex.Message,
                userMsg = "Có lỗi xảy ra vui lòng liên hệ người code"
            };
            var result = JsonSerializer.Serialize(msg);
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(result);
        }
    }
}
