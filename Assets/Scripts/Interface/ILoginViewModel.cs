namespace Interface
{
    public interface ILoginViewModel
    {
        /// <summary>
        /// ログインボタンクリック
        /// </summary>
        /// <param name="userName"></param>
        void OnClickLoginButton(string userName);
    }
}