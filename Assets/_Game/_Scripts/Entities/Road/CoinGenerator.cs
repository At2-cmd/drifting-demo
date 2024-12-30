using UnityEngine;
using Zenject;

public class CoinGenerator : GenerateableObjectBase
{
    [Inject] CoinEntity.Pool _coinsPool;
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
            GeneratedObjectsList.Add(_coinsPool.Spawn(TempGenerationPosition));
            CurrentlyGeneratedCount++;
        }
    }
    public override void ResetGeneratedObjects()
    {
        CurrentlyGeneratedCount = 0;
        foreach (CoinEntity coin in GeneratedObjectsList) coin.Despawn();
        GeneratedObjectsList.Clear();
    }
}
