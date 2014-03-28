using apiFormTranslator.Presenter.Factories;
using apiFormTranslator.Presenter.POCO;
using apiFormTranslator.Service.Requests;
using apiFormTranslator.Service.Services;
using apiFormTranslator.View;

namespace apiFormTranslator.Presenter
{
    public class LoginPresenter : IPresenter
    {
        private ILoginForm _view;
        private SecurityService _loginService;

        public LoginPresenter(ILoginForm view, SecurityService loginService)
        {
            _view = view;
            _loginService = loginService;
        }

        public LoginPresenter(ILoginForm view)
            : this(view, new SecurityService())
        {
        }

        public User GetAuthenticatedUser()
        {
            var loginRequest = new LoginRequest
            {
                UserName = _view.UserName,
                Password = _view.Password
            };
            var loginResponse = _loginService.GetAuthenticatedUser(loginRequest);

            return UserFactory.GetUserFromResponse(loginResponse);
        }
    }
}
