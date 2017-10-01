using Manager;
using PageSettings;
using UniRx;
using ValueObject;
using ViewModel;

namespace Model
{
    /// <summary>
    /// ランキングモデル
    /// </summary>
    public class Ranking
    {
        /// <summary>
        /// ランキング表示のためのViewModel
        /// </summary>
        private readonly RankingViewModel viewModel;

        /// <summary>
        /// ランキングVoを購読
        /// </summary>
        public readonly ReactiveProperty<RankingVO> rankingObject = new ReactiveProperty<RankingVO>();

        /// <summary>
        /// FenyaPageを表示する
        /// </summary>
        public void ShowFenyaPage()
        {
            GameManager.Instance.ShowMainCat();
        }

        /// <summary>
        /// コンストラクタ
        /// ToDo:現在のFenyaをFetchしてRanking表示は無駄、すでに取得済みのFenyaを使いたい
        /// </summary>
        public Ranking()
        {
            viewModel = new RankingViewModel(this);
            NCMBManager.Instance.FetchFenyaObject().Subscribe(fenya =>
            {
                NCMBManager.Instance.FetchRankingByFenyaVO(fenya).Subscribe(x => rankingObject.Value = x);
            });
        }

        /// <summary>
        /// 画面を表示する
        /// </summary>
        public void Show()
        {
            var uiManager = UIManager.Instance;
            var pageSetting = uiManager.GetPageSetting<RankingSetting>();
            pageSetting.Bind(viewModel);
            uiManager.ReplaceCurrentPage<RankingSetting>();
        }
    }
}