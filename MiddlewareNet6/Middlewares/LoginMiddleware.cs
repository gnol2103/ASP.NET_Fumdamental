using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareNet6.Middlewares
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;
        public LoginMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            using var buffer = new MemoryStream();
            var request = context.Request;
            var response = context.Response;
            var stream = response.Body;
            response.Body = buffer;
            await _next(context);
            Debug.WriteLine("Request content type: Schema: {0}, Host: {1}, QueryString: {2}, Body: {3}, Path: {4}", request.Scheme, request.Host, request.QueryString, request.Body, request.Path);
            buffer.Position=0;
            await buffer.CopyToAsync(stream);
        }
    }
}