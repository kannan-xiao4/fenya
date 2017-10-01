using Interface;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

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

        [SerializeField]
        private Button fenyaPageButton;

        /// <summary>
        /// ViewModelをBind
        /// </summary>
        /// <param name="viewModel"></param>
        public void Bind(IRankingViewModel viewModel)
        {
            viewModel.rankingCardList
                .Where(x => x != null)
                .Subscribe(list => list.ForEach(InitializeCardView))
                .AddTo(this);

            fenyaPageButton.OnClickAsObservable().Subscribe(_ => viewModel.OnClickFenyaButton()).AddTo(this);
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