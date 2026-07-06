using ConsoleGameFramework.Core;
using ConsoleGameFramework.UI;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleGameFramework.Contents;

enum GameEvent
{
    PlayerDamaged,
    PlayerHealed,
    PlayerDied,
    EnemyKilled,
    ItemPickedUp
}

class EventBus
{
    public static EventBus Instance { get; } = new EventBus();

    Dictionary<GameEvent, List<Delegate>> listeners = new Dictionary<GameEvent, List<Delegate>>();

    

    // 이벤트를 구독하는 메서드
    public void Subscribe<T>(GameEvent @event, Action<T> callback)
    {
        // 콜백으로 받은 메소드를 게임 이벤트에 맞춰서 리스트에 저장

        if (!listeners.ContainsKey(@event))
        {
            listeners[@event] = new List<Delegate>();
        }
        listeners[@event].Add(callback);
    }

    // 이벤트를 구독해제하는 메서드
    public void UnSubscribe<T>(GameEvent @event, Action<T> callback)
    {

        if (!listeners.ContainsKey(@event))
            listeners[@event].Remove(callback);


    }

    public void UnSubscribe<T>(GameEvent @event, Action<T, T> callback)
    {

        if (!listeners.ContainsKey(@event))
            listeners[@event].Remove(callback);


    }

    //구독한 이벤트들을 발행하는 메서드
    public void Publish<T>(GameEvent @event, T delta)
    {
        //Invoke
        foreach(Delegate callback in listeners[@event].ToList())
        {
            ((Action<T>)callback).Invoke(delta);
        }

    }

    public void Publish<T>(GameEvent @event, T delta, T alpha)
    {
        //Invoke
        
        //GameManager.Instance.Context.AddLog(); // 잘하면 가능ㄷㄷ
        foreach (Delegate callback in listeners[@event].ToList())
        {
            ((Action<T, T>)callback).Invoke(delta, alpha);
        }

    }

}