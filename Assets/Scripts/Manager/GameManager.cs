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
            Login.LoginSuccessAsObservable().Subscribe(_ => ProcessRanking());
            Login.Process();
        }

        /// <summary>
        /// MainCatモデルを作成して表示する
        /// </summary>
        private void ProcessMainCat()
        {
            var model = new MainCat();
            model.Show();
        }

        /// <summary>
        /// Rankingモデルを作成して表示する
        /// </summary>
        private void ProcessRanking()
        {
            var model = new Ranking();
            model.Show();
        }
    }
}