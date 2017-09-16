﻿using UniRx;
using TimeSpan = System.TimeSpan;

namespace Interface
{
    public interface IMainCatViewModel
    {
        IObservable<int> remainHp { get; }
        
        IObservable<TimeSpan> remainTime { get; }

        void OnCLickAttackButton(float damage);
    }
}