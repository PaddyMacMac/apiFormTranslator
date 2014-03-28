using System;
using apiFormTranslator.Model.Services.WSHandlers;
using apiFormTranslator.Service.Requests;
using apiFormTranslator.Service.Responses;

namespace apiFormTranslator.Service.Services
{
    public class SecurityService
    {
        private SecurityServiceHandler _securirtyServiceHander;

        public SecurityService(IServiceHandler serviceHandler)
        {
            _securirtyServiceHander = serviceHandler as SecurityServiceHandler;
        }

        public SecurityService()
            : this(new SecurityServiceHandler())
        {
        }

        public void SetCurrentContext(SetCurrentContextRequest request)
        {
            _securirtyServiceHander.SetCurrentContext(request.ContextName, request.ContextId);
        }

        public string GetCurrentContext()
        {
            return _securirtyServiceHander.GetCurrentContext();
        }
        public LoginResponse GetAuthenticatedUser(LoginRequest request)
        {
            LoginResponse loginResponse = null;
            try
            {
                var user = _securirtyServiceHander.AuthenticateUser(request.UserName, request.Password);

                loginResponse = new LoginResponse(user)
                {
                    Error = null,
                    Success = true,
                };
            }
            catch (Exception ex)
            {
                loginResponse = new LoginResponse(null)
                {
                    Error = ex,
                    Success = false,
                };
            }
            return loginResponse;
        }

        public UserContextsResponse LoadUserContexts(UserContextsRequest request)
        {
            UserContextsResponse userContextsResponse = null;
            try
            {
                var contexts = _securirtyServiceHander.GetUserContexts(request.UserId);

                userContextsResponse = new UserContextsResponse()
                {
                    Error = null,
                    Success = true,
                    Contexts = contexts
                };
            }
            catch (Exception ex)
            {
                userContextsResponse = new UserContextsResponse()
                {
                    Error = ex,
                    Success = false,
                };
            }
            return userContextsResponse;
        }
    }
}
