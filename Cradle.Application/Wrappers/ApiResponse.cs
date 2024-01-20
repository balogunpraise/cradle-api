using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cradle.Application.Wrappers
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Success = StatusCode == 200 || StatusCode == 201;
            Message = message ?? GetResponseMessage(statusCode);
        }

        private static string GetResponseMessage(int statusCode)
        {
            return statusCode switch
            {
                200 => "Operation successul",
                201 => "Resource Created",
                400 => "Bad Request",
                404 => "Resource Not Found",
                401 => "Unauthorized",
                500 => "Internal Server Error",
                _ => null
            };
        }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
        public ApiResponse(T data, int statusCode, string message = null) : base(statusCode, message)
        {
            Data = data;
        }
    }
}
