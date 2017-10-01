using UniRx;
using TimeSpan = System.TimeSpan;

namespace Interface
{
    /// <summary>
    /// Fenya画面を表示するViewModelのInterface
    /// </summary>
    public interface IMainCatViewModel
    {
        /// <summary>
        /// Fenyaの残りHP
        /// </summary>
        IObservable<long> remainHp { get; }

        /// <summary>
        /// 今週の残り時間
        /// </summary>
        IObservable<TimeSpan> remainTime { get; }

        /// <summary>
        /// 攻撃可能かどうか？1日1回
        /// </summary>
        IObservable<bool> canAttack { get; }

        /// <summary>
        /// 攻撃ボタンクリック時処理
        /// </summary>
        /// <param name="damage"></param>
        void OnCLickAttackButton(float damage);

        /// <summary>
        /// Fenyaの状態をリロード
        /// </summary>
        void OnClickReloadButton();

        /// <summary>
        /// ランキングページの表示
        /// </summary>
        void OnClickRankingButton();
    }
}