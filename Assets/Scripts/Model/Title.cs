using Manager;
using PageSettings;
using ViewModel;

namespace Model
{
    /// <summary>
    /// タイトル画面のModel
    /// </summary>
    public class Title
    {
        /// <summary>
        /// タイトル画面のViewModel
        /// </summary>
        private readonly TitleViewModel viewModel;

        /// <summary>
        /// プレイヤー名
        /// </summary>
        public string PlayerName {get { return NCMBManager.currentPlayerVo.Name; }}
        
        /// <summary>
        /// メイン画面を表示する
        /// </summary>
        public void ShowMainCatPage()
        {
            GameManager.Instance.ShowMainCat();
        }

        /// <summary>
        /// ランキング画面を表示する
        /// </summary>
        public void ShowRankingPage()
        {
            GameManager.Instance.ShowRanking();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Title()
        {
            viewModel = new TitleViewModel(this);
        }

        /// <summary>
        /// 画面を表示する
        /// </summary>
        public void Show()
        {
            var uiManager = UIManager.Instance;
            var pageSetting = uiManager.GetPageSetting<TitleSetting>();
            pageSetting.Bind(viewModel);
            uiManager.ReplaceCurrentPage<TitleSetting>();
        }
    }
}