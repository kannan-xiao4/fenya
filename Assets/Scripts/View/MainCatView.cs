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

        /// <summary>
        /// ViewModelをBind
        /// </summary>
        /// <param name="viewModel"></param>
        public void Bind(IMainCatViewModel viewModel)
        {
            viewModel.remainHp.SubscribeToText(remainHpText).AddTo(this);

            viewModel.remainTime.Subscribe(span => remainTimeText.text = string.Format("{0} days", span.Days)).AddTo(this);

            viewModel.canAttack.Subscribe(canAttack =>
            {
                playerInputField.interactable = canAttack;
                playerInputField.text = "";
                attackButton.interactable = canAttack;
            }).AddTo(this);

            playerInputField.OnValueChangedAsObservable().Subscribe(input =>
            {
                attackButton.interactable = input != null;
            }).AddTo(this);
            
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
        }
    }
}