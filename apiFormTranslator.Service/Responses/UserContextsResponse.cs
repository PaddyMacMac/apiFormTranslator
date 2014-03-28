using System.Collections.Generic;

namespace apiFormTranslator.Service.Responses
{
    public class UserContextsResponse : IResponse
    {
        public IDictionary<string, string> Contexts { get; set; }
    }
}
