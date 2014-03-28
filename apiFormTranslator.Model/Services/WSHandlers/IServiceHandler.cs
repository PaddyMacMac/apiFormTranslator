using apiFormTranslator.Model.Enums;
using apiFormTranslator.Model.Factories;

namespace apiFormTranslator.Model.Services.WSHandlers
{
    public abstract class IServiceHandler
    {
        protected object GetServiceUser(ServiceTypesEnum userType)
        {
            return UserFactory.GetUser(userType);
        }
    }
}
