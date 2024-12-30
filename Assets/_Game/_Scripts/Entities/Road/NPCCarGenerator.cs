using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class NPCCarGenerator : MonoBehaviour
{
    [Inject] NPCCarEntity.Pool _npcCarsPool;
    [SerializeField] private int carGenerationAmount;
    private int _generatedCarCount;
    private List<NPCCarEntity> _generatedCarsList = new();
    private Vector3 _carGenerationPosition;
    private float[] roadXPositions = new float[3] { -2.25f, 0f, 2.25f };
    private float _offsetBetweenGeneratedCars = 10;
    private float _initialGenerationOffset = 25;
    public void Initialize()
    {
        GenerateCarsOnTheRoad();
    }
    public void GenerateCarsOnTheRoad()
    {
        for (int i = 0; i <= carGenerationAmount; i++)
        {
            _carGenerationPosition.x = roadXPositions[Random.Range(0, roadXPositions.Length)];
            _carGenerationPosition.z = (transform.position.z) + _initialGenerationOffset + (_generatedCarCount * _offsetBetweenGeneratedCars);
            _generatedCarsList.Add(_npcCarsPool.Spawn(_carGenerationPosition));
            _generatedCarCount++;
        }
    }
    public void ResetGeneratedCars()
    {
        _generatedCarCount = 0;
        foreach (var npcCar in _generatedCarsList) npcCar.Despawn();
        _generatedCarsList.Clear();
    }
}
