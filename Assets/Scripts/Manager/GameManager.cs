using Model;
using UniRx;
using Utility;
using ValueObject;

namespace Manager
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        private void Start()
        {
            ProcessLogin();
        }

        private void ProcessLogin()
        {
            var model = new Login();
            model.Show();

            model.LoginSuccessAsObservable().First().Subscribe(_ => ProcessMainCat()).AddTo(this);
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