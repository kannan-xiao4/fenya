using System.Linq;
using Manager;
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
        /// <summary>
        /// 画面を表示するためのViewModel
        /// </summary>
        private readonly MainCatViewModel viewModel;

        /// <summary>
        /// 表示の対象となるFenyaVO
        /// </summary>
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
        /// 今日攻撃できるか？
        /// </summary>
        public ReactiveProperty<bool> canAttackToday = new BoolReactiveProperty(false);

        /// <summary>
        /// 攻撃ボタンを押したときの動作
        /// </summary>
        /// <param name="overWorkHours"></param>
        public void OnCLickAttackButton(float overWorkHours)
        {
            canAttackToday.Value = false;
            NCMBManager.Instance.AttackAndFetchFenyaHp(fenyaObject.Value, new DamageVO((int) overWorkHours * 1000))
                .Subscribe(x => fenyaObject.Value = x, Debug.LogError);
        }

        /// <summary>
        /// リロード処理
        /// </summary>
        public void OnClickReloadButton()
        {
            NCMBManager.Instance.FetchFenyaObject().Subscribe(obj => fenyaObject.Value = obj);
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
            var pageSetting = uiManager.GetPageSetting<MainCatSetting>();
            pageSetting.Bind(viewModel);
            uiManager.ReplaceCurrentPage<MainCatSetting>();

            NCMBManager.Instance.FetchTodayHistory()
                .Subscribe(list => canAttackToday.Value = list.All(x => x.CreateDate.GetValueOrDefault().Date != DateTime.Today.Date));
        }
    }
}