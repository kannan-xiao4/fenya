using Interface;
using View;

namespace PageSettings
{
    public class RankingSetting : PageSetting
    {
        private IRankingViewModel viewModel;
        
        internal override void BindLoadModel()
        {
            Instance.GetComponent<RankingView>().Bind(viewModel);
        }

        public void Bind(IRankingViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
    }
}