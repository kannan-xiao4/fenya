using Interface;
using View;

namespace PageSettings
{
    /// <summary>
    /// Fenyaページの設定
    /// </summary>
    public class MainCatSetting : PageSetting
    {
        /// <summary>
        /// ViewModelを保持
        /// </summary>
        private IMainCatViewModel viewModel;

        /// <summary>
        /// ViewにViewModelをBind
        /// </summary>
        internal override void BindLoadModel()
        {
            Instance.GetComponent<MainCatView>().Bind(viewModel);
        }

        /// <summary>
        /// SettingにViewModelをBind
        /// </summary>
        /// <param name="viewModel"></param>
        public void Bind(IMainCatViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}