using Interface;
using View;

namespace PageSettings
{
    public class MainCatSetting : PageSetting
    {
        private IMainCatViewModel viewModel;

        internal override void BindLoadModel()
        {
            Instance.GetComponent<MainCatView>().Bind(viewModel);
        }

        public void Bind(IMainCatViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}