using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoadEntity : MonoBehaviour
{
    [Inject] NPCCarEntity.Pool _npcCarsPool;
    [SerializeField] private TriggerHandler roadEndTrigger;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private int carGenerationAmount;

    private RoadController _roadController;
    private int _generatedCarCount;
    private float[] roadXPositions = new float[3] { -2.25f, 0f, 2.25f };
    private List<NPCCarEntity> _generatedCarsList = new();
    private Vector3 _carGenerationPosition;
    private float _offsetBetweenGeneratedCars = 10;
    private float _initialGenerationOffset = 25;
    public float RoadLength => meshRenderer.bounds.size.z;

    public void Initialize(RoadController roadController)
    {
        roadEndTrigger.OnTriggered += OnPlayerReachedRoadEnd;
        _roadController = roadController;
        GenerateCarsOnTheRoad();
    }

    private void OnPlayerReachedRoadEnd(Transform player)
    {
        _roadController.OnRoadEndReached(this);
        ResetRoad();
        GenerateCarsOnTheRoad();
    }

    private void ResetRoad()
    {
        _generatedCarCount = 0;
        foreach (var npcCar in _generatedCarsList) npcCar.Despawn();
        _generatedCarsList.Clear();
    }

    private void GenerateCarsOnTheRoad()
    {
        for (int i = 0; i <= carGenerationAmount; i++)
        {
            _carGenerationPosition.x = roadXPositions[Random.Range(0, roadXPositions.Length)];
            _carGenerationPosition.z = (transform.position.z) + _initialGenerationOffset + (_generatedCarCount * _offsetBetweenGeneratedCars);
            _generatedCarsList.Add(_npcCarsPool.Spawn(_carGenerationPosition));
            _generatedCarCount++;
        }
    }
}
