using Interface;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    /// <summary>
    /// ログイン画面View
    /// </summary>
    public class LoginView : MonoBehaviour
    {
        [SerializeField]
        private InputField _userNameInputField;

        [SerializeField]
        private Button _loginButton;

        /// <summary>
        /// ViewModelをBind
        /// </summary>
        /// <param name="viewModel"></param>
        public void Bind(ILoginViewModel viewModel)
        {
            _loginButton.OnClickAsObservable().Subscribe(_ =>
            {
                viewModel.OnClickLoginButton(_userNameInputField.text);
            }).AddTo(this);
        }
    }
}