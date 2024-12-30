using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoadEntity : MonoBehaviour
{
    [Inject] CoinEntity.Pool _coinsPool;
    [SerializeField] private NPCCarGenerator npcCarGenerator;
    [SerializeField] private CoinGenerator coinGenerator;
    [SerializeField] private TriggerHandler roadEndTrigger;
    [SerializeField] private MeshRenderer meshRenderer;

    private RoadController _roadController;
    private Vector3 _initialRoadPosition;
    public float RoadLength => meshRenderer.bounds.size.z;


    public void Initialize(RoadController roadController)
    {
        npcCarGenerator.Initialize();
        coinGenerator.Initialize();
        roadEndTrigger.OnTriggered += OnPlayerReachedRoadEnd;
        _roadController = roadController;
        _initialRoadPosition = transform.position;
    }

    private void OnPlayerReachedRoadEnd(Transform player)
    {
        _roadController.OnRoadEndReached(this);
        npcCarGenerator.ResetGeneratedCars();
        npcCarGenerator.GenerateCarsOnTheRoad();
    }
    
    public void ResetRoadToInitialStatus()
    {
        transform.position = _initialRoadPosition;
        npcCarGenerator.ResetGeneratedCars();
        npcCarGenerator.GenerateCarsOnTheRoad();
    }
}
