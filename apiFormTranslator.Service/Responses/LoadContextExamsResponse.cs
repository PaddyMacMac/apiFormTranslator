using System.Collections.Generic;

namespace apiFormTranslator.Service.Responses
{
    public class LoadContextExamsResponse : IResponse
    {
        public IDictionary<string, string> ExmaNamesAndIds { get; set; }
    }
}
