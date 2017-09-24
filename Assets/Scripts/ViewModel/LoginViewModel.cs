using Interface;
using Model;

namespace ViewModel
{
    public class LoginViewModel : ILoginViewModel
    {
        public ManualLogin Model { get; private set; }

        public void OnClickLoginButton(string userName)
        {
            Model.OnClickLoginButton(userName);
        }

        public LoginViewModel(ManualLogin model)
        {
            Model = model;
        }
    }
}