using UniRx;
using TimeSpan = System.TimeSpan;

namespace Interface
{
    public interface IMainCatViewModel
    {
        IObservable<long> remainHp { get; }

        IObservable<TimeSpan> remainTime { get; }

        IObservable<bool> canAttack { get; }

        void OnCLickAttackButton(float damage);

        void OnClickReloadButton();
    }
}