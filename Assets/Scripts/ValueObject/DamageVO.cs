namespace ValueObject
{
    /// <summary>
    /// Fenyaへのダメージを扱うVO
    /// </summary>
    public class DamageVO
    {
        /// <summary>
        /// ダメージ量（単一だったり総計だったり）
        /// </summary>
        public long Amount { get; private set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="amount"></param>
        public DamageVO(long amount)
        {
            Amount = amount;
        }
    }
}