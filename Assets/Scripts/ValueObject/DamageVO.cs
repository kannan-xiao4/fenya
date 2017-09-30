namespace ValueObject
{
    public class DamageVO
    {
        public int Amount { get; private set; }

        public DamageVO(int amount)
        {
            Amount = amount;
        }
    }
}