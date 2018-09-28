using System;

namespace Codific.Exceptions
{
    public class NotFoundItemInBackpackException : InvalidOperationException
    {
        public NotFoundItemInBackpackException() : base("Не е намерен предмета в чантата")
        {
            
        }
    }
}
