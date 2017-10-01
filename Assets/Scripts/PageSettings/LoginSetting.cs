using Interface;
using View;

namespace PageSettings
{
    /// <summary>
    /// ログインページの設定
    /// </summary>
    public class LoginSetting : PageSetting
    {
        /// <summary>
        /// ViewModelを保持
        /// </summary>
        private ILoginViewModel viewModel;

        /// <summary>
        /// ViewにViewModelをBind
        /// </summary>
        internal override void BindLoadModel()
        {
            Instance.GetComponent<LoginView>().Bind(viewModel);
        }

        /// <summary>
        /// SettingにViewModelをBind
        /// </summary>
        /// <param name="viewModel"></param>
        public void Bind(ILoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}