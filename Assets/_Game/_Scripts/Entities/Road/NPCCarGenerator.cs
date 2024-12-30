using UnityEngine;
using Zenject;

public class NPCCarGenerator : GenerateableObjectBase
{
    [Inject] NPCCarEntity.Pool _npcCarsPool;
    public void Initialize()
    {
        GenerateObjects();
    }
    public override void GenerateObjects()
    {
        for (int i = 0; i <= GenerationAmount; i++)
        {
            TempGenerationPosition.x = RoadXPositions[Random.Range(0, RoadXPositions.Length)];
            TempGenerationPosition.z = (transform.position.z) + InitialGenerationOffset + (CurrentlyGeneratedCount * OffsetBetweenGeneratedObjects);
            GeneratedObjectsList.Add(_npcCarsPool.Spawn(TempGenerationPosition));
            CurrentlyGeneratedCount++;
        }
    }
    public override void ResetGeneratedObjects()
    {
        CurrentlyGeneratedCount = 0;
        foreach (NPCCarEntity npcCar in GeneratedObjectsList) npcCar.Despawn();
        GeneratedObjectsList.Clear();
    }
}
