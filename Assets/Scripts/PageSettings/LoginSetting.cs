using Interface;
using View;

namespace PageSettings
{
    public class LoginSetting : PageSetting
    {
        private ILoginViewModel viewModel;

        internal override void BindLoadModel()
        {
            Instance.GetComponent<LoginView>().Bind(viewModel);
        }

        public void Bind(ILoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}