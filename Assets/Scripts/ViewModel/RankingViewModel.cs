using System.Collections.Generic;
using System.Linq;
using Interface;
using Model;
using UniRx;
using ValueObject;

namespace ViewModel
{
    /// <summary>
    /// ランキング画面表示のためのViewModel
    /// </summary>
    public class RankingViewModel : IRankingViewModel
    {
        /// <summary>
        /// ランキングModel
        /// </summary>
        private readonly Ranking Model;

        /// <summary>
        /// ランキングカードViewModelのList
        /// </summary>
        public IObservable<List<IRankingCardViewModel>> rankingCardList
        {
            get { return ObservableRankingVo(); }
        }

        /// <summary>
        /// FenyaPageへの遷移する
        /// </summary>
        public void OnClickFenyaButton()
        {
            Model.ShowFenyaPage();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model"></param>
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
            return Model.rankingObject.Where(x => x != null).Select(CreateRankingCardByRankingVo);
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