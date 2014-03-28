using System.Collections.Generic;

namespace apiFormTranslator.Service.Responses
{
    public class LoadExamFormsResponse : IResponse
    {
        public IDictionary<string, string> FormIdsAndCodes { get; set; }
    }
}
