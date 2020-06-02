using BozheHvatitDushitSharp.Models;
using BozheHvatitDushitSharp.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BozheHvatitDushitSharp.Middleware
{

        public class RRLMiddleware
        {
            private readonly RequestDelegate _next;
            private readonly LogService db;

            public RRLMiddleware(RequestDelegate next, LogService _context)
            {
                _next = next;
                db = _context;
            }

            public async Task Invoke(HttpContext context)
            {
                var request = await FormatRequest(context.Request);
                var originalBodyStream =  context.Response.Body;

                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;
                    await _next(context);
                    var response = await FormatResponse(context.Response);
                    Log log = new Log
                    {
                        request = request,
                        response = response
                    };
                    await db.Create(log);
                    //await logRepository.Add(log);
                    //await unitOfWork.CompleteAsync();
                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }

            private async Task<string> FormatRequest(HttpRequest request)
            {
                var body = request.Body;
                request.EnableBuffering();
                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer, 0, buffer.Length);
                var bodyAsText = Encoding.UTF8.GetString(buffer);
                request.Body.Position = 0;
                return $"{request.Scheme} {request.Host}{request.Path} {request.QueryString}";

            }

            private async Task<string> FormatResponse(HttpResponse response)
            {
                response.Body.Seek(0, SeekOrigin.Begin);
                response.Body.Seek(0, SeekOrigin.Begin);
                return $"{response.StatusCode}";
            }
        }
    }

