using System;
using System.Net;
using McfApi.Exceptions;
using McfApi.Models;

namespace McfApi.Middleware
{
	public class HandleExceptionMiddleware : IMiddleware
	{
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (NotFoundException e)
            {
                await HandleExceptionAsync(context, e);
            }
            catch (BadRequestException e)
            {
                await HandleExceptionAsync(context, e);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            var error = new ErrorDetails
            {
                status_code = context.Response.StatusCode,
                message = "Internal Server Error"
            };

            switch (e)
            {
                case NotFoundException:
                    error.status_code = (int)HttpStatusCode.NotFound;
                    error.is_success = false;
                    error.message = e.Message;
                    error.path = context.Request.Path;
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case BadRequestException:
                    error.status_code = (int)HttpStatusCode.BadRequest;
                    error.is_success = false;
                    error.message = e.Message;
                    error.path = context.Request.Path;
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case Exception:
                    error.status_code = (int)HttpStatusCode.InternalServerError;
                    error.is_success = false;
                    error.message = e.Message;
                    error.path = context.Request.Path;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            return context.Response.WriteAsJsonAsync(error);
        }
    }
}

