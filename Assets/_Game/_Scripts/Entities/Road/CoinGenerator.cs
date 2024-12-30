using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CoinGenerator : MonoBehaviour
{
    [Inject] CoinEntity.Pool _coinsPool;
    public void Initialize()
    {
        GenerateCoinsOnTheRoad();
    }

    private void GenerateCoinsOnTheRoad()
    {

    }
}
