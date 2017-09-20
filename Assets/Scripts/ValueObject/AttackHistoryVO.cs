using NCMB;

namespace ValueObject
{
    public class AttackHistoryVO
    {
        private const string HISTORY_CLASS_NAME = "AttackHistory";
        private const string ATTACKER_NAME = "AttackerName";
        private const string ATTACK_DAMAGE = "AttackDamage";

        private readonly string attackUserName;
        private readonly FenyaVO DamagedFenyaVo;
        private readonly int Damage;

        /// <summary>
        /// 現在の値からNCMBObjectを生成する
        /// </summary>
        /// <returns></returns>
        public NCMBObject CreateNcmbObject()
        {
            var obj = new NCMBObject(HISTORY_CLASS_NAME);
            obj[ATTACKER_NAME] = attackUserName;
            obj[ATTACK_DAMAGE] = Damage;
            obj.Add(FenyaVO.FENYA_CLASS_NAME, DamagedFenyaVo.CreateNcmbObject());

            return obj;
        }

        public AttackHistoryVO(string userName, FenyaVO fenya, int damage)
        {
            attackUserName = userName;
            DamagedFenyaVo = fenya;
            Damage = damage;
        }
    }
}