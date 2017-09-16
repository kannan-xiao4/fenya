using Manager;
using PageSettings;
using UniRx;
using View;
using ViewModel;
using DateTime = System.DateTime;
using TimeSpan = System.TimeSpan;

namespace Model
{
    /// <summary>
    /// MainCatのロジックをまとめるModel
    /// </summary>
    public class MainCat
    {
        private readonly MainCatViewModel viewModel;
        
        public IObservable<int> remainHpAsObservable
        {
            get { return remainHp; }
        }

        private readonly ReactiveProperty<int> remainHp = new ReactiveProperty<int>(50000);

        public IObservable<TimeSpan> remainTimeAsObservable
        {
            get { return remainTime; }
        }

        private readonly ReactiveProperty<TimeSpan> remainTime =
            new ReactiveProperty<TimeSpan>(DateTime.Now - DateTime.Today);

        public void OnCLickAttackButton(float damage)
        {
            remainHp.Value -= (int) (damage * 1000);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainCat()
        {
            viewModel = new MainCatViewModel(this);
        }

        /// <summary>
        /// 画面を表示する
        /// </summary>
        public void Show()
        {
            var uiManager = UIManager.Instance;
            uiManager.InstancePage<MainCatSetting>();
            uiManager.GetCurrentView<MainCatView>().Bind(viewModel);
        }
    }
}