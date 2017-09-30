namespace ValueObject
{
    public class DamageVO
    {
        public long Amount { get; private set; }

        public DamageVO(long amount)
        {
            Amount = amount;
        }
    }
}