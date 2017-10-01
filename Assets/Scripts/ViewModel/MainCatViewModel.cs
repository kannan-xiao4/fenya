using Interface;
using Model;
using UniRx;
using TimeSpan = System.TimeSpan;

namespace ViewModel
{
    /// <summary>
    /// Fenyaの表示のためのViewModel
    /// </summary>
    public class MainCatViewModel : IMainCatViewModel
    {
        /// <summary>
        /// 残りHPのObservable
        /// </summary>
        public IObservable<long> remainHp
        {
            get { return Model.remainHpAsObservable; }
        }

        /// <summary>
        /// 残り時間のObservable
        /// </summary>
        public IObservable<TimeSpan> remainTime
        {
            get { return Model.remainTimeAsObservable; }
        }

        /// <summary>
        /// 攻撃かのうかどうかのObservable
        /// </summary>
        public IObservable<bool> canAttack
        {
            get { return Model.canAttackToday; }
        }

        /// <summary>
        /// FenyaのModel
        /// </summary>
        private MainCat Model { get; set; }

        /// <summary>
        /// 攻撃ボタン処理
        /// </summary>
        /// <param name="damage"></param>
        public void OnCLickAttackButton(float damage)
        {
            Model.OnCLickAttackButton(damage);
        }

        /// <summary>
        /// リロードボタン処理
        /// </summary>
        public void OnClickReloadButton()
        {
            Model.OnClickReloadButton();
        }

        /// <summary>
        /// ランキングへの遷移
        /// </summary>
        public void OnClickRankingButton()
        {
            Model.ShowRankingPage();
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="model"></param>
        public MainCatViewModel(MainCat model)
        {
            Model = model;
        }
    }
}