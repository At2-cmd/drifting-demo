using UnityEngine;
using Zenject;

public class RoadController : MonoBehaviour, IInitializable, IRoadController
{
    [SerializeField] private RoadEntity[] roadEntities;

    public void Initialize()
    {
        InitializeRoads();
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
