using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using apiFormTranslator.Model.Enums;
using apiFormTranslator.Model.POCO;

namespace apiFormTranslator.Model.Services.WSHandlers
{
    public class AutoGenCodeServiceHandler : IServiceHandler
    {
        private const string MCQRS_ITEM = "Prometric.Intelitest.ItemMCQSR";

        public bool CheckCodeExist(string masterCode)
        {
            using (var service = new AutoGenCodeWebService.AutoGenCodeWebService())
            {
                service.user = GetServiceUser(ServiceTypesEnum.AutoGenCodeService) as AutoGenCodeWebService.User;
                return service.CheckCodeExists(MCQRS_ITEM, masterCode, User.Instance.ContextId);
            }
        }
    }
}
