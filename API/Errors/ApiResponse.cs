using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;

namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode,string message=null) 
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefaultMessageForStatusCode(statusCode);
   
        }

        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch{
                400 => "A bad request, you have made.",
                401 => "Authorization failed",
                404 => "not found",
                500 => "internal server error",
                   _ => "Contact to administrator"
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

    }
}