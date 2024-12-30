using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class NPCCarGenerator : GenerateableObjectBase
{
    [Inject] NPCCarEntity.Pool _npcCarsPool;
    public void Initialize()
    {
        GenerateCarsOnTheRoad();
    }
    public void GenerateCarsOnTheRoad()
    {
        for (int i = 0; i <= GenerationAmount; i++)
        {
            TempGenerationPosition.x = RoadXPositions[Random.Range(0, RoadXPositions.Length)];
            TempGenerationPosition.z = (transform.position.z) + InitialGenerationOffset + (CurrentlyGeneratedCount * OffsetBetweenGeneratedObjects);
            GeneratedObjectsList.Add(_npcCarsPool.Spawn(TempGenerationPosition));
            CurrentlyGeneratedCount++;
        }
    }
    public void ResetGeneratedCars()
    {
        CurrentlyGeneratedCount = 0;
        foreach (NPCCarEntity npcCar in GeneratedObjectsList) npcCar.Despawn();
        GeneratedObjectsList.Clear();
    }
}
