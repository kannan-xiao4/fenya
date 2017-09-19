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
    /// </summary>
    public class NCMBManager : SingletonMonoBehaviour<NCMBManager>
    {
        private static NCMBUser currentUser;

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
        /// 受け取ったFenyaVOでサーバのFenyaを更新する
        /// </summary>
        /// <param name="fenyaVo"></param>
        /// <returns></returns>
        public IObservable<NCMBObject> PostFenyaHp(FenyaVO fenyaVo)
        {
            var fenyaObject = fenyaVo.CreateNcmbObject();

            return fenyaObject.SaveAsyncAsStream();
        }

        /// <summary>
        /// PlayerVOを用いて新規会員登録を行う
        /// </summary>
        /// <returns></returns>
        public IObservable<NCMBUser> SignUp(PlayerVO playerVo)
        {
            var userObject = playerVo.CreateNcmbUser();

            return userObject.SingUpAsyncAsStream().Do(user => currentUser = user);
        }

        /// <summary>
        /// PlayerVOよりログイン処理
        /// </summary>
        /// <param name="playerVo"></param>
        public void Login(PlayerVO playerVo)
        {
            NCMBUser.LogInAsync(playerVo.UserName, playerVo.Password, error =>
            {
                if (error != null) Debug.LogError(error);
                currentUser = NCMBUser.CurrentUser;
            });
        }

        public IObservable<NCMBUser> LoginAsyncAsStream(PlayerVO playerVo)
        {
            var user = playerVo.CreateNcmbUser();

            return Observable.Create<NCMBUser>(observer =>
            {
                var gate = new object();
                var isDisposed = false;
                NCMBUser.LogInAsync(playerVo.UserName, playerVo.Password, error =>
                {
                    lock (gate)
                    {
                        if (isDisposed) return;
                        if (error == null)
                        {
                            currentUser = user;
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
    }
}