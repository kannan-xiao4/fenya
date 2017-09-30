using System.Collections.Generic;
using System.Linq;

namespace ValueObject
{
    public class RankingVO
    {
        private List<AttackHistoryVO> historyData;

        public Dictionary<PlayerVO, DamageVO> Ranking;

        /// <summary>
        /// AttackVOのリストからランキングを作成する
        /// </summary>
        /// <param name="list"></param>
        public void MakeRanking(List<AttackHistoryVO> list)
        {
            historyData = list;
            
            Ranking = new Dictionary<PlayerVO, DamageVO>();
            
            foreach (var pair in historyData.Select(x => x.AttackPlayer).Select(TotalDamage).OrderByDescending(x => x.Value))
            {
                Ranking.Add(pair.Key, pair.Value);
            }
        }

        /// <summary>
        /// 指定UserのUserとTotalDmageのPairを作る
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private KeyValuePair<PlayerVO, DamageVO> TotalDamage(PlayerVO user)
        {
            var totalDamage = historyData.Where(x => x.AttackPlayer.Equals(user)).Sum(x => x.DamageVo.Amount);
            
            return new KeyValuePair<PlayerVO, DamageVO>(user, new DamageVO(totalDamage));
        }
    }
}