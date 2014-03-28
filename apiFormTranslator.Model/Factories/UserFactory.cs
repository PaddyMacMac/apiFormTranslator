using System;
using apiFormTranslator.Model.Enums;
using apiFormTranslator.Model.POCO;

namespace apiFormTranslator.Model.Factories
{
    public class UserFactory
    {
        public static object GetUser(ServiceTypesEnum userType)
        {
            var contextId = User.Instance.ContextId;
            var usrName = User.Instance.UserName;
            var usrId = User.Instance.UserId;
            var auth = User.Instance.Authenticated;

            switch (userType)
            {
                case (ServiceTypesEnum.ItemService):
                    return new ItemService.User
                    {
                        currentContextId = contextId,
                        userName = usrName,
                        userId = usrId,
                        authenticated = auth
                    };
                case (ServiceTypesEnum.ExamService):
                    return new ExamService.User
                    {
                        currentContextId = contextId,
                        userName = usrName,
                        userId = usrId,
                        authenticated = auth
                    };
                case (ServiceTypesEnum.ListService):
                    return new ListService.User
                    {
                        currentContextId = contextId,
                        userName = usrName,
                        userId = usrId,
                        authenticated = auth
                    };
                case (ServiceTypesEnum.SecurityService):
                    return new SecurityService.User
                    {
                        currentContextId = contextId,
                        userName = usrName,
                        userId = usrId,
                        authenticated = auth
                    };
                case (ServiceTypesEnum.IcsService):
                    return new ICSService.User
                    {
                        currentContextId = contextId,
                        userName = usrName,
                        userId = usrId,
                        authenticated = auth
                    };
                case (ServiceTypesEnum.SearchService):
                    return new SearchService.User
                    {
                        currentContextId = contextId,
                        userName = usrName,
                        userId = usrId,
                        authenticated = auth
                    };
                case (ServiceTypesEnum.AutoGenCodeService):
                    return new AutoGenCodeWebService.User
                    {
                        currentContextId = contextId,
                        userName = usrName,
                        userId = usrId,
                        authenticated = auth
                    };
                default:
                    throw new Exception(string.Format("No User defined for Service User Type {0}", userType.ToString()));
            }
        }
    }
}
