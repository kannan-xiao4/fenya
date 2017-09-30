using NCMB;

namespace ValueObject
{
    public class AttackHistoryVO
    {
        private const string HISTORY_CLASS_NAME = "AttackHistory";
        private const string ATTACKER_NAME = "AttackerName";
        private const string ATTACK_DAMAGE = "AttackDamage";
        private const string FENYA = "Fenya";

        public readonly PlayerVO AttackPlayer;
        public readonly FenyaVO DamagedFenyaVo;
        public readonly DamageVO DamageVo;

        /// <summary>
        /// 現在の値からNCMBObjectを生成する
        /// </summary>
        /// <returns></returns>
        public NCMBObject CreateNcmbObject()
        {
            var obj = new NCMBObject(HISTORY_CLASS_NAME);
            obj[ATTACKER_NAME] = AttackPlayer.Name;
            obj[ATTACK_DAMAGE] = DamageVo.Amount;
            obj.Add(FenyaVO.FENYA_CLASS_NAME, DamagedFenyaVo.CreateNcmbObject());

            return obj;
        }

        /// <summary>
        /// 今日の履歴を取得する
        /// </summary>
        /// <returns></returns>
        /// <remarks>攻撃者の名前必須</remarks>>
        public NCMBQuery<NCMBObject> CreateTodayHistoryQuery()
        {
            var query = new NCMBQuery<NCMBObject>(HISTORY_CLASS_NAME);
            query.OrderByAscending("createDate");
            query.WhereEqualTo(ATTACKER_NAME, AttackPlayer.Name);
            query.Limit = 5;

            return query;
        }

        public NCMBQuery<NCMBObject> CreateAttackHistoryQueryByFenyaVO()
        {
            var query = new NCMBQuery<NCMBObject>(HISTORY_CLASS_NAME);
            query.WhereEqualTo(FENYA, DamagedFenyaVo.CreateNcmbObject());
            query.Include(FENYA);

            return query;
        }

        /// <summary>
        /// ユーザー名を指定して取得する
        /// </summary>
        /// <param name="player"></param>
        public AttackHistoryVO(PlayerVO player)
        {
            AttackPlayer = player;
        }

        /// <summary>
        /// FenyaVO を指定して取得する
        /// </summary>
        /// <param name="fenya"></param>
        public AttackHistoryVO(FenyaVO fenya)
        {
            DamagedFenyaVo = fenya;
        }

        /// <summary>
        /// すべて指定して作成
        /// 更新時に使用
        /// </summary>
        /// <param name="player"></param>
        /// <param name="fenya"></param>
        /// <param name="damage"></param>
        public AttackHistoryVO(PlayerVO player, FenyaVO fenya, DamageVO damage)
        {
            AttackPlayer = player;
            DamagedFenyaVo = fenya;
            DamageVo = damage;
        }

        /// <summary>
        /// クエリで取得したものから作成
        /// </summary>
        /// <param name="ncmbObject"></param>
        public AttackHistoryVO(NCMBObject ncmbObject)
        {
            var attackerName = ncmbObject[ATTACKER_NAME] as string;
            var isSelf = NCMBUser.CurrentUser.UserName == attackerName;
            AttackPlayer = new PlayerVO(attackerName, isSelf);
            DamagedFenyaVo = new FenyaVO(ncmbObject[FENYA] as NCMBObject);
            DamageVo = new DamageVO((long)ncmbObject[ATTACK_DAMAGE]);
        }
    }
}