using System;

namespace apiFormTranslator.Service.Responses
{
    public abstract class IResponse
    {
        public bool Success { get; set; }
        public Exception Error { get; set; }
    }
}
