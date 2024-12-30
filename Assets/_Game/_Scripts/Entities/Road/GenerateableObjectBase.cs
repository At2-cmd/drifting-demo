using System.Collections.Generic;
using UnityEngine;

public abstract class GenerateableObjectBase : MonoBehaviour
{
    [SerializeField] protected int GenerationAmount;
    [SerializeField] protected float OffsetBetweenGeneratedObjects;
    protected int CurrentlyGeneratedCount;
    protected Vector3 TempGenerationPosition;
    protected float InitialGenerationOffset = 25;
    protected List<IGenerateableObjectOnRoad> GeneratedObjectsList = new();
    protected float[] RoadXPositions = new float[3] { -2.25f, 0f, 2.25f };

    public abstract void GenerateObjects();
    public abstract void ResetGeneratedObjects();
}
