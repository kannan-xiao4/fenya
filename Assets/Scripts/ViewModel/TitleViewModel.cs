using Interface;
using Model;

namespace ViewModel
{
    /// <summary>
    /// タイトル画面のViewModel
    /// </summary>
    public class TitleViewModel : ITitleViewModel
    {
        /// <summary>
        /// TitleのModel
        /// </summary>
        private readonly Title Model;

        /// <summary>
        /// プレイヤーの名前
        /// </summary>
        public string PlayerName { get { return Model.PlayerName; } }

        /// <summary>
        /// メイン画面に遷移
        /// </summary>
        public void OnClickAttackPageButton()
        {
            Model.ShowMainCatPage();
        }

        /// <summary>
        /// ランキングページに遷移
        /// </summary>
        public void OnClickRankingPageButton()
        {
            Model.ShowRankingPage();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TitleViewModel(Title model)
        {
            Model = model;
        }
    }
}