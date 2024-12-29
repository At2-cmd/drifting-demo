using System;
using UnityEngine;
using Zenject;

public class RoadController : MonoBehaviour, IInitializable
{
    [SerializeField] private RoadEntity[] roadEntities;
    private int _generatedRoadIndex;
    public void Initialize()
    {
        GenerateRoad();
    }

    private void GenerateRoad()
    {
        //roadEntities[_generatedRoadIndex].SetActivation(true);
    }
}
