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

        public IObservable<bool> canAttack
        {
            get { return Model.canAttackToday; }
        }

        private MainCat Model { get; set; }

        public void OnCLickAttackButton(float damage)
        {
            Model.OnCLickAttackButton(damage);
        }

        public void OnClickReloadButton()
        {
            Model.OnClickReloadButton();
        }

        public MainCatViewModel(MainCat model)
        {
            Model = model;
        }
    }
}