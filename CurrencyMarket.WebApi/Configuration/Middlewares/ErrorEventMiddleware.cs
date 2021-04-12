using CurrencyMarket.Common.Exceptions;
using CurrencyMarket.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyMarket.WebApi.Configuration.Middlewares
{
    public class ErrorEventMiddleware
    {
        private RequestDelegate _Next;

        public ErrorEventMiddleware(RequestDelegate next)
        {
            _Next = next;
        }
        public async Task Invoke(HttpContext context, ILogger<ErrorEventMiddleware> logger)
        {
            try { 
                await _Next(context);
            }catch(Exception ex)
            {
                logger.LogError(ex.Message);
                RequestErrorModel response = new RequestErrorModel();
                switch (ex)
                {
                    case InvalidCurrencyException a:
                        response.Code = StatusCodes.Status400BadRequest;
                        response.Message = a.Message;
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    case CurrencyExchangeLimitException a:
                        response.Code = StatusCodes.Status400BadRequest;
                        response.Message = a.Message;
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    default:
                        response.Code = StatusCodes.Status500InternalServerError;
                        response.Message = "Error processing the request.";
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }
                var result = JsonConvert.SerializeObject(response);
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(result);
            }
        }
    }
}
