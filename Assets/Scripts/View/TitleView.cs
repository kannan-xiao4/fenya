using Interface;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    /// <summary>
    /// タイトルページのView
    /// </summary>
    public class TitleView : MonoBehaviour
    {
        [SerializeField]
        private Text playerNameText;

        [SerializeField]
        private Button attackPageButton;

        [SerializeField]
        private Button rankingPageButton;

        /// <summary>
        /// ViewModelをBind
        /// </summary>
        public void Bind(ITitleViewModel viewModel)
        {
            playerNameText.text = viewModel.PlayerName;

            attackPageButton.OnClickAsObservable().Subscribe(_ => viewModel.OnClickAttackPageButton()).AddTo(this);

            rankingPageButton.OnClickAsObservable().Subscribe(_ => viewModel.OnClickRankingPageButton()).AddTo(this);
        }
    }
}