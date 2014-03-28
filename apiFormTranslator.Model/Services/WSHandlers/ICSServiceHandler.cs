using apiFormTranslator.Model.Enums;

namespace apiFormTranslator.Model.Services.WSHandlers
{
    public class ICSServiceHandler : IServiceHandler
    {
        public string GetDefaultIcsRootId()
        {
            using (var service = new ICSService.ICSService())
            {
                service.user = GetServiceUser(ServiceTypesEnum.IcsService) as ICSService.User;
                return service.GetICSNodeRootFolder();
            }
        }
    }
}
