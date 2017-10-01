using Interface;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    /// <summary>
    /// 個々のランキングカードを表示するためのView
    /// </summary>
    public class RankingCardView : MonoBehaviour
    {
        [SerializeField]
        private Text rankText;

        [SerializeField]
        private Text playerNameText;

        [SerializeField]
        private Text totalDamageText;

        /// <summary>
        /// ViewModelをBind
        /// </summary>
        /// <param name="viewModel"></param>
        public void Bind(IRankingCardViewModel viewModel)
        {
            rankText.text = viewModel.Rank.ToString();
            totalDamageText.text = viewModel.TotalDamage.ToString();

            playerNameText.text = viewModel.Name;
            
            if(!viewModel.IsSelf) return;
            playerNameText.color = Color.blue;
        }
    }
}