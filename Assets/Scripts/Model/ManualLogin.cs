using Manager;
using PageSettings;
using ValueObject;
using View;
using ViewModel;

namespace Model
{
    public class ManualLogin
    {
        private readonly LoginViewModel viewModel;

        /// <summary>
        /// ログイン画面が押された
        /// </summary>
        /// <param name="userName"></param>
        public void OnClickLoginButton(string userName)
        {
            AutoLogin.SaveUserName(userName);
            Login.LoginByNCMB(new PlayerVO(userName, true));
        }

        public ManualLogin()
        {
            viewModel = new LoginViewModel(this);
        }

        /// <summary>
        /// マニュアルログイン画面を表示する
        /// </summary>
        public void Show()
        {
            var uiManager = UIManager.Instance;
            var pageSetting = uiManager.GetPageSetting<LoginSetting>();
            pageSetting.Bind(viewModel);
            uiManager.ReplaceCurrentPage<LoginSetting>();
        }
    }
}