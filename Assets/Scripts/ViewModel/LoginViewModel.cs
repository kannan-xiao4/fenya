using Interface;
using Model;

namespace ViewModel
{
    public class LoginViewModel : ILoginViewModel
    {
        public Login Model { get; private set; }
        
        public void OnClickLoginButton(string userName)
        {
            Model.OnClickLoginButton(userName);
        }

        public LoginViewModel(Login model)
        {
            Model = model;
        }
    }
}