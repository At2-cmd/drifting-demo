using System;
using UnityEngine;
using Zenject;

public class RoadController : MonoBehaviour, IInitializable, IRoadController
{
    [SerializeField] private RoadEntity[] roadEntities;

    public void Initialize()
    {
        Subscribe();
        InitializeRoads();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }
    private void Subscribe()
    {
        EventController.Instance.OnBlackScreenOpened += OnBlackScreenOpenedHandler;
    }
    private void Unsubscribe()
    {
        EventController.Instance.OnBlackScreenOpened -= OnBlackScreenOpenedHandler;
    }

    private void OnBlackScreenOpenedHandler()
    {
        foreach (var road in roadEntities) road.ResetRoadToInitialStatus();
    }

    private void InitializeRoads()
    {
        foreach (var road in roadEntities)
        {
            road.Initialize(this);
        }
    }

    public void OnRoadEndReached(RoadEntity roadEntity)
    {
        roadEntity.transform.position += (Vector3.forward * (roadEntity.RoadLength * roadEntities.Length));
    }
}
