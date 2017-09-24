using Model;
using UniRx;
using Utility;

namespace Manager
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        private void Start()
        {
            ProcessLogin();
        }

        /// <summary>
        /// ログインプロセスを開始する
        /// </summary>
        private void ProcessLogin()
        {
            Login.LoginSuccessAsObservable().Subscribe(_ => ProcessMainCat());
            Login.Process();
        }

        /// <summary>
        /// モデルを作成して表示する
        /// </summary>
        private void ProcessMainCat()
        {
            var model = new MainCat();
            model.Show();
        }
    }
}