using Interface;
using Model;
using UniRx;
using TimeSpan = System.TimeSpan;

namespace ViewModel
{
    public class MainCatViewModel : IMainCatViewModel
    {
        public IObservable<long> remainHp
        {
            get { return Model.remainHpAsObservable; }
        }

        public IObservable<TimeSpan> remainTime
        {
            get { return Model.remainTimeAsObservable; }
        }

        private MainCat Model { get; set; }

        public void OnCLickAttackButton(float damage)
        {
            Model.OnCLickAttackButton(damage);
        }

        public MainCatViewModel(MainCat model)
        {
            Model = model;
        }
    }
}