using UnityEngine;
using Zenject;

public class EventController : MonoBehaviour, IInitializable
{
    public static EventController Instance { get; private set; }
    public void Initialize()
    {
        Instance = this;
    }
}
