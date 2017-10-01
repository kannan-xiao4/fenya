using System.Collections.Generic;
using UniRx;

namespace Interface
{
    /// <summary>
    /// ランキング表示のためのViewModel
    /// </summary>
    public interface IRankingViewModel
    {
        /// <summary>
        /// ランキングカードのリスト、表示させたい順番に入っている
        /// 普通は降順
        /// </summary>
        IObservable<List<IRankingCardViewModel>> rankingCardList { get; }

        /// <summary>
        /// Fenyaページに遷移する
        /// </summary>
        void OnClickFenyaButton();
    }
}