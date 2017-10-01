using Model;
using UniRx;
using Utility;

namespace Manager
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        private MainCat mainCat;
        private Ranking ranking;

        private void Start()
        {
            ProcessLogin();
        }

        /// <summary>
        /// ログインプロセスを開始する
        /// </summary>
        private void ProcessLogin()
        {
            Login.LoginSuccessAsObservable().Subscribe(_ => ShowRanking());
            Login.Process();
        }

        /// <summary>
        /// MainCatモデルを作成して表示する
        /// </summary>
        public void ShowMainCat()
        {
            if (mainCat == null)
            {
                mainCat = new MainCat();
            }

            mainCat.Show();
        }

        /// <summary>
        /// Rankingモデルを作成して表示する
        /// </summary>
        public void ShowRanking()
        {
            if (ranking == null)
            {
                ranking = new Ranking();
            }

            ranking.Show();
        }
    }
}