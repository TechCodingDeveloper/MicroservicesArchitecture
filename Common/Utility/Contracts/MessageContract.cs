using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Contracts
{
    public class MessageContract<T>
        where T : class
    {
        public T?  Result { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }

    public static class MessageContractExtention
    {
         public  static MessageContract<T> ToContract<T>(this T t)
             where T : class
        {
            return new MessageContract<T>() {
             Result = t,
             IsSuccess = true,
            };
        }

        public static MessageContract<T> toFailContract<T> (this Exception message)
                    where T : class
        {
            return new MessageContract<T>()
            {
                Result = null,
                Message = message.Message,
                IsSuccess = false
            };
        }
    }

}
