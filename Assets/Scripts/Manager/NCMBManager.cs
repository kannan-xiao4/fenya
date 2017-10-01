using System.Collections.Generic;
using System.Linq;
using NCMB;
using NcmbAsObservables;
using UniRx;
using UnityEngine;
using Utility;
using ValueObject;

namespace Manager
{
    /// <summary>
    /// NCMBとの通信を行うクラス
    /// ToDO: 責務ごとにクラス分けが必要
    /// </summary>
    public class NCMBManager : SingletonMonoBehaviour<NCMBManager>
    {
        /// <summary>
        /// 現在ログインしているPlayer
        /// </summary>
        private static PlayerVO currentPlayerVo;

        /// <summary>
        /// 最新の有効なFenya情報取得する
        /// </summary>
        /// <returns></returns>
        public IObservable<FenyaVO> FetchFenyaObject()
        {
            var fenyaVo = new FenyaVO();

            return NcmbQueryHelper<NCMBObject>
                .FindAsync(fenyaVo.CreateNcmbQuery())
                .Select(list =>
                {
                    fenyaVo.UpdateByNCMBList(list);
                    return fenyaVo;
                });
        }

        /// <summary>
        /// 最新の攻撃記録を取得する
        /// </summary>
        /// <returns></returns>
        public IObservable<List<NCMBObject>> FetchTodayHistory()
        {
            var historyVo = new AttackHistoryVO(currentPlayerVo);

            return NcmbQueryHelper<NCMBObject>
                .FindAsync(historyVo.CreateTodayHistoryQuery());
        }

        /// <summary>
        /// 対象のFenyaへの攻撃履歴一覧を取得する
        /// </summary>
        /// <param name="fenyaVo">ランキングを取りたい対象のFenyaVO</param>
        /// <returns></returns>
        public IObservable<RankingVO> FetchRankingByFenyaVO(FenyaVO fenyaVo)
        {
            var historyVo = new AttackHistoryVO(fenyaVo);

            return NcmbQueryHelper<NCMBObject>
                .FindAsync(historyVo.CreateAttackHistoryQueryByFenyaVO())
                .Select(ncmbList => ncmbList.Select(ncmbObject => new AttackHistoryVO(ncmbObject)))
                .Where(list => list.Any())
                .Select(historyList => new RankingVO(historyList.ToList()));
        }

        /// <summary>
        /// Fenyaへの攻撃を保存する
        /// </summary>
        /// <param name="fenyaVo"></param>
        /// <param name="damage"></param>
        /// <returns></returns>
        public IObservable<NCMBObject> AttackFenyaByPlayer(FenyaVO fenyaVo, DamageVO damage)
        {
            var historyVo = new AttackHistoryVO(currentPlayerVo, fenyaVo, damage);
            var historyObject = historyVo.CreateNcmbObject();

            return historyObject.SaveAsyncAsStream();
        }
        
        /// <summary>
        /// 受け取ったFenyaVOでサーバのFenyaを更新する
        /// </summary>
        /// <param name="fenyaVo"></param>
        /// <returns></returns>
        public IObservable<NCMBObject> PostFenyaHp(FenyaVO fenyaVo)
        {
            var fenyaObject = fenyaVo.CreateNcmbObject();
            fenyaObject.FetchAsync();

            return fenyaObject.SaveAsyncAsStream();
        }

        /// <summary>
        /// ぷれいやーのダメージを記録し、FenyaのHpも更新する
        /// </summary>
        /// <param name="fenyaVo"></param>
        /// <param name="damage"></param>
        /// <returns>だめーじを受けたFenyaVO</returns>
        public IObservable<FenyaVO> AttackAndFetchFenyaHp(FenyaVO fenyaVo, DamageVO damage)
        {
            var damagedFenya = new FenyaVO(fenyaVo.ObjectId, fenyaVo.RemainHP - damage.Amount);

            return AttackFenyaByPlayer(damagedFenya, damage)
                .Zip(PostFenyaHp(damagedFenya), (ncmb1, ncmb2) => new FenyaVO(ncmb2))
                .First()
                .Repeat();
        }
        
        /// <summary>
        /// PlayerVOを用いて新規会員登録を行う
        /// </summary>
        /// <returns></returns>
        public IObservable<NCMBUser> SignUp(PlayerVO playerVo)
        {
            var userObject = playerVo.CreateNcmbUser();

            return userObject.SingUpAsyncAsStream().Do(SetCurrentUser);
        }

        /// <summary>
        /// PlayerVOよりログイン処理
        /// </summary>
        /// <param name="playerVo"></param>
        public void Login(PlayerVO playerVo)
        {
            NCMBUser.LogInAsync(playerVo.Name, playerVo.Password, error =>
            {
                if (error != null) Debug.LogError(error);
                SetCurrentUser(NCMBUser.CurrentUser);
            });
        }

        /// <summary>
        /// PlayerVOからLogin処理を行うストリーム
        /// </summary>
        /// <param name="playerVo"></param>
        /// <returns></returns>
        public IObservable<NCMBUser> LoginAsyncAsStream(PlayerVO playerVo)
        {
            var user = playerVo.CreateNcmbUser();

            return Observable.Create<NCMBUser>(observer =>
            {
                var gate = new object();
                var isDisposed = false;
                NCMBUser.LogInAsync(playerVo.Name, playerVo.Password, error =>
                {
                    lock (gate)
                    {
                        if (isDisposed) return;
                        if (error == null)
                        {
                            SetCurrentUser(user);
                            observer.OnNext(user);
                            observer.OnCompleted();
                        }
                        else
                        {
                            observer.OnError(error);
                        }
                    }
                });
                return Disposable.Create(() =>
                {
                    lock (gate)
                    {
                        isDisposed = true;
                    }
                });
            });
        }

        /// <summary>
        /// 現在のユーザーを更新する
        /// </summary>
        /// <param name="ncmbUser"></param>
        private static void SetCurrentUser(NCMBUser ncmbUser)
        {
            currentPlayerVo = new PlayerVO(ncmbUser.UserName, true); //自信なのでTrue
        }
    }
}