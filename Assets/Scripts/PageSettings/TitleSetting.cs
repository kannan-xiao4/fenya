using Interface;
using UnityEngine;
using View;

namespace PageSettings
{
    /// <summary>
    /// タイトル画面のセッティング
    /// </summary>
    [CreateAssetMenu]
    public class TitleSetting : PageSetting
    {
        /// <summary>
        /// ViewModelを保持
        /// </summary>
        private ITitleViewModel viewModel;

        /// <summary>
        /// ViewにViewModelをBind
        /// </summary>
        internal override void BindLoadModel()
        {
            Instance.GetComponent<TitleView>().Bind(viewModel);
        }

        /// <summary>
        /// SettingにViewModelをBind
        /// </summary>
        /// <param name="viewModel"></param>
        public void Bind(ITitleViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}