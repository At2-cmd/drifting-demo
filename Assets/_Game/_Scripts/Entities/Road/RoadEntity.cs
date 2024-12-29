using System;
using UnityEngine;

public class RoadEntity : MonoBehaviour
{
    public void SetActivation(bool activationStatus)
    {
        gameObject.SetActive(activationStatus);
    }
}
