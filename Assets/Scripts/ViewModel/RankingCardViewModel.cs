using Interface;
using ValueObject;

namespace ViewModel
{
    /// <summary>
    /// ランキングカード表示のためのViewModel
    /// </summary>
    public class RankingCardViewModel : IRankingCardViewModel
    {
        /// <summary>
        /// ランク
        /// </summary>
        public int Rank { get; private set; }

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 攻撃ダメージ総計
        /// </summary>
        public long TotalDamage { get; private set; }

        /// <summary>
        /// 自分自身かどうか
        /// </summary>
        public bool IsSelf { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="rank"></param>
        /// <param name="playerVo"></param>
        /// <param name="damageVo"></param>
        public RankingCardViewModel(int rank, PlayerVO playerVo, DamageVO damageVo)
        {
            Rank = rank;
            Name = playerVo.Name;
            TotalDamage = damageVo.Amount;
            IsSelf = playerVo.IsSelf;
        }
    }
}