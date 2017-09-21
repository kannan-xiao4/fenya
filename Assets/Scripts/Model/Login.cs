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
    public class Login
    {
        private readonly LoginViewModel viewModel;

        private readonly ReactiveProperty<PlayerVO> playerReactive = new ReactiveProperty<PlayerVO>();

        private readonly Subject<Unit> _noticeLogin = new Subject<Unit>();

        public void OnClickLoginButton(string userName)
        {
            playerReactive.Value = new PlayerVO(userName);
        }

        private void LoginByNCMB(PlayerVO player)
        {
            NCMBManager.Instance.LoginAsyncAsStream(player).Subscribe(user => _noticeLogin.OnNext(Unit.Default), exception =>
            {
                Debug.LogWarning(exception);
                NCMBManager.Instance.SignUp(player).Subscribe(user => _noticeLogin.OnNext(Unit.Default), Debug.LogError);
            });
        }

        public Login()
        {
            viewModel = new LoginViewModel(this);

            playerReactive.Where(x => x != null).ThrottleFirst(TimeSpan.FromSeconds(3)).Subscribe(LoginByNCMB);
        }

        /// <summary>
        /// 画面を表示する
        /// </summary>
        public void Show()
        {
            var uiManager = UIManager.Instance;
            uiManager.InstancePage<LoginSetting>();
            uiManager.GetCurrentView<LoginView>().Bind(viewModel);
        }

        public IObservable<Unit> LoginSuccessAsObservable()
        {
            return _noticeLogin;
        }
    }
}