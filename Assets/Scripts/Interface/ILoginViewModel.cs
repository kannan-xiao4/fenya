namespace Interface
{
    /// <summary>
    /// ログイン画面を表示するViewModelのInterface
    /// </summary>
    public interface ILoginViewModel
    {
        /// <summary>
        /// ログインボタンクリック
        /// </summary>
        /// <param name="userName"></param>
        void OnClickLoginButton(string userName);
    }
}