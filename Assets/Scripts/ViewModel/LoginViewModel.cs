using Interface;
using Model;

namespace ViewModel
{
    /// <summary>
    /// ログイン画面を表示するViewModel
    /// </summary>
    public class LoginViewModel : ILoginViewModel
    {
        /// <summary>
        /// ログイン画面のModel
        /// </summary>
        public ManualLogin Model { get; private set; }

        /// <summary>
        /// ログインボタンクリック時の処理
        /// </summary>
        /// <param name="userName"></param>
        public void OnClickLoginButton(string userName)
        {
            if (userName == "") return;

            Model.OnClickLoginButton(userName);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model"></param>
        public LoginViewModel(ManualLogin model)
        {
            Model = model;
        }
    }
}