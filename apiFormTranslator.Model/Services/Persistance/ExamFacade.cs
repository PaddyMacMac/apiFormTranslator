using System.Collections.Generic;
using apiFormTranslator.DAL;

namespace apiFormTranslator.Model.Services.Persistance
{
    public class ExamFacade
    {
        public IDictionary<string, string> LoadContextExamsNamesAndIds(string contextName)
        {
            return new ExamConnection().LoadContextExamsNamesAndIds(contextName);
        }
    }
}
