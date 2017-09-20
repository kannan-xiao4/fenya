using Manager;
using NCMB;
using PageSettings;
using UniRx;
using UnityEngine;
using ValueObject;
using View;
using ViewModel;
using NCMBManager = Manager.NCMBManager;
using TimeSpan = System.TimeSpan;
using DateTime = System.DateTime;

namespace Model
{
    /// <summary>
    /// MainCatのロジックをまとめるModel
    /// </summary>
    public class MainCat
    {
        private readonly MainCatViewModel viewModel;

        private readonly ReactiveProperty<FenyaVO> fenyaObject = new ReactiveProperty<FenyaVO>();

        /// <summary>
        /// Fenyaの残りHP
        /// </summary>
        public ReactiveProperty<long> remainHpAsObservable = new ReactiveProperty<long>();

        /// <summary>
        /// Fenyaの残り時間
        /// </summary>
        public ReactiveProperty<TimeSpan> remainTimeAsObservable = new ReactiveProperty<TimeSpan>();

        /// <summary>
        /// 攻撃ボタンを押したときの動作
        /// </summary>
        /// <param name="damage"></param>
        public void OnCLickAttackButton(float damage)
        {
            NCMBManager.Instance.AttackAndFetchFenyaHp(fenyaObject.Value, (int)damage * 1000)
                .Subscribe(x => fenyaObject.Value = x, Debug.LogError);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainCat()
        {
            viewModel = new MainCatViewModel(this);
            NCMBManager.Instance.FetchFenyaObject().Subscribe(obj => fenyaObject.Value = obj);

            fenyaObject.Where(x => x != null).Subscribe(obj =>
            {
                remainTimeAsObservable.Value = obj.RemaiTimeSpan;
                remainHpAsObservable.Value = obj.RemainHP;
            });
        }

        /// <summary>
        /// 画面を表示する
        /// </summary>
        public void Show()
        {
            var uiManager = UIManager.Instance;
            uiManager.ReplaceCurrentPage<MainCatSetting>();
            uiManager.GetCurrentView<MainCatView>().Bind(viewModel);
        }
    }
}