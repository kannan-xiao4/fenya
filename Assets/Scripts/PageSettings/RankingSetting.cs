using Interface;
using View;

namespace PageSettings
{
    /// <summary>
    /// ランキングページの設定
    /// </summary>
    public class RankingSetting : PageSetting
    {
        /// <summary>
        /// ViewModelを保持
        /// </summary>
        private IRankingViewModel viewModel;

        /// <summary>
        /// ViewにViewModelをBind
        /// </summary>
        internal override void BindLoadModel()
        {
            Instance.GetComponent<RankingView>().Bind(viewModel);
        }

        /// <summary>
        /// SettingにViewModelをBind
        /// </summary>
        /// <param name="viewModel"></param>
        public void Bind(IRankingViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}