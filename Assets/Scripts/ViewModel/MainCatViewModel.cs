using Interface;
using UniRx;
using DateTime = System.DateTime;
using TimeSpan = System.TimeSpan;

namespace ViewModel
{
    public class MainCatViewModel : IMainCatViewModel
    {
        public IObservable<int> remainHp
        {
            get { return remainHpViewModel; }
        }

        private readonly ReactiveProperty<int> remainHpViewModel = new ReactiveProperty<int>(50000);

        public IObservable<TimeSpan> remainTime
        {
            get { return remainTimeViewModel; }
        }

        private readonly ReactiveProperty<TimeSpan> remainTimeViewModel =
            new ReactiveProperty<TimeSpan>(DateTime.Now - DateTime.Today);

        public void OnCLickAttackButton(float damage)
        {
            remainHpViewModel.Value = (int)(damage * 1000);
        }

        public MainCatViewModel()
        {
        }
    }
}