using CleanArq.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArq.Application.Features
{
    public static class ResponseApiService
    {
        public static BaseResponseModel Response(int statusCode, string message = null, object data = null)
        { 
            bool success = false;

            if (statusCode >= 200 && statusCode < 300)
                success = true;
            
            var result = new BaseResponseModel() { 
                StatusCode = statusCode,
                Success = success,
                Message = message,
                Data = data ?? new List<string>()
            };

            return result;
        }

    }
}
