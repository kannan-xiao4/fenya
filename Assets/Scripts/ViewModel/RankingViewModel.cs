using System.Collections.Generic;
using System.Linq;
using Interface;
using Model;
using UniRx;
using ValueObject;

namespace ViewModel
{
    public class RankingViewModel : IRankingViewModel
    {
        private readonly Ranking Model;

        public IObservable<List<IRankingCardViewModel>> rankingCardList
        {
            get { return ObservableRankingVo(); }
        }

        public RankingViewModel(Ranking model)
        {
            Model = model;
        }

        /// <summary>
        /// モデルのRankingVOからListRankigCardのObservableに
        /// </summary>
        /// <returns></returns>
        private IObservable<List<IRankingCardViewModel>> ObservableRankingVo()
        {
            return Model.rankingObject.Select(CreateRankingCardByRankingVo);
        }

        /// <summary>
        /// RankigVOからRankigCardVMのListを作成
        /// </summary>
        /// <param name="rankingVo"></param>
        /// <returns></returns>
        private List<IRankingCardViewModel> CreateRankingCardByRankingVo(RankingVO rankingVo)
        {
            return rankingVo.Ranking
                .Select((r, i) => new {r, i})
                .Select(pair => new RankingCardViewModel(pair.i + 1, pair.r.Key, pair.r.Value))
                .Cast<IRankingCardViewModel>()
                .ToList();
        }
    }
}