using Manager;
using PageSettings;
using UniRx;
using ValueObject;
using ViewModel;

namespace Model
{
    public class Ranking
    {
        private readonly RankingViewModel viewModel;
        public readonly ReactiveProperty<RankingVO> rankingObject = new ReactiveProperty<RankingVO>();

        /// <summary>
        /// FenyaPageを表示する
        /// </summary>
        public void ShowFenyaPage()
        {
            GameManager.Instance.ShowMainCat();
        }

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