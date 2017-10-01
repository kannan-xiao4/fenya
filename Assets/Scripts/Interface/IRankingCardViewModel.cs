namespace Interface
{
    /// <summary>
    /// ランキングカード表示のためのViewModelのInterface
    /// </summary>
    public interface IRankingCardViewModel
    {
        /// <summary>
        /// ランク
        /// </summary>
        int Rank { get; }

        /// <summary>
        /// プレイヤー名
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 総与ダメージ
        /// </summary>
        long TotalDamage { get; }

        /// <summary>
        /// 自分のカードか？
        /// </summary>
        bool IsSelf { get; }
    }
}