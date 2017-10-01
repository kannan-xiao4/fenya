using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ValueObject
{
    /// <summary>
    /// 攻撃者ランキングのVo
    /// </summary>
    public class RankingVO
    {
        private readonly List<AttackHistoryVO> historyData;
        public FenyaVO TargetFenya;
        public Dictionary<PlayerVO, DamageVO> Ranking;

        /// <summary>
        /// AttackVOのリストからランキングを作成する
        /// </summary>
        private void MakeRanking()
        {
            Ranking = new Dictionary<PlayerVO, DamageVO>();

            Ranking = historyData
                .Select(x => x.AttackPlayer) //Player抽出
                .Select(TotalDamage) //PlayerとHistoryDataから各プレイヤーの総合ダメージ算出
                .GroupBy(x => x.Key) //Playerでグループ分け
                .Select(x => x.First()) //そのうちの一つを取得（重複削除）
                .OrderByDescending(x => x.Value.Amount) //ダメージの降順で並べ替え
                .ToDictionary(pair => pair.Key, pair => pair.Value);
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

        /// <summary>
        /// コンストラクタ
        /// AttackHistoryVOListからランキングDictionaryを作成する
        /// </summary>
        /// <param name="historyData"></param>
        public RankingVO(List<AttackHistoryVO> historyData)
        {
            TargetFenya = historyData.First().DamagedFenyaVo;
            this.historyData = historyData;
            MakeRanking();
        }
    }
}