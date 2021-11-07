using System;

namespace MarsRoverVolkan.Extensions
{
    public static class ResponseBaseExtensions
    {
        public static Response<T> Ok<T>(this T model)
        {
            return new Response<T> { IsSuccess = true, Result = model};
        }

        public static Response<T> Error<T>(this Enum messageEnum)
        {
            return new Response<T>
            {
                IsSuccess = false,
                Message = messageEnum.ToString()
            };
        }
    }
    
    public class Response<T>
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
        
        public T Result { get; set; }
    }
}