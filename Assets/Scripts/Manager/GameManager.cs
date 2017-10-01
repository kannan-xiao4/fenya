using Model;
using UniRx;
using Utility;

namespace Manager
{
    /// <summary>
    /// ゲーム全体を管理するクラス
    /// </summary>
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        /// <summary>
        /// FenyaModel
        /// </summary>
        private MainCat mainCat;

        /// <summary>
        /// RankingModel
        /// </summary>
        private Ranking ranking;

        /// <summary>
        /// 初期処理
        /// </summary>
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