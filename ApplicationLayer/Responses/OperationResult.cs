using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Responses
{
    public class OperationResult<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
        public List<string>? Errors { get; set; }

        public static OperationResult<T> Ok(T data, string? message = null)
            => new OperationResult<T> { Success = true, Data = data, Message = message };

        public static OperationResult<T> Fail(string message, List<string>? errors = null)
            => new OperationResult<T> { Success = false, Message = message, Errors = errors };
    }
}
