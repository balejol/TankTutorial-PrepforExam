using System;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntUnityEvent : UnityEvent<int>
{
    internal void Invoke()
    {
        throw new NotImplementedException();
    }
}
