using Interface;
using UnityEngine;

namespace View
{
    /// <summary>
    /// ランキングを表示するView
    /// </summary>
    public class RankingView : MonoBehaviour
    {
        [SerializeField]
        private RankingCardView rankingCardPrefab;

        [SerializeField]
        private Transform rankingCardParent;

        /// <summary>
        /// ViewModelをBind
        /// </summary>
        /// <param name="viewModel"></param>
        public void Bind(IRankingViewModel viewModel)
        {
            viewModel.rankingCardList.ForEach(InitializeCardView);
        }

        /// <summary>
        /// 個々のカードの生成と初期化
        /// </summary>
        /// <param name="viewModel"></param>
        private void InitializeCardView(IRankingCardViewModel viewModel)
        {
            Instantiate(rankingCardPrefab, rankingCardParent, false)
                .GetComponent<RankingCardView>().Bind(viewModel);
        }
    }
}