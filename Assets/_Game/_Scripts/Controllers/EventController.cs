using System;
using UnityEngine;
using Zenject;

public class EventController : MonoBehaviour, IInitializable
{
    public static EventController Instance { get; private set; }
    public void Initialize()
    {
        Instance = this;
    }

    public event Action OnRetryLevelButtonClicked;
    public void RaiseRetryLevelButtonClicked() => OnRetryLevelButtonClicked?.Invoke();
    
    public event Action OnBlackScreenOpened;
    public void RaiseBlackScreenOpened() => OnBlackScreenOpened?.Invoke();
    
    public event Action OnBlackScreenClosed;
    public void RaiseBlackScreenClosed() => OnBlackScreenClosed?.Invoke();
}
