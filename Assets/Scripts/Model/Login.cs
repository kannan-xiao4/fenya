using Manager;
using PageSettings;
using UniRx;
using UnityEngine;
using ValueObject;
using View;
using ViewModel;
using TimeSpan = System.TimeSpan;

namespace Model
{
    /// <summary>
    /// ログイン処理を行うモデル
    /// </summary>
    public static class Login
    {
        /// <summary>
        /// ログインが行えたかどうかを通知するSubject
        /// </summary>
        private static readonly Subject<Unit> _noticeLogin = new Subject<Unit>();

        /// <summary>
        /// ログイン処理が完了した通知
        /// </summary>
        /// <returns></returns>
        public static IObservable<Unit> LoginSuccessAsObservable()
        {
            return _noticeLogin;
        }

        /// <summary>
        /// ログインプロセス
        /// </summary>
        public static void Process()
        {
            if (AutoLogin.CanAutoLogin())
            {
                AutoLogin.LoginByAutoName();
                return;
            }

            var model = new ManualLogin();
            model.Show();
        }

        /// <summary>
        /// PlayerVOを用いてNCMBにログインする
        /// </summary>
        /// <param name="player"></param>
        public static void LoginByNCMB(PlayerVO player)
        {
            NCMBManager.Instance.LoginAsyncAsStream(player).Subscribe(user => _noticeLogin.OnNext(Unit.Default),
                exception =>
                {
                    Debug.LogWarning(exception);
                    NCMBManager.Instance.SignUp(player)
                        .Subscribe(user => _noticeLogin.OnNext(Unit.Default), Debug.LogError);
                });
        }
    }
}