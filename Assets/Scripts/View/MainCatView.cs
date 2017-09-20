using System;
using System.Collections.Generic;
using Interface;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
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

        /// <summary>
        /// ViewModelをBind
        /// </summary>
        /// <param name="viewModel"></param>
        public void Bind(IMainCatViewModel viewModel)
        {
            viewModel.remainHp.SubscribeToText(remainHpText).AddTo(this);

            viewModel.remainTime.Subscribe(span => remainTimeText.text = string.Format("{0} days", span.Days)).AddTo(this);

            playerInputField.OnValueChangedAsObservable().Subscribe(input =>
            {
                attackButton.interactable = input != null;
            }).AddTo(this);
            
            attackButton.OnClickAsObservable().ThrottleFirst(TimeSpan.FromSeconds(5)).Subscribe(_ =>
            {
                var damageHours = float.Parse(playerInputField.text);
                viewModel.OnCLickAttackButton(damageHours);
            }).AddTo(this);
        }
    }
}