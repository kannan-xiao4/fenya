using System;
using Interface;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    /// <summary>
    /// Fenya画面のView
    /// </summary>
    public class MainCatView : MonoBehaviour
    {
        [SerializeField]
        private Text remainTimeText;

        [SerializeField]
        private Text remainHpText;

        [SerializeField]
        private InputField playerInputField;

        [SerializeField]
        private Button attackButton;

        [SerializeField]
        private Button reloadButton;

        [SerializeField]
        private Button rankingButton;

        /// <summary>
        /// ViewModelをBind
        /// </summary>
        /// <param name="viewModel"></param>
        public void Bind(IMainCatViewModel viewModel)
        {
            SubscribeViewModelChange(viewModel);

            SubscribePlayerInput(viewModel);
        }

        /// <summary>
        /// ViewModelの変化を購読し、画面に反映させる
        /// </summary>
        /// <param name="viewModel"></param>
        private void SubscribeViewModelChange(IMainCatViewModel viewModel)
        {
            viewModel.remainHp.SubscribeToText(remainHpText).AddTo(this);

            viewModel.remainTime.Subscribe(span => remainTimeText.text = string.Format("{0} days", span.Days)).AddTo(this);

            viewModel.canAttack.Subscribe(canAttack =>
            {
                playerInputField.interactable = canAttack;
                playerInputField.text = "";
                attackButton.interactable = canAttack;
            }).AddTo(this);
        }

        /// <summary>
        /// Playerの入力を購読する
        /// </summary>
        /// <param name="viewModel"></param>
        private void SubscribePlayerInput(IMainCatViewModel viewModel)
        {
            playerInputField.OnValueChangedAsObservable()
                .Subscribe(input => { attackButton.interactable = input != null; }).AddTo(this);

            attackButton.OnClickAsObservable().ThrottleFirst(TimeSpan.FromSeconds(5)).Subscribe(_ =>
            {
                var damageHours = float.Parse(playerInputField.text);
                viewModel.OnCLickAttackButton(damageHours);
            }).AddTo(this);

            reloadButton.OnClickAsObservable().Subscribe(_ =>
            {
                playerInputField.text = "";
                viewModel.OnClickReloadButton();
            }).AddTo(this);

            rankingButton.OnClickAsObservable().Subscribe(_ => { viewModel.OnClickRankingButton(); }).AddTo(this);
        }
    }
}