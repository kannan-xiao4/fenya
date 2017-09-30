using System.Collections.Generic;

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
        List<IRankingCardViewModel> rankingCardList { get; }
    }
}