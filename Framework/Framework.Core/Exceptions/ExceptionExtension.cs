using System;

namespace Framework.Core.Exceptions
{
    public static class ExceptionExtension
    {
        public static string GetExceptionDetailMessage(this Exception actualException)
        {
            var detailedMessage = $"Error Message : {actualException.Message} ";
            detailedMessage += $" Stack trace : {actualException.StackTrace}";

            var innerException = actualException.InnerException;
            while (innerException != null)
            {
                detailedMessage += $"Error Message : {innerException.Message} ";
                detailedMessage += $" Stack trace : {innerException.StackTrace}";

                innerException = innerException.InnerException;
            }

            return detailedMessage;
        }
    }
}