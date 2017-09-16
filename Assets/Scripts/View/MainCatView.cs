using System;
using System.Collections.Generic;
using Interface;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using ViewModel;
using Random = UnityEngine.Random;

namespace View
{
    public class MainCatView : MonoBehaviour
    {
        [SerializeField]
        private Image catMainImage;

        [SerializeField]
        private List<Sprite> catSprites;

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
            
            attackButton.OnClickAsObservable().Subscribe(_ =>
            {
                var damageHours = float.Parse(playerInputField.text);
                viewModel.OnCLickAttackButton(damageHours);
            }).AddTo(this);
        }
        
        private void Start()
        {
            Observable.Timer(TimeSpan.FromSeconds(1))
                .Select(time => Random.Range(1, 100))
                .Subscribe(rand =>
                {
                    var sprite = catSprites[CalucurateIndex(rand)];
                    catMainImage.sprite = sprite;
                }).AddTo(this);
        }

        /// <summary>
        /// 表示する画像を抽選する
        /// </summary>
        /// <param name="rand"></param>
        /// <returns></returns>
        private int CalucurateIndex(int rand)
        {
            if (rand == 1) return 2;
            if (rand <= 30) return 1;

            return 0;
        }
    }
}