using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Contracts
{
    public class MessageContract<T>
    {
        public T?  Result { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public static class MessageContractExtention
    {
         public  static MessageContract<T> ToContract<T>(this T t)
        {
            return new MessageContract<T>() {
             Result = t,
             IsSuccess = true,
            };
        }

        public static MessageContract<T> ToFailContract<T> (this Exception message)
        {
            return new MessageContract<T>()
            {
                Result = default(T),
                Message = message.Message,
                IsSuccess = false
            };
        }

        public static MessageContract<T> ToFailContract<T>(this string message)
        {
            return new MessageContract<T>()
            {
                Result = default(T),
                Message = message,
                IsSuccess = false
            };
        }

    

    }

}
